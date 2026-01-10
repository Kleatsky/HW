using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class GameUIConsole : IUserInterface
    {
        public string Read() => Console.ReadLine() ?? string.Empty;

        public void Write(string message) => Console.WriteLine(message);
    }
}
