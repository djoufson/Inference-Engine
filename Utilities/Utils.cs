using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceRuler.Utilities
{
    internal static class Utils
    {
        public static bool CheckNull(object? obj)
        {
            if (obj is null)
                throw new NullReferenceException();
            return true;
        }
    }
}
