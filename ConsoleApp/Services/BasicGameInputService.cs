using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class BasicGameInputService : IInputService
    {
        private IUserInterface _ui;

        public BasicGameInputService (IUserInterface ui)
        {
            _ui = ui;
        }

        public int GetIntInput(string message)
        {
            while (true)
            {
                _ui.Write(message);
                string userInput = _ui.Read();

                if (int.TryParse(userInput, out int value))
                {
                    return value;
                }
                else
                {
                    _ui.Write($"{userInput} is not a nubmer");
                }
            }
        }
    }
}
