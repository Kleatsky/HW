using BenchmarkDotNet.Running;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SumBenchmark>();

            Console.WriteLine("\nProgram complite.");
        }
    }
}
