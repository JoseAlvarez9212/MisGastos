using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MisGastos.Prism.Enums;
using MisGastos.Prism.Helpers;

namespace MisGastos.Prism.Services.Resources.ConfigApp
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly Dictionary<string, Dictionary<string, string>> dictionary;
        private const string FILE_NAME = "environments_app";
        private readonly EnvironmentsType Environment = AppInit.ENVIRONMENT;

        public string ExchangeRatesApi => GetValue();

        public string ExchangeRatesApiKey => GetValue();

        public EnvironmentService()
        {
            dictionary = FILE_NAME.FileTo<Dictionary
                <string, Dictionary<string, string>>>();
        }

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

