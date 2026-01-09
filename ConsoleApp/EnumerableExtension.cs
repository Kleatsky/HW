using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class EnumerableExtension
    {
        public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) return null!;

            T MaxElement = null!;
            float MaxValue = float.MinValue;

            foreach (var item in collection)
            {
                T? element = item as T;

                if (element != null)
                {
                    float currentValue = convertToNumber(element);

                    if (currentValue > MaxValue)
                    {
                        MaxValue = currentValue;
                        MaxElement = element;
                    }
                }
            }

            return MaxElement!;
        }
    }
}
