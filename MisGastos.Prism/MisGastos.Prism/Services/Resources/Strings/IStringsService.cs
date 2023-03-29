using System;
using System.Runtime.CompilerServices;

namespace MisGastos.Prism.Services.Resources.Strings
{
    /// <summary>
    /// Contract Strings Service.
    /// </summary>
	public interface IStringsService
	{
        #region Common
        string IsEmailInvalidText { get; }
        string AppNameText { get; }
        string ErrorEntryText { get; }
        string AceptButton { get; }
        string ErrorTitleText { get; }
        string ErrorNetworkAccessText { get; }
        #endregion

        #region Login
        string LoginTitlePage { get; }
        string LoginEmailEntryText { get; }
        string LoginPasswordEntryText { get; }
        string LoginEnterButton { get; }
        string LoginRegisterButton { get; }
        #endregion

        #region Register
        string RegisterTitlePage { get; }
        string RegisterNameEntryText { get; }
        string RegisterLastNameEntryText { get; }
        string RegisterEmailEntryText { get; }
        string RegisterPasswordEntryText { get; }
        string RegisterEnterButton { get; }
        string RegisterBackButton { get; }
        #endregion

        /// <summary>
        /// Get values for property in the dictionary
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>Value</returns>
        string GetValue([CallerMemberName] string propertyName = null);
    }
}

