using System.Runtime.CompilerServices;

namespace MisGastos.Prism.Services.Resources.ConfigApp
{
    /// <summary>
    /// Contract  environment service.
    /// </summary>
    public interface IEnvironmentService
	{
        #region Properties
        string ExchangeRatesApi { get; }
        string ExchangeRatesApiKey { get; }
        #endregion

        /// <summary>
        /// Get values for property in the dictionary
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>Value</returns>
        string GetValue([CallerMemberName] string propertyName = null);
    }
}

