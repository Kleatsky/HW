using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Task 1 Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).

            string[] files = { Path.Combine("TestFiles","File1.txt"), 
                Path.Combine("TestFiles", "File2.txt"), Path.Combine("TestFiles", "File3.txt") };

            var sw1 = Stopwatch.StartNew(); // Stopwatch Start

            var tasks = new List<Task<long>>();
            foreach (string file in files)
            {
                Task<long> task = FileReader.CountSpacesAsync(file);
                tasks.Add(task);
            }

            long[] results = await Task.WhenAll(tasks);

            sw1.Stop(); // Stopwatch Stop

            Console.WriteLine("Task 1:\n");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{files[i]}: {results[i]} spaces");
            }
            Console.WriteLine($"Stopwatch: {sw1.ElapsedMilliseconds} ms\n");

            // Task 2 Написать функцию, принимающую в качестве аргумента путь к папке.
            // Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
            Console.WriteLine("\nTask 2:\n");
            string repositary = "TestFiles";

            sw1.Restart(); // Stopwatch Start
            var resultsTask2 = await RepositaryReader.CountSpacesAsync(repositary);
            sw1.Stop();

            foreach (var (file, count) in resultsTask2)
            {
                Console.WriteLine($"{file}: {count} spaces");
            }
            Console.WriteLine($"Stopwatch: {sw1.ElapsedMilliseconds} ms\n");

            // Task 3 замеренное время

            Console.WriteLine("\nProgram complite!");
        }
    }
}
