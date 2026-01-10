using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class BasicNumberGenerator : INumberGenerator
    {
        private Random _random = new Random();
        public int Generate(int min, int max) => _random.Next(min, max);
    }
}
