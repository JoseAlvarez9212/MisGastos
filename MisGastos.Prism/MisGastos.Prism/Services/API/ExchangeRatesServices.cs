using System;
using System.Net.Http;
using System.Threading.Tasks;
using MisGastos.Prism.Models.ExchangeRate;
using Newtonsoft.Json;

namespace MisGastos.Prism.Services.API
{
	public class ExchangeRatesServices : IExchangeRatesServices
    {
        //public async Task<ExchangeRatesResponse> GetExchangeRatesAsync()
        //{
        //    try
        //    {
        //        var client = new HttpClient();
        //        client.DefaultRequestHeaders.Add("apikey", "gG9OSqA1CeuJuVsmqCjgxlfzlPAgT5HX");
        //        client.BaseAddress = new Uri("https://api.apilayer.com/exchangerates_data/");
        //        var url = string.Format(
        //            "convert?to={0}&from={1}&amount={2}"
        //            , "MXN"
        //            , "USD"
        //            , "1");
        //        var response = await client.GetAsync(url);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new ExchangeRatesResponse
        //            {
        //                Success = false,
        //            };
        //        }

        //        var result = await response.Content.ReadAsStringAsync();
        //        var model = JsonConvert.DeserializeObject<ExchangeRatesResponse>(result);
        //        return model;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ExchangeRatesResponse { Success = false };
        //    }
        //}



        #region Refit

        public async Task<ExchangeRatesResponse> GetExchangeRatesAsync(ExchangeRatesRequest exchangeRatesRequest)
        {
            try
            {
                var urlBase = "https://api.apilayer.com/exchangerates_data/";
                var refitService = Refit.RestService.For<IRestService>(urlBase);
                var response = await refitService.GetExchangeRatesAsync("gG9OSqA1CeuJuVsmqCjgxlfzlPAgT5HX",
                    exchangeRatesRequest);
                if (response.Success)
                {
                    return response;
                }
                return new ExchangeRatesResponse(false);
            }
            catch (Exception ex)
            {
                return new ExchangeRatesResponse(false);
            }
        }
        #endregion

    }
}

