using System;
using System.Runtime.CompilerServices;

namespace MisGastos.Prism.Services.Resources.Strings
{
    /// <summary>
    /// Contract Strings Service.
    /// </summary>
	public interface IStringsService
	{
        #region Login
        string LoginAppNameText { get; }
        string LoginEmailEntryText { get; }
        string LoginPasswordEntryText { get; }
        string LoginEnterButton { get; }
        string LoginRegisterButton { get; }
        #endregion

        /// <summary>
        /// Get values for property in the dictionary
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>Value</returns>
        string GetValue([CallerMemberName] string propertyName = null);
    }
}

