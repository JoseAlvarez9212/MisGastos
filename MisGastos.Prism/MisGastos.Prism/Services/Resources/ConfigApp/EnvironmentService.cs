using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MisGastos.Prism.Enums;
using MisGastos.Prism.Helpers;

namespace MisGastos.Prism.Services.Resources.ConfigApp
{
    /// <summary>
    /// Implementation environment service.
    /// </summary>
    public class EnvironmentService : IEnvironmentService
    {
        private const string FILE_NAME = "environments_app";
        private readonly EnvironmentsType Environment = AppInit.ENVIRONMENT;
        private readonly Dictionary<string, Dictionary<string, string>> dictionary;

        #region Properties
        public string ExchangeRatesApi => GetValue();

        public string ExchangeRatesApiKey => GetValue();

        public string FirebaseProjectID => GetValue();
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public EnvironmentService()
        {
            dictionary = FILE_NAME.FileTo<Dictionary
                <string, Dictionary<string, string>>>();
        }

        /// <summary>
        /// Get values for property in the dictionary
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>Value</returns>
        public string GetValue([CallerMemberName] string propertyName = null)
        {
            var environment = $"{Environment}".ToLowerSafely();
            if (dictionary.TryGetValue(environment, out var dic) &&
                    dic.TryGetValue(propertyName, out var stringResource))
            {
                return stringResource;
            }
            return string.Empty;
        }

    }
}

