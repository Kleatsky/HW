using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class BasicGameSettings : IGameSettings
    {
        public int MaxNumber { get; set; }
        public int MinNumber { get; set; }
        public int MaxGuessCount { get; set; }

        public BasicGameSettings(int maxNumber, int minNumber, int maxGuessCount)
        {
            if (maxGuessCount < 0) throw new ArgumentException("MaxGuessCount below zero.");
            if (maxNumber < minNumber) throw new ArgumentException("MaxNumber lower then minNumber.");

            MaxGuessCount = maxGuessCount;
            MinNumber = minNumber;
            MaxNumber = maxNumber;
        }
    }
}
