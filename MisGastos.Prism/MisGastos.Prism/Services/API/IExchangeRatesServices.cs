using System;
using MisGastos.Prism.Models.ExchangeRate;
using System.Threading.Tasks;

namespace MisGastos.Prism.Services.API
{
	public interface IExchangeRatesServices
	{
        //Task<ExchangeRatesResponse> GetExchangeRatesAsync();

        Task<ExchangeRatesResponse> GetExchangeRatesAsync(ExchangeRatesRequest exchangeRatesRequest);

    }
}

