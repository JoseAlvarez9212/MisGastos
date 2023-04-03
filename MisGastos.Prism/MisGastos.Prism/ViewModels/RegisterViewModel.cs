using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MisGastos.Prism.Helpers;
using MisGastos.Prism.Services.Firebase;
using MisGastos.Prism.Services.Resources.Strings;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Essentials;

namespace MisGastos.Prism.ViewModels
{
    /// <summary>
    /// Register user app ViewModel
    /// </summary>
	public class RegisterViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private IStringsService _stringsService;
        private IFirebaseAuthentication _firebaseAuthentication;
        private string _nameEntry;
        private string _lastNameEntry;
        private string _emailEntry;
        private string _passwordEntry;
        private DelegateCommand _entryUnfocusedCommand;
        private DelegateCommand _entryFocusedCommand;
        private DelegateCommand _registerButtonCommand;
        private DelegateCommand _backButtonCommand;
        private bool _isVisibleErrorEmail;
        private bool _registerButtonEnabled;

        public RegisterViewModel(INavigationService navigationService,
			IStringsService stringsService,
			IFirebaseAuthentication firebaseAuthentication) :
			base(navigationService)
        {
            _navigationService = navigationService;
            _stringsService = stringsService;
            _firebaseAuthentication = firebaseAuthentication;

            InitializeComponent();
        }

        /// <summary>
        /// Initialize component
        /// </summary>
        private void InitializeComponent()
        {
            _registerButtonEnabled = false;
            _isVisibleErrorEmail = false;
        }

        #region View
        public DelegateCommand EntryUnfocusedCommand =>
            _entryUnfocusedCommand ?? (_entryUnfocusedCommand =
            new DelegateCommand(EntryUnfocused));

        public DelegateCommand EntryFocusedCommand =>
            _entryFocusedCommand ?? (_entryFocusedCommand =
            new DelegateCommand(EntryFocused));

        public DelegateCommand RegisterButtonCommand =>
            _registerButtonCommand ?? (_registerButtonCommand =
            new DelegateCommand(RegisterAsync));

        public DelegateCommand BackButtonCommand =>
            _backButtonCommand ?? (_backButtonCommand =
            new DelegateCommand(BackButtonAsync));

        public string NameEntry
        {
            get => _nameEntry;
            set => SetProperty(ref _nameEntry, value);
        }

        public string LastNameEntry
        {
            get => _lastNameEntry;
            set => SetProperty(ref _lastNameEntry, value);
        }

        public string EmailEntry
        {
            get => _emailEntry;
            set => SetProperty(ref _emailEntry, value);
        }

        public string PasswordEntry
        {
            get => _passwordEntry;
            set => SetProperty(ref _passwordEntry, value);
        }

        public bool IsVisibleErrorEmail
        {
            get => _isVisibleErrorEmail;
            set => SetProperty(ref _isVisibleErrorEmail, value);
        }

        public bool RegisterButtonEnabled
        {
            get => _registerButtonEnabled;
            set => SetProperty(ref _registerButtonEnabled, value);
        }
        #endregion

        /// <summary>
        /// email validation Unfocused
        /// </summary>
        private async void EntryUnfocused()
        {
            IsVisibleErrorEmail = !string.IsNullOrEmpty(EmailEntry) && !EmailEntry.IsValidEmail();
            RegisterButtonEnabled = await ValidationForm(false) && EmailEntry.IsValidEmail();
        }

        /// <summary>
        /// email validation Focused
        /// </summary>
        private void EntryFocused()
        {
            IsVisibleErrorEmail = false;
        }

        //TODO: Agregar textos al StringService - agregar pantalla de success
        /// <summary>
        /// Register user async.
        /// </summary>
        public async void RegisterAsync()
        {
            if (await ValidationForm(true))
            {
                return;
            }

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert(
                    _stringsService.ErrorTitleText,
                    _stringsService.ErrorNetworkAccessText,
                    _stringsService.AceptButton);
                return;
            }

            var response = await _firebaseAuthentication.RegisterWithEmailAndPassword(EmailEntry, PasswordEntry);
            if (response.IsSucces)
            {
                await App.Current.MainPage.DisplayAlert("Bienvenido",
                   "Usuario registrado correctamente.",
                   _stringsService.AceptButton);
                await NavigationService.GoBackAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(_stringsService.ErrorTitleText,
                   response.Exception.Message,
                   _stringsService.AceptButton);
            }
        }

        /// <summary>
        /// Validation entries
        /// </summary>
        /// <param name="showDisplayAlert">Show DisplayAlert error</param>
        /// <returns>is valid form</returns>
        private async Task<bool> ValidationForm(bool showDisplayAlert)
        {
            var isValid = new List<Func<Task<bool>>>
            {
               async () => await ValidationEntry(NameEntry, _stringsService.RegisterNameEntryText, showDisplayAlert),
               async () => await ValidationEntry(LastNameEntry, _stringsService.RegisterLastNameEntryText, showDisplayAlert),
               async () => await ValidationEntry(EmailEntry, _stringsService.RegisterEmailEntryText, showDisplayAlert),
               async () => await ValidationEntry(PasswordEntry, _stringsService.RegisterPasswordEntryText, showDisplayAlert),
            };
            foreach (var item in isValid)
            {
                if (!await item())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Validation entry is empty.
        /// </summary>
        /// <param name="entry">Entry</param>
        /// <param name="entryName">Entry name.</param>
        /// <param name="showDisplayAlert">Show DisplayAlert error</param>
        /// <returns>isValid</returns>
        private async Task<bool> ValidationEntry(string entry, string entryName, bool showDisplayAlert)
        {
            if (!string.IsNullOrEmpty(entry))
            {
                return true;
            }

            if (showDisplayAlert)
            {
                var errorText = string.Format(_stringsService.ErrorEntryText, entryName ?? string.Empty);
                await App.Current.MainPage.DisplayAlert(_stringsService.ErrorTitleText,
                    errorText,
                    _stringsService.AceptButton);
            }
            return false;
        }

        /// <summary>
        /// Back button async
        /// </summary>
        public async void BackButtonAsync()
        {
            await _navigationService.GoBackAsync();
        }
    }
}

