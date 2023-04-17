using System;
namespace MisGastos.Prism.Models.FirebaseDB
{
	public class ExpenseModel
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public decimal Amount { get; set; }

		public LocationExp Location { get; set; }

		public DateTime Date { get; set; }

		public string UrlImage { get; set; }

		public string Email { get; set; }

		public string CategoryId { get; set; }

		public string CategoryName { get; set; }

		public string TeamId { get; set; }
	}

	public class LocationExp
	{
		public string Latitude { get; set; }

		public string Longitude { get; set; }

		public string LocationName { get; set; }
	}
}

