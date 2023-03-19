using DryIoc;
using Firebase.Auth;
using Firebase.Auth.Providers;
using MisGastos.Prism.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace MisGastos.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _emailEntry;
        private string _passwordEntry;
        private DelegateCommand _loginButtonCommand;

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Login";
        }

        public DelegateCommand LoginButtonCommand =>
            _loginButtonCommand ?? (_loginButtonCommand = new DelegateCommand(LoginAsync));

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

        private async void LoginAsync()
        {
            /*
            if (string.IsNullOrEmpty(EmailEntry))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingrese Email", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(PasswordEntry))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingrese Password", "Aceptar");
                return;
            }

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error de red", "Aceptar");
                return;
            }

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
            await _navigationService.NavigateAsync($"{nameof(HomePage)}");
        }
    }
}
