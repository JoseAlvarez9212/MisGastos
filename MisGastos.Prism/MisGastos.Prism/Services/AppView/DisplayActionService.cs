using System;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Essentials;

namespace MisGastos.Prism.Services.AppView
{
	public class AppViewService : IAppViewService
    {
		public async Task DisplayAlert(string title, string message, string cancel)
		{
            await App.Current.MainPage.DisplayAlert(title, message, cancel);
        }

		public bool InternetConnect()
		{
            return Connectivity.NetworkAccess != NetworkAccess.Internet;
        }
	}
}

