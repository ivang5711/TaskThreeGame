﻿using Spectre.Console;

namespace TaskThreeGame
{
    public class GameMoves
    {
        private const string draw = "Draw";
        private const string win = "Win";
        private const string lose = "Lose";

        public string[,] HelpTable { get; set; }
        public string[] Moves { get; set; }

        public GameMoves(string[] moves)
        {
            Moves = moves;
            HelpTable = new string[Moves.Length, Moves.Length];
            CreateHelpTable();
        }

        public void CheckMoves()
        {
            if (!CheckMovesAmountCorrect() || !CheckAllMovesUnique())
            {
                PrintArgumentsHelp();
                throw new ArgumentException("Command line arguments " +
                    "provided are not correct.");
            }
        }

        private void PrintArgumentsHelp()
        {
            ConsoleUi.PrintArgumentsRequirements();
            ConsoleUi.PrintExample();
        }

        private void CreateHelpTable()
        {
            for (int i = 0; i < Moves.Length; i++)
            {
                PopulateValuesToRight(i);
                PopulateValuesToLeft(i);
            }
        }

        private void PopulateValuesToRight(int i)
        {
            for (int j = 0; j < Moves.Length; j++)
            {
                if (j == i)
                {
                    PopulateRowToRight(i, j);
                }
            }
        }

        private void PopulateRowToRight(int i, int j)
        {
            HelpTable[i, j++] = draw;
            j = PopulateWinToRight(i, j);
            PopulateLoseToRight(i, j);
        }

        private int PopulateWinToRight(int i, int j)
        {
            for (int k = 0; j < Moves.Length && k < Moves.Length / 2; k++)
            {
                HelpTable[i, j++] = win;
            }

            return j;
        }

        private void PopulateLoseToRight(int i, int j)
        {
            while (j < Moves.Length)
            {
                HelpTable[i, j++] = lose;
            }
        }

        private void PopulateValuesToLeft(int i)
        {
            for (int j = Moves.Length - 1; j >= 0; j--)
            {
                if (j == i)
                {
                    PopulateRowToLeft(i, j);
                }
            }
        }

        private void PopulateRowToLeft(int i, int j)
        {
            j--;
            j = PopulateLoseToLeft(i, j);
            PopulateWinToLeft(i, j);
        }

        private int PopulateLoseToLeft(int i, int j)
        {
            for (int k = 0; j >= 0 && k < Moves.Length / 2; k++)
            {
                HelpTable[i, j--] = lose;
            }

            return j;
        }

        private void PopulateWinToLeft(int i, int j)
        {
            while (j >= 0)
            {
                HelpTable[i, j--] = win;
            }
        }

        private bool CheckMovesAmountCorrect()
        {
            if (Moves.Length < 3 || Moves.Length % 2 == 0)
            {
                ConsoleUi.PrintArgumentsAmountErrorMessage(Moves.Length);
                return false;
            }

            return true;
        }

        private bool CheckAllMovesUnique()
        {
            bool isUnique = Moves.Select(x => x).Distinct().Count()
                == Moves.Select(x => x).Count();
            PrintErrorMessageIfMovesNotUnique(isUnique);
            return isUnique;
        }

        private void PrintErrorMessageIfMovesNotUnique(bool isUnique)
        {
            if (!isUnique)
            {
                ConsoleUi.PrintNonUniqueErrorMessage();
                PrintMovesWithColor();
            }
        }

        private void PrintMovesWithColor()
        {
            List<string> distinctMoves = new();
            GetDistinctMovesWithCount(ref distinctMoves);
            ConsoleUi.PrintMovesRowWithColor(distinctMoves, Moves);
        }

        private void GetDistinctMovesWithCount(ref List<string> distinctMoves)
        {
            foreach (var group in Moves.GroupBy(v => v))
            {
                if (group.Count() > 1)
                {
                    distinctMoves.Add(group.Key);
                }
            }
        }
    }
}