using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SumBenchmark
    {
        private int[] _array;

        [Params(100_000, 1_000_000, 10_000_000)]
        public int Size;

        [GlobalSetup]
        public void Setup()
        {
            _array = new int[Size];
            Random rand = new Random();
            for (int i = 0; i < Size; i++)
                _array[i] = rand.Next(1, 100);
        }

        [Benchmark(Baseline = true)]
        public long SimpleSum()
        {
            return SimpleSumElemFromArray.Sum(_array);
        }

        [Benchmark]
        public long ParallelSum()
        {
            return ParralelThreads.SumParralelThreads(_array);
        }

        [Benchmark]
        public long LinqSum()
        {
            return SumElemFromArrayParralelLinq.Sum(_array);
        }
    }
}
