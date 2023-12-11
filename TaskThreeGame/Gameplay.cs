﻿using Spectre.Console;

namespace TaskThreeGame
{
    public class Gameplay
    {
        private readonly GameMoves moves;
        private readonly ConsoleUi consoleUi;
        private readonly CryptographicKeys crypto;

        public Gameplay(GameMoves moves,
            ConsoleUi consoleUi, CryptographicKeys crypto)
        {
            this.moves = moves;
            this.consoleUi = consoleUi;
            this.crypto = crypto;
        }

        public void PlayGame()
        {
            string? choice = string.Empty;
            GetUserChoice(ref choice);
            ConsoleUi.PrintChoice(choice);
            ExitGame(CheckExitSequence(choice));
            consoleUi.PrintGameOutcome(choice, crypto);
        }

        private void GetUserChoice(ref string choice)
        {
            while (!CheckInput(choice!))
            {
                ProvideChoiceToUser(ref choice);
                CheckHelpChoice(choice);
            }
        }

        private bool CheckInput(string choice)
        {
            return int.TryParse(choice, out int menuIndex)
                && menuIndex >= 0
                && menuIndex <= moves.Moves.Length;
        }

        private void ProvideChoiceToUser(ref string choice)
        {
            ConsoleUi.ClearConsoleScreen();
            ConsoleUi.PrintHmac("9ED68097B2D5D9A968E85BD7094C75D00F96680DC43CDD6918168A8F50DE8507");
            consoleUi.PrintMenu();
            ConsoleUi.CollectUserInput(ref choice);
        }

        private void CheckHelpChoice(string choice)
        {
            if (choice == "?")
            {
                ConsoleUi.PrintChoice(choice);
                consoleUi.ShowHelpTableBlock();
            }
        }

        private static void ExitGame(bool exit)
        {
            if (exit)
            {
                Environment.Exit(0);
            }
        }

        private static bool CheckExitSequence(string? choice)
        {
            return int.TryParse(choice, out int r) && r == 0;
        }
    }
}