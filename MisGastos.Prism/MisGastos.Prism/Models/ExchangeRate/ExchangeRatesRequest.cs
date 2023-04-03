namespace MisGastos.Prism.Models.ExchangeRate
{
    /// <summary>
    /// Convert from one currency to another.
    /// </summary>
	public class ExchangeRatesRequest
	{
        /// <summary>
        /// The three-letter currency code of the currency you would like to convert to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The three-letter currency code of the currency you would like to convert from.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The amount to be converted.
        /// </summary>
        public decimal Amount { get; set; }
	}
}

