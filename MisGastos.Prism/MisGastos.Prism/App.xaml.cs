using System;
using MisGastos.Prism.Services.API;
using MisGastos.Prism.Services.AppView;
using MisGastos.Prism.Services.Firebase;
using MisGastos.Prism.Services.Resources.ConfigApp;
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
            await NavigationService.NavigateAsync($"MyNavigationPage/{nameof(LoginPage)}");
            //await NavigationService.NavigateAsync($"{nameof(ExpenseTabbedPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<MyNavigationPage>();
            containerRegistry.RegisterForNavigation<TeamsPage, TeamsPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterViewModel>();
            containerRegistry.RegisterForNavigation<ExpenseTabbedPage, ExpenseTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<AddExpensePage, AddExpensePageViewModel>();

            containerRegistry.Register<IEnvironmentService, EnvironmentService>();
            containerRegistry.Register<IAppViewService, AppViewService>();
            containerRegistry.Register<IStringsService, StringsService>();
            containerRegistry.Register<IFirebaseDataBaseService, FirebaseDataBaseService>();

            if (AppInit.ENVIRONMENT == Enums.EnvironmentsType.Mock)
            {
                //TODO: CREAR SERVICIOS MOCK
            }
            else
            {
                containerRegistry.Register<IExchangeRatesServices, ExchangeRatesServices>();
            }
        }
    }

    internal class MyNavigationPage : NavigationPage
    {
        public MyNavigationPage()
        {
            this.BarBackgroundColor = ColorConverters.FromHex("#4F0A3A");
            this.BarTextColor = Color.White;
        }
    }
}
