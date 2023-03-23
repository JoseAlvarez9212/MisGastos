using System;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace MisGastos.Prism.Helpers
{
    /// <summary>
    /// String Extensions.
    /// </summary>
	public static class StringExtensions
	{
        private const string DIRECTORY_ASSETS = "Resources";

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

