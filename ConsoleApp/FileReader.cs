using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FileReader
    {
        public static async Task<long> CountSpacesAsync(string filePath)
        {
            if (String.IsNullOrEmpty(filePath)) throw new ArgumentNullException("Empty filePath");
            if (!File.Exists(filePath)) throw new ArgumentNullException("File not found");

            long count = 0;

            await foreach (var line in File.ReadLinesAsync(filePath))
            {
                count += line.Count(x => x == ' ');
            }

            return count;
        }
    }
}
