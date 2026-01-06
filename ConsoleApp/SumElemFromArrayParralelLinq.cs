using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SumElemFromArrayParralelLinq
    {
        /// <summary>
        /// Plinq
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static long Sum(int[] arr)
        {
            return arr.AsParallel().Sum(e => (long)e);
        }
    }
}
