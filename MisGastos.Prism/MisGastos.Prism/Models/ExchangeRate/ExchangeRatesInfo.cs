using System;
namespace MisGastos.Prism.Models.ExchangeRate
{
    /// <summary>
    /// Exchange rates info.
    /// </summary>
	public class ExchangeRatesInfo
	{
        /// <summary>
        /// Timestamp
        /// </summary>
        public int Timestamp { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public double Rate { get; set; }
    }
}

