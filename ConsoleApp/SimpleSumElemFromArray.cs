using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SimpleSumElemFromArray
    {
        public static long Sum(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            long sum = 0;
            foreach (long item in arr)
            {
                sum += item;
            }
            return sum;
        }
    }
}
