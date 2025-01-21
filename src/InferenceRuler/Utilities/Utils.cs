using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine.Utilities
{
    internal static class Utils
    {
        /// <summary>
        /// That function checks if an object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if the passed argument is not null, false if not</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool CheckNull(object? obj, string propertyName = "")
        {
            if (obj is null)
                throw new ArgumentNullException((string.IsNullOrEmpty(propertyName)) ? nameof(obj) : propertyName);
            return true;
        }
    }
}
