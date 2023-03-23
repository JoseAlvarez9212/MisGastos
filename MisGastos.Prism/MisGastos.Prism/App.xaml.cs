using MisGastos.Prism.Services.Resources.Strings;
using MisGastos.Prism.ViewModels;
using MisGastos.Prism.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MisGastos.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //var navigationPage = new NavigationPage();
            //navigationPage.BarBackgroundColor = ColorConverters.FromHex("#5D1049");
            //await NavigationService.NavigateAsync($"{nameof(navigationPage)}/{nameof(LoginPage)}");
            await NavigationService.NavigateAsync($"MyNavigationPage/{nameof(LoginPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.Register<IStringsService, StringsService>();

            containerRegistry.RegisterForNavigation<MyNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<AddExpensePage, AddExpensePageViewModel>();
        }
    }

    internal class MyNavigationPage : NavigationPage
    {
        public MyNavigationPage()
        {
            this.BarBackgroundColor = ColorConverters.FromHex("#4F0A3A");
            //this.BackgroundColor = ColorConverters.FromHex("#5D1049");
            this.BarTextColor = Color.White;
        }
    }
}
