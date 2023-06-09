﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using MisGastos.Prism.Helpers;
using Newtonsoft.Json;

namespace MisGastos.Prism.Services.Resources.Strings
{
    /// <summary>
    /// Implementation Strings Service.
    /// </summary>
	public class StringsService : IStringsService
	{
        private const string LANGUAGE_DEFAULT = "en";
        private const string FILE_NAME = "strings";
        private readonly Dictionary<string, Dictionary<string, string>> dictionary;

        #region Common
        public string IsEmailInvalidText => GetValue();
        public string AppNameText => GetValue();
        public string ErrorEntryText => GetValue();
        public string AceptButton => GetValue();
        public string ErrorTitleText => GetValue();
        public string ErrorNetworkAccessText => GetValue();
        #endregion

        #region Login
        public string LoginTitlePage => GetValue();
        public string LoginEmailEntryText => GetValue();
        public string LoginPasswordEntryText => GetValue();
        public string LoginEnterButton => GetValue();
        public string LoginRegisterButton => GetValue();
        #endregion

        #region Register
        public string RegisterTitlePage => GetValue();
        public string RegisterNameEntryText => GetValue();
        public string RegisterLastNameEntryText => GetValue();
        public string RegisterEmailEntryText => GetValue();
        public string RegisterPasswordEntryText => GetValue();
        public string RegisterEnterButton => GetValue();
        public string RegisterBackButton => GetValue();
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public StringsService()
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
            var twoLetterISOLanguageName = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var currentLanguage = dictionary.First().Value.ContainsKey(twoLetterISOLanguageName) ?
                twoLetterISOLanguageName :
                LANGUAGE_DEFAULT;
            if (dictionary.TryGetValue(propertyName, out var dic) &&
                dic.TryGetValue(currentLanguage, out var stringResource))
            {
                return stringResource;
            }
            return string.Empty;
        }
    }
}

