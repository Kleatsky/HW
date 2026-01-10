using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class GuessNumberGame : IGame
    {
        private readonly IGameSettings _gameSettings;
        private readonly INumberGenerator _numberGenerator;
        private readonly IUserInterface _ui;
        private readonly IInputService _inputService;

        public GuessNumberGame(IGameSettings gameSettings,
                               INumberGenerator numberGenerator,
                               IUserInterface userInterface,
                               IInputService inputService)
        {
            _gameSettings = gameSettings;
            _numberGenerator = numberGenerator;
            _ui = userInterface;
            _inputService = inputService;
        }
        public void Start()
        {
            int targetNumber = _numberGenerator.Generate(_gameSettings.MinNumber, _gameSettings.MaxNumber);
            int attemptLeft = _gameSettings.MaxGuessCount;

            _ui.Write($"Guess the Nubmer from {_gameSettings.MinNumber} to {_gameSettings.MaxNumber}.");
            _ui.Write($"You have {attemptLeft} attempts left.");

            while (attemptLeft > 0)
            {
                attemptLeft--;
                
                int userNubmer = _inputService.GetIntInput($"Input your number:");

                if (userNubmer == targetNumber)
                {
                    _ui.Write("Game Success.");
                    return;
                }
                else if (userNubmer < targetNumber)
                {
                    _ui.Write("The nubmer is higher.");
                }
                else
                {
                    _ui.Write("The number is lower.");
                }

                _ui.Write($"{attemptLeft} attempt left.");
            }

            _ui.Write($"You fail, guess number was {targetNumber}");
        }
    }
}
