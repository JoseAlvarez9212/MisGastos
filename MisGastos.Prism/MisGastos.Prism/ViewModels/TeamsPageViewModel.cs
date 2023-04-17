using DryIoc;
using MisGastos.Prism.Enums;
//using Firebase.Auth;
//using Firebase.Auth.Providers;
using MisGastos.Prism.Helpers;
using MisGastos.Prism.Models;
using MisGastos.Prism.Models.FirebaseDB;
using MisGastos.Prism.Services.API;
using MisGastos.Prism.Services.Firebase;
using MisGastos.Prism.Services.Resources.Strings;
using MisGastos.Prism.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace MisGastos.Prism.ViewModels
{
    public class TeamsPageViewModel : ViewModelBase
    {
        private const string PARAM_TEAM = nameof(TeamModel);

        private readonly INavigationService _navigationService;
        private readonly IStringsService _stringsService;
        private readonly IFirebaseDataContainerService _firebaseDataBase;
        private DelegateCommand _addTeamCommand;
        private DelegateCommand _continueCommand;
        ObservableCollection<ItemViewModelAddCommand<TeamModel>> _teams;
        private bool _isVisibleTextEmptyList;
        private bool _isVisibleTeamsCV;

        public TeamsPageViewModel(INavigationService navigationService,
            IStringsService stringsService,
            IFirebaseDataContainerService firebaseDataBase) :
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
        public DelegateCommand AddTeamCommand =>
            _addTeamCommand ?? (_addTeamCommand =
            new DelegateCommand(AddTeam));


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

        public ObservableCollection<ItemViewModelAddCommand<TeamModel>> Teams
        {
            get => _teams;
            set => SetProperty(ref _teams, value);
        }
        #endregion

        /// <summary>
        /// Get Teams async.
        /// </summary>
        private async void GetTeamsAsync()
        { 
            var teams = await _firebaseDataBase.TeamsData.GetItemsAsync(true);
            if (teams != null)
            {
                Teams = ConvertItemToCommand(teams);
                IsVisibleTeamsCV = Teams.Count > 0;
                IsVisibleTextEmptyList = Teams.Count == 0;
            }
            else
            {
                IsVisibleTextEmptyList = true;
            }
        }

        /// <summary>
        /// Convert item to command.
        /// </summary>
        /// <param name="teamModel">TeamModel IEnumerable.</param>
        /// <returns>ItemViewModel with command.</returns>
        private ObservableCollection<ItemViewModelAddCommand<TeamModel>> ConvertItemToCommand(IEnumerable<TeamModel> teamModel)
        {
            var OCTeamItemVieModel = new ObservableCollection<ItemViewModelAddCommand<TeamModel>>();
            teamModel.ForEach(item =>
            {
                var cm = new DelegateCommand(() => Continue(item));
                var teamItem = new ItemViewModelAddCommand<TeamModel>(item, cm);
                OCTeamItemVieModel.Add(teamItem);
            });
            return OCTeamItemVieModel;
        }

        /// <summary>
        /// Continue to ExpenseTabbedPage.
        /// </summary>
        /// <param name="teamModel">TeamModel.</param>
        private async void Continue(TeamModel teamModel)
        {
            var parameters = new NavigationParameters();
            parameters.Add(PARAM_TEAM, teamModel);
            await _navigationService.NavigateAsync($"{nameof(ExpenseTabbedPage)}", parameters, animated: true);
        }

        /// <summary>
        /// ContinueButton create team
        /// </summary>
        private async void AddTeam()
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
            var addTeam = await _firebaseDataBase.TeamsData.AddItemAsync(team);
            if (addTeam)
            {
                await App.Current.MainPage.DisplayAlert("Success", "equipo agregado correctamente.", "aceptar");
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
                cancel: "Salir");
            return teamName;
        }
    }
}

