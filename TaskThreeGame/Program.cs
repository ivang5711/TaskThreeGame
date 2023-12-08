﻿using Spectre.Console;

namespace TaskThreeGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameMoves moves = new(args);
            ConsoleUi consoleUi = new(moves);
            moves.CheckMoves();
            Console.WriteLine();
            consoleUi.PrintHelpTable();

            Console.WriteLine();

            AnsiConsole.Markup("[underline red]Hello[/] World!");
        }
    }
}