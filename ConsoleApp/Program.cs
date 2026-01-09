using BenchmarkDotNet.Running;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 4 Write to Console our serialize CSV
            var f = F.Get();
            Console.WriteLine("Результат сериализации MyReflection:");
            Console.WriteLine(CSVHandler.SerializetoCSV(f));

            var summary = BenchmarkRunner.Run<CerializationBenchMark>();


            Console.WriteLine("\nProgram Complete.");
        }
    }
}
