using MisGastos.Prism.ItemViewModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MisGastos.Prism.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        ObservableCollection<ExpenseItemViewModel> _expenses;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Mis Gastos";

            //TODO: AGREGAR DATOS DE SERVICIO
            Expenses = new ObservableCollection<ExpenseItemViewModel>
            {
                new ExpenseItemViewModel("Mastes 14 de febrero de 2023", new List<ExpenseDto>
                {
                    new ExpenseDto
                    {
                        Title = "Title 1",
                        Description = "Description 1",
                        Amount = 245,
                        Date = DateTime.Now
                    },
                    new ExpenseDto
                    {
                        Title = "Title 2",
                        Description = "Description 2",
                        Amount = 245,
                        Date = DateTime.Now
                    },
                    new ExpenseDto
                    {
                        Title = "Title 3",
                        Description = "Description 3",
                        Amount = 245,
                        Date = DateTime.Now
                    }
                }),
                /*new ExpenseItemViewModel("Lunes 13 de febrero de 2023", new List<ExpenseDto>
                {
                    new ExpenseDto
                    {
                        Title = "Title 1",
                        Description = "Description 1",
                        Amount = 245,
                        Date = DateTime.Now.AddDays(-1)
                    },
                    new ExpenseDto
                    {
                        Title = "Title 2",
                        Description = "Description 2",
                        Amount = 245,
                        Date = DateTime.Now.AddDays(-1)
                    },
                    new ExpenseDto
                    {
                        Title = "Title 3",
                        Description = "Description 3",
                        Amount = 245,
                        Date = DateTime.Now.AddDays(-1)
                    },
                    new ExpenseDto
                    {
                        Title = "Title 4",
                        Description = "Description 4",
                        Amount = 245,
                        Date = DateTime.Now.AddDays(-1)
                    },
                    new ExpenseDto
                    {
                        Title = "Title 5",
                        Description = "Description 5",
                        Amount = 245,
                        Date = DateTime.Now.AddDays(-1)
                    },
                    new ExpenseDto
                    {
                        Title = "Title 6",
                        Description = "Description 6",
                        Amount = 245,
                        Date = DateTime.Now.AddDays(-1)
                    }
                })*/
            };
        }

        public ObservableCollection<ExpenseItemViewModel> Expenses
        {
            get => _expenses;
            set => SetProperty(ref _expenses, value);
        }
	}
}
