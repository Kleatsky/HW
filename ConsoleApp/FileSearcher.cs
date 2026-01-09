using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> FileFound;

        public class FileArgs : EventArgs
        {
            public string FileName { get; set; }
            public bool Cancel { get; set; }

            public FileArgs(string fileName)
            {
                FileName = fileName;
            }
        }

        public bool Search(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Repositary does't found: {directory}");
                return false;
            }

            string[] files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                if (OnFileFound(Path.GetFileName(file)))
                {
                    Console.WriteLine("Expected file found.");
                    return true;
                }
            }

            string[] innerRepositaries = Directory.GetDirectories(directory);
            foreach (string repo in innerRepositaries)
            {
                if (Search(repo))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual bool OnFileFound(string fileName)
        {
            var args = new FileArgs(fileName);
            FileFound?.Invoke(this, args);
            return args.Cancel;
        }
    }
}
