using System;
namespace MisGastos.Prism.Models.Dtos
{
	public class ExpenseDto
	{
        public string url_imagen { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string location { get; set; }

        public decimal amount { get; set; }

        public DateTime expenseDate { get; set; }

        public string id_group { get; set; }
	}
}

