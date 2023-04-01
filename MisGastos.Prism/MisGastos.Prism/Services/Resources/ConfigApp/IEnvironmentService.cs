using System;
using System.Runtime.CompilerServices;
using MisGastos.Prism.Enums;

namespace MisGastos.Prism.Services.Resources.ConfigApp
{
	public interface IEnvironmentService
	{
        //EnvironmentsType Environment { get; }
        //bool IsInitialized { get; }

        #region Properties
        string ExchangeRatesApi { get; }
        string ExchangeRatesApiKey { get; }
        #endregion

        //void Init(EnvironmentsType environment);

        string GetValue([CallerMemberName] string propertyName = null);
    }
}

