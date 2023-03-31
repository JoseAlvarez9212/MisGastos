using System;
using MisGastos.Prism.Models.ExchangeRate;
using Newtonsoft.Json;

namespace MisGastos.Prism.Models.ExchangeRate
{
    /// <summary>
    /// Exchange rates response.
    /// </summary>
	public class ExchangeRatesResponse
	{
        /// <summary>
        /// Indicates if the response is success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Conversion query.
        /// </summary>
        public ExchangeRatesRequest Query { get; set; }

        /// <summary>
        /// Conversion information.
        /// </summary>
        public ExchangeRatesInfo Info { get; set; }

        /// <summary>
        /// Conversion date.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Conversion result.
        /// </summary>
        public decimal Result { get; set; }

        /// <summary>
        /// Constructor when error occurs 
        /// </summary>
        /// <param name="success">Indicates if the response is success</param>
        public ExchangeRatesResponse(bool success)
        {
            Success = success;
        }

        public ExchangeRatesResponse()
        {

        }
	}
}

