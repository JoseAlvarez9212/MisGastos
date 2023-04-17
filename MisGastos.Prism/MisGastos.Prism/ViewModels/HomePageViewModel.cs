using MisGastos.Prism.ItemViewModels;
using MisGastos.Prism.Models.FirebaseDB;
using MisGastos.Prism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MisGastos.Prism.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private DelegateCommand _addExpenseCommand;
        ObservableCollection<ExpenseItemViewModel> _my_expenses;
        ObservableCollection<GroupExpenseItemViewModel> _group_expenses;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Mis Gastos";

            //TODO: AGREGAR DATOS DE SERVICIO
            MyExpenses = new ObservableCollection<ExpenseItemViewModel>
            {
                new ExpenseItemViewModel("Lunes 20 de febrero de 2023", new List<ExpenseDto>
                {
                    new ExpenseDto
                    {
                        Title = "Alimentos",
                        Description = "Pizza Dominos",
                        Amount = 245,
                        Date = DateTime.Now.AddHours(-1)
                    },
                    new ExpenseDto
                    {
                        Title = "Turismo",
                        Description = "Entrada castillo de chapultepec",
                        Amount = 100,
                        Date = DateTime.Now.AddHours(-2)
                    },
                    new ExpenseDto
                    {
                        Title = "Estacionamiento",
                        Description = "Ecologico chapultepec",
                        Amount = 60,
                        Date = DateTime.Now.AddHours(-3)
                    },
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

            GroupExpenses = new ObservableCollection<GroupExpenseItemViewModel>
            {
                new GroupExpenseItemViewModel
                {
                    Name = "Sindy",
                    LastName = "Martínez",
                    Amount = 385.87m
                }
            };
        }

        public DelegateCommand AddExpenseCommand =>
            _addExpenseCommand ?? (_addExpenseCommand =
            new DelegateCommand(AddTExpense));

        public ObservableCollection<ExpenseItemViewModel> MyExpenses
        {
            get => _my_expenses;
            set => SetProperty(ref _my_expenses, value);
        }

        public ObservableCollection<GroupExpenseItemViewModel> GroupExpenses
        {
            get => _group_expenses;
            set => SetProperty(ref _group_expenses, value);
        }

        private async void AddTExpense()
        {
            //var parameters = new NavigationParameters();
            //parameters.Add(PARAM_TEAM, teamModel);
            await _navigationService.NavigateAsync($"{nameof(AddExpensePage)}");
        }
    }
}
