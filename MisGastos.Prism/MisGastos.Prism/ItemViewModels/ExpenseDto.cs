using System;
namespace MisGastos.Prism.ItemViewModels
{
	public class ExpenseDto
	{
        public string ImgName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public ExpenseDto()
		{
		}
	}
}

