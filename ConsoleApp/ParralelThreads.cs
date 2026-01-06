using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp
{
    public class ParralelThreads
    {
        public static long SumParralelThreads(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            int threadCount = Environment.ProcessorCount;
            long sum = 0;
            var lockObj = new object();
            var threads = new List<Thread>();

            int length = arr.Length;
            int partSize = length / threadCount;
            int remainer = length % threadCount; // If array is not divisible without remain

            for (int i = 0; i < threadCount; i++)
            {
                int start = i * partSize + Math.Min(i, remainer);
                int end = start + partSize + (i < remainer ? 1 : 0);

                threads.Add(new Thread(() =>
                {
                    long threadSum = 0;
                    for (int j = start; j < end; j++)
                        threadSum += arr[j];

                    Interlocked.Add(ref sum, threadSum);
                }));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return sum;
        }
    }
}
