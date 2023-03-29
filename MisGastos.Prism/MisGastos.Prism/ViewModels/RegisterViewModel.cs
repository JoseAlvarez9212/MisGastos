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
            //Title = _stringsService.RegisterTitlePage;
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
        private void EntryUnfocused()
        {
            IsVisibleErrorEmail = !string.IsNullOrEmpty(EmailEntry) && !EmailEntry.IsValidEmail();
            _registerButtonEnabled = EmailEntry.IsValidEmail() && !string.IsNullOrEmpty(PasswordEntry);
        }

        /// <summary>
        /// email validation Focused
        /// </summary>
        private void EntryFocused()
        {
            IsVisibleErrorEmail = false;
        }

        public async void RegisterAsync()
        {
            if (await ValidationForm())
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





        }

        private async Task<bool> ValidationForm()
        {
            var isValid = new List<Func<Task<bool>>>
            {
                async () => await ValidationEntry(NameEntry, _stringsService.RegisterNameEntryText),
                async () => await ValidationEntry(LastNameEntry, _stringsService.RegisterLastNameEntryText),
                async () => await ValidationEntry(EmailEntry, _stringsService.RegisterEmailEntryText),
                async () => await ValidationEntry(PasswordEntry, _stringsService.RegisterPasswordEntryText),
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

        private async Task<bool> ValidationEntry(string entryText, string entryName)
        {
            if (!string.IsNullOrEmpty(entryText))
            {
                return true;
            }
            var errorText = string.Format(_stringsService.ErrorEntryText, entryName ?? string.Empty);
            await App.Current.MainPage.DisplayAlert(_stringsService.ErrorTitleText,
                errorText,
                _stringsService.AceptButton);
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

