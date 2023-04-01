using DryIoc;
//using Firebase.Auth;
//using Firebase.Auth.Providers;
using MisGastos.Prism.Helpers;
using MisGastos.Prism.Services.API;
using MisGastos.Prism.Services.Firebase;
using MisGastos.Prism.Services.Resources.Strings;
using MisGastos.Prism.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MisGastos.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private IStringsService _stringsService;
        private IFirebaseAuthentication _firebaseAuthentication;
        private IExchangeRatesServices _exchangeRatesServices;
        private string _emailEntry;
        private string _passwordEntry;
        private DelegateCommand _entryUnfocusedCommand;
        private DelegateCommand _loginButtonCommand;
        private DelegateCommand _registerButtonCommand;
        private bool _isVisibleErrorEmail;
        private bool _loginButtonEnabled;

        //public LoginPageViewModel(INavigationService navigationService,
        //    IStringsService stringsService,
        //    IFirebaseAuthentication firebaseAuthentication,
        //    IExchangeRatesServices exchangeRatesServices) : base(navigationService)
        //{
        //    _navigationService = navigationService;
        //    _stringsService = stringsService;
        //    _firebaseAuthentication = firebaseAuthentication;
        //    _exchangeRatesServices = exchangeRatesServices;
        //    _loginButtonEnabled = false;
        //    _isVisibleErrorEmail = false;
        //}
        public LoginPageViewModel(INavigationService navigationService,
                IStringsService stringsService,
                IExchangeRatesServices exchangeRatesServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _stringsService = stringsService;
            _exchangeRatesServices = exchangeRatesServices;
            _loginButtonEnabled = false;
            _isVisibleErrorEmail = false;
        }

        public DelegateCommand EntryUnfocusedCommand =>
            _entryUnfocusedCommand ?? (_entryUnfocusedCommand =
            new DelegateCommand(EntryUnfocused));

        public DelegateCommand LoginButtonCommand =>
            _loginButtonCommand ?? (_loginButtonCommand =
            new DelegateCommand(LoginAsync));

        public DelegateCommand RegisterButtonCommand =>
            _registerButtonCommand ?? (_registerButtonCommand =
            new DelegateCommand(RegisterAsync));

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

        public bool LoginButtonEnabled
        {
            get => _loginButtonEnabled;
            set => SetProperty(ref _loginButtonEnabled, value);
        }

        private void EntryUnfocused()
        {
            IsVisibleErrorEmail = !string.IsNullOrEmpty(EmailEntry) && !EmailEntry.IsValidEmail();
            LoginButtonEnabled = EmailEntry.IsValidEmail() && !string.IsNullOrEmpty(PasswordEntry);
        }

        private async void LoginAsync()
        {
            
            if (!EmailEntry.IsValidEmail() || string.IsNullOrEmpty(PasswordEntry))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingrese un correo electrónico y contraseña válido", "Aceptar");
                return;
            }
                    
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error de red", "Revise su conección a internet", "Aceptar");
                return;
            }

            var loginResult = await _firebaseAuthentication.LoginWithEmailAndPassword(EmailEntry, PasswordEntry);
            if (loginResult.IsSucces)
            {
                await _navigationService.NavigateAsync($"{nameof(HomePage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }

            /*
            string WebAPIkey = "AIzaSyBosudD07QmcwaOv53BsPVCN1nOXP7c01Y";
            string MyAuthDomain = "misgastos-d5408.firebaseapp.com";

            var config = new FirebaseAuthConfig
            {
                ApiKey = WebAPIkey,
                AuthDomain = MyAuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    //new GoogleProvider(),
                    //new FacebookProvider(),
                    //new TwitterProvider(),
                    //new GithubProvider(),
                    //new MicrosoftProvider(),
                    new EmailProvider()
                }
            };

            var authProvider = new FirebaseAuthClient(config);
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailEntry.ToString(), PasswordEntry.ToString());
                //var content = await auth.User.GetIdTokenAsync();
                //var serializedcontnet = JsonConvert.SerializeObject(content);

                //Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

                //Puede navegar al tener autorizacion
                await _navigationService.NavigateAsync($"NavigationPage/{nameof(HomePage)}");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }
            */
            //await _navigationService.NavigateAsync($"{nameof(HomePage)}");
        }

        private async void RegisterAsync()
        {
            await _navigationService.NavigateAsync($"{nameof(RegisterPage)}");
            //await _exchangeRatesServices.GetExchangeRatesAsync(new Models.ExchangeRate.ExchangeRatesRequest
            //{
            //    Amount = 1,
            //    From = "USD",
            //    To = "MXN"
            //});
        }
    }
}
