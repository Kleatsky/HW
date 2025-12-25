using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RepositaryReader
    {
        public static async Task<(string fileName, long spaceCount)[]> CountSpacesAsync(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath)) throw new ArgumentException("Argument is empty");
            if (!Directory.Exists(folderPath)) throw new ArgumentException("Folder's not found");
            string[] files = Directory.GetFiles(folderPath);
            var tasks = new List<Task<long>>(files.Length);

            foreach (string file in files)
            {
                tasks.Add(FileReader.CountSpacesAsync(file));
            }

            long[] results = await Task.WhenAll(tasks);

            var tuples = new (string file, long count)[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                tuples[i] = (files[i], results[i]);
            }

            return tuples;
        }
    }
}
