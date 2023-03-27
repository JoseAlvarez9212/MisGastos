using System;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MisGastos.Prism.Helpers
{
    /// <summary>
    /// String Extensions.
    /// </summary>
	public static class StringExtensions
	{
        private const string DIRECTORY_ASSETS = "Resources";
        private const string REGEX_EMAIL = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";


        /// <summary>
        /// Email Validation.
        /// </summary>
        /// <param name="email">Email to validate.</param>
        /// <returns>True if email is valid</returns>
        public static bool IsValidEmail(this string email)
        {
            try
            {
                return Regex.IsMatch(email, REGEX_EMAIL, RegexOptions.IgnoreCase, new TimeSpan(0, 0, 0, 0, 100));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Convert file from to object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="name">File name.</param>
        /// <returns>T</returns>
        public static T FileTo<T>(this string name)
        {
            T result;
            var assembly = typeof(StringExtensions).GetTypeInfo().Assembly;
            var fullName = $"{assembly.GetName().Name}.{DIRECTORY_ASSETS}.{name}.json";
            var stream = assembly.GetManifestResourceStream(fullName);
            using (var reader = new StreamReader(stream))
            {
                result = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
            return result;
        }
    }
}

