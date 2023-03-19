using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MisGastos.Prism.ItemViewModels
{
	public class ExpenseItemViewModel : List<ExpenseDto>
	{
		public string Date { get; set; }

		public ExpenseItemViewModel(string date , List<ExpenseDto> expenses) : base(expenses)
		{
			Date = date;
		}
	}
}

