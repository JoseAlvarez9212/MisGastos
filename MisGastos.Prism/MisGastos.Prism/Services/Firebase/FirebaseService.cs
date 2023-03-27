using System;
using System.Threading.Tasks;
//using Firebase.Auth;
//using Firebase.Auth.Providers;
using Firebase.Database;
using MisGastos.Prism.Views;
using Prism.Navigation;

namespace MisGastos.Prism.Services.Firebase
{
    public class FirebaseService
    {
        /*
        FirebaseClient firebaseClient;
        string WebAPIkey = "";
        string MyAuthDomain = "";
        FirebaseAuthProvider[] Providers;

        public FirebaseService()
        {
            firebaseClient = new FirebaseClient("");
            Providers = new FirebaseAuthProvider[]
            {
                //new GoogleProvider(),
                //new FacebookProvider(),
                //new TwitterProvider(),
                //new GithubProvider(),
                //new MicrosoftProvider(),
                new EmailProvider()
            };

        }

        public async void SignInWithEmailAndPasswordAsync(string email, string password)
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = WebAPIkey,
                AuthDomain = MyAuthDomain,
                Providers = Providers
            };

            var authProvider = new FirebaseAuthClient(config);
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                //var content = await auth.User.GetIdTokenAsync();
                //var serializedcontnet = JsonConvert.SerializeObject(content);

                //Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

                //Puede navegar al tener autorizacion
                //await _navigationService.NavigateAsync($"NavigationPage/{nameof(HomePage)}");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }
        }*/
    }
}

