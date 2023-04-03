using System;
using System.Net.Http;
using System.Threading.Tasks;
using MisGastos.Prism.Models.ExchangeRate;
using MisGastos.Prism.Services.Resources.ConfigApp;
using Newtonsoft.Json;

namespace MisGastos.Prism.Services.API
{
    /// <summary>
    /// Exchange rates services
    /// </summary>
	public class ExchangeRatesServices : IExchangeRatesServices
    {
        private IEnvironmentService _environmentService;

        /// <summary>
        /// Constructor ExchangeRatesServices
        /// </summary>
        /// <param name="environmentService">IEnvironmentService</param>
        public ExchangeRatesServices(IEnvironmentService environmentService)
        {
            _environmentService = environmentService;
        }

        #region HttpClient
        /// <summary>
        /// Example get exchange rates async by HttpClient.
        /// </summary>
        /// <param name="exchangeRatesRequest"></param>
        /// <returns>Exchange rates response.</returns>
        public async Task<ExchangeRatesResponse> GetExchangeRatesHttpClientAsync(ExchangeRatesRequest exchangeRatesRequest)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("apikey", _environmentService.ExchangeRatesApiKey);
                client.BaseAddress = new Uri(_environmentService.ExchangeRatesApi);
                var url = string.Format(
                    "convert?to={0}&from={1}&amount={2}",
                    exchangeRatesRequest.To,
                    exchangeRatesRequest.From,
                    exchangeRatesRequest.Amount);
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new ExchangeRatesResponse(false);

                var result = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ExchangeRatesResponse>(result);
                return model;
            }
            catch (Exception)
            {
                return new ExchangeRatesResponse(false);
            }
        }
        #endregion

        #region Refit
        /// <summary>
        /// Get exchange rates async by Refit.
        /// </summary>
        /// <param name="exchangeRatesRequest">Exchange rates request.</param>
        /// <returns>Exchange rates response.</returns>
        public async Task<ExchangeRatesResponse> GetExchangeRatesAsync(ExchangeRatesRequest exchangeRatesRequest)
        {
            try
            {
                var refitService = Refit.RestService.For<IRestService>(_environmentService.ExchangeRatesApi);
                var response = await refitService.GetExchangeRatesAsync(
                    _environmentService.ExchangeRatesApiKey,
                    exchangeRatesRequest);
                if (response.Success)
                {
                    return response;
                }
                return new ExchangeRatesResponse(false);
            }
            catch (Exception)
            {
                return new ExchangeRatesResponse(false);
            }
        }
        #endregion

    }
}

