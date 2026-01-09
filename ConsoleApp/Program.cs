namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string> { "Word1", "Hellp", "porgramm" };
            Console.WriteLine($"Longest string: {strings.GetMax<string>(s => s.Length)}");

            var products = new[]
            {
                new { Name = "Product1", Price = 10.0 },
                new { Name = "Product3", Price = 20.0 },
                new { Name = "Product2", Price = 120.0 }
            };
            var maxPrice = products.GetMax<object>(p => { dynamic d = p; return (float)d.Price; });
            Console.WriteLine($"Most expancive product {maxPrice}");



            Console.WriteLine("Program Complete.");
        }
    }
}
