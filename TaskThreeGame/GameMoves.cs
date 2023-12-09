using Spectre.Console;

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

        private void PrintArgumentsAmountErrorMessage()
        {
            AnsiConsole.Markup($"Oops! Seems like you have entered wrong" +
                    $" amount of arguments...\n\nYou have entered " +
                    $"[underline red]{Moves.Length}[/] arguments.\n\n");
        }

        private static void PrintArgumentsHelp()
        {
            AnsiConsole.Markup("Please provide odd number of unique " +
                "arguments and\n" +
                "make sure the overall amount of arguments equals or " +
                "greater than 3.\n\n");
            PrintExample();
        }

        private static void PrintExample()
        {
            AnsiConsole.Markup(
                "[underline green]CORRECT EXAMPLE:[/]\n\n\t" +
                "Rock Scissors Paper Lizard Spok\n\n" +
                "[underline red]INCORRECT EXAMPLE:[/]\n\n\t" +
                "Rock Scissors Paper Scissors\n\n");
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

        public void CheckMoves()
        {
            if (!CheckMovesAmountCorrect() || !CheckAllMovesUnique())
            {
                PrintArgumentsHelp();
                throw new ArgumentException("Command line arguments provided are not correct.");
            }
        }

        private bool CheckMovesAmountCorrect()
        {
            if (Moves.Length < 3 || Moves.Length % 2 == 0)
            {
                PrintArgumentsAmountErrorMessage();
                return false;
            }

            return true;
        }

        private bool CheckAllMovesUnique()
        {
            bool isUnique = Moves.Select(x => x).Distinct().Count() == Moves.Select(x => x).Count();
            PrintErrorMessageIfMovesNotUnique(isUnique);
            return isUnique;
        }

        private void PrintErrorMessageIfMovesNotUnique(bool isUnique)
        {
            if (!isUnique)
            {
                Console.WriteLine($"Oops! Arguments marked with red are not unique:\n");
                PrintMovesWithColor();
            }
        }

        private void PrintMovesWithColor()
        {
            List<string> distinctMoves = new();
            GetDistinctMovesWithCount(ref distinctMoves);
            foreach (string item in Moves)
            {
                PrintSingleMoveWithColor(distinctMoves, item);
            }

            Console.WriteLine("\n\n");
        }

        private void PrintSingleMoveWithColor(List<string> distinctMoves, string item)
        {
            AnsiConsole.Markup(
                    distinctMoves.Contains(item) ?
                    $"[underline red]{item}[/] " :
                    $"[green]{item}[/] "
                    );
        }

        private void GetDistinctMovesWithCount(ref List<string> distinctMoves)
        {
            var groups = Moves.GroupBy(v => v);
            foreach (var group in groups)
            {
                if (group.Count() > 1)
                {
                    distinctMoves.Add(group.Key);
                }
            }
        }
    }
}