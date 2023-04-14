using System;
using MisGastos.Prism.Models.FirebaseDB;
using Prism.Navigation;

namespace MisGastos.Prism.ViewModels
{
	public class ExpenseTabbedPageViewModel : ViewModelBase
    {
        private const string PARAM_TEAM = nameof(TeamModel);

        private readonly INavigationService _navigationService;

        public ExpenseTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey(PARAM_TEAM))
            {
                var team = parameters.GetValue<TeamModel>(PARAM_TEAM);
                Title = team.Name;
            }

        }
    }
}

