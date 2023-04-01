using System.Threading.Tasks;
using MisGastos.Prism.Models.ExchangeRate;

namespace MisGastos.Prism.Services.API
{
    /// <summary>
    /// Contract ExchangeRatesServices.
    /// </summary>
	public interface IExchangeRatesServices
	{
        /// <summary>
        /// Example get exchange rates async by HttpClient.
        /// </summary>
        /// <param name="exchangeRatesRequest"></param>
        /// <returns>Exchange rates response.</returns>
        Task<ExchangeRatesResponse> GetExchangeRatesHttpClientAsync(ExchangeRatesRequest exchangeRatesRequest);

        /// <summary>
        /// Get exchange rates async by Refit.
        /// </summary>
        /// <param name="exchangeRatesRequest">Exchange rates request.</param>
        /// <returns>Exchange rates response.</returns>
        Task<ExchangeRatesResponse> GetExchangeRatesAsync(ExchangeRatesRequest exchangeRatesRequest);
    }
}

