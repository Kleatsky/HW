using static ConsoleApp.FileSearcher;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            var strings = new List<string> { "Word1", "Hellp", "porgramm" };
            Console.WriteLine($"Longest string: {strings.GetMax<string>(s => s.Length)}");

            var products = new[]
            {
                new { Name = "Product1", Price = 10.0 },
                new { Name = "Product3", Price = 20.0 },
                new { Name = "Product2", Price = 120.0 }
            };
            var maxPrice = products.GetMax<object>(p => { dynamic d = p; return (float)d.Price; });
            Console.WriteLine($"Most expancive product {maxPrice}\n");




            // Task 2-5
            FileSearcher searcher = new FileSearcher();

            var searchingFile = "test3.txt";

            EventHandler<FileArgs> onFileFound = (sender, e) =>
            {
                Console.WriteLine($"File Found: {e.FileName}");

                if (e.FileName == searchingFile)
                {
                    Console.WriteLine($"Expected file Found. {e.FileName}");
                    e.Cancel = true;
                }
            };

            // Subscribe
            searcher.FileFound += onFileFound;

            searcher.Search("TestSearchRepo");

            // UnSubscribe
            searcher.FileFound -= onFileFound;



            Console.WriteLine("\nProgram Complete.");
        }
    }
}
