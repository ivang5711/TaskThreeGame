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

        public void CheckMoves()
        {
            if (Moves.Length < 3 || Moves.Length % 2 == 0)
            {
                PrintArgumentsAmountErrorMessage();
                PrintArgumentsHelp();
                Environment.Exit(0);
            }
            else
            {
                string[] temp = (string[])Moves.Clone();
                Array.Sort(temp, StringComparer.CurrentCulture);
                for (int i = 1; i < temp.Length; i++)
                {
                    if (temp[i - 1] == temp[i])
                    {
                        var k = Array.IndexOf(Moves, temp[i]);
                        Console.WriteLine($"Oops! Argument number {k + 1} is not unique:\n");
                        PrintMovesWithNonUniqueMembers(k);
                        Console.Write("\n\n");
                        PrintArgumentsHelp();
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void PrintMovesWithNonUniqueMembers(int k)
        {
            for (int j = 0; j < Moves.Length; j++)
            {
                AnsiConsole.Markup(
                    (Moves[j] == Moves[k]) ? $"[red]{Moves[j]}[/] " : $"{Moves[j]} "
                    );
            }
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
    }
}