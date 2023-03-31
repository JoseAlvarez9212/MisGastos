using System;
using Refit;
using System.Threading;
using System.Threading.Tasks;
using MisGastos.Prism.Models.ExchangeRate;

namespace MisGastos.Prism.Services.API
{
    /// <summary>
    /// Contract for the Rest Service.
    /// </summary>
    public interface IRestService
	{
        /// <summary>
        /// Convert any amount from one currency to another
        /// </summary>
        /// <param name="apikey">API Key.</param>
        /// <param name="parameters">Parameters.</param>
        /// <returns></returns>
        [Get("/convert?to={parameters.to}&from={parameters.from}&amount={parameters.amount}")]
        Task<ExchangeRatesResponse> GetExchangeRatesAsync([Header("apikey")] string apikey, ExchangeRatesRequest parameters);
    }
}

