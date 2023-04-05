using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MisGastos.Prism.Enums;
using MisGastos.Prism.ItemViewModels;
using MisGastos.Prism.Models.FirebaseDB;
using MisGastos.Prism.Services.Firebase;
using MisGastos.Prism.Services.Resources.Strings;
using Prism.Commands;
using Prism.Navigation;

namespace MisGastos.Prism.ViewModels
{
    public class TeamsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
        private readonly IStringsService _stringsService;
        private readonly IFirebaseDataBaseService _firebaseDataBase;
        private DelegateCommand _continueButtonCommand;
        ObservableCollection<TeamModel> _teams;
        private bool _isVisibleTextEmptyList;
        private bool _isVisibleTeamsCV;

        public TeamsPageViewModel(INavigationService navigationService,
            IStringsService stringsService,
            IFirebaseDataBaseService firebaseDataBase) :
            base(navigationService)
        {
            _navigationService = navigationService;
            _stringsService = stringsService;
            _firebaseDataBase = firebaseDataBase;

            Title = "Equipos";
            _isVisibleTextEmptyList = false;
            _isVisibleTeamsCV = false;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            GetTeamsAsync();
        }

        #region View
        public DelegateCommand ContinueButtonCommand =>
            _continueButtonCommand ?? (_continueButtonCommand =
            new DelegateCommand(ContinueButton));

        public bool IsVisibleTextEmptyList
        {
            get => _isVisibleTextEmptyList;
            set => SetProperty(ref _isVisibleTextEmptyList, value);
        }

        public bool IsVisibleTeamsCV
        {
            get => _isVisibleTeamsCV;
            set => SetProperty(ref _isVisibleTeamsCV, value);
        }

        public ObservableCollection<TeamModel> Teams
        {
            get => _teams;
            set => SetProperty(ref _teams, value);
        }
        #endregion

        private async void GetTeamsAsync()
        {
            var teams = await _firebaseDataBase.GetItemsAsync<TeamModel>(FirebaseNodeType.Teams);
            if (teams != null)
            {
                Teams = new ObservableCollection<TeamModel>(teams);
                IsVisibleTeamsCV = Teams.Count > 0;
                IsVisibleTextEmptyList = Teams.Count == 0;
            }
            else
            {
                IsVisibleTextEmptyList = true;
            }
        }

        /// <summary>
        /// ContinueButton create team
        /// </summary>
        private async void ContinueButton()
        {
            string teamName = await AddTeamDisplayPromptAsync();
            if (string.IsNullOrEmpty(teamName))
            {
                return;
            }
            //TODO: OBTNER CORREO DESDE PREFERENCES
            var team = new TeamModel
            {
                Name = teamName,
                Users = new List<UserTeam>
                {
                    new UserTeam
                    {
                        Email = "jose.alvarez9212@gmail.com",
                        IsAdmin = true
                    }
                }
            };
            var addTeam = await _firebaseDataBase.AddItemAsync<TeamModel>(team, FirebaseNodeType.Teams);
            if (addTeam)
            {
                await App.Current.MainPage.DisplayAlert("Success","equipo agregado correctamente.","aceptar");
                GetTeamsAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "ha ocurrido un error, intentalo más tarde.", "aceptar");
            }
        }

        private async Task<string> AddTeamDisplayPromptAsync()
        {
            var teamName = await App.Current.MainPage.DisplayPromptAsync("Empecemos", "¿Que nombre le pondremos al equipo?",
                placeholder: "Ej. Amor, Amigos, Compadres, etc...",
                keyboard: Xamarin.Forms.Keyboard.Text,
                accept: "Agregar",
                cancel: "Cancelar");
            return teamName;
        }
    }
}

