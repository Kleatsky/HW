using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new GameUIConsole();
            var settings = new BasicGameSettings(minNumber: 1, maxNumber: 10, maxGuessCount: 5);
            var nubmerGenerator = new BasicNumberGenerator();
            var gameInputServise = new BasicGameInputService(ui);

            var guessNubmerGame = new GuessNumberGame(gameSettings: settings,
                               numberGenerator: nubmerGenerator,
                                userInterface: ui,
                                inputService: gameInputServise);

            guessNubmerGame.Start();
        }
    }
}
