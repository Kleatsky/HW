using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces
{
    public interface IGameSettings
    {
        public int MaxNumber { get; set; }
        public int MinNumber { get; set; }
        public int MaxGuessCount { get; set; }
    }
}
