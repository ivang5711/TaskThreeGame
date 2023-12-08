namespace TaskThreeGame
{
    public class GameMoves
    {
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
                Console.Write($"Oops! Seems like you have entered wrong amount of arguments...\n\n" +
                    "You have entered ");
                PrintWithColor(Moves.Length.ToString());
                Console.Write(" arguments.\n\n");
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
                        for (int j = 0; j < Moves.Length; j++)
                        {
                            if (Moves[j] == Moves[k])
                            {
                                PrintWithColor($"{Moves[j]} ");
                            }
                            else
                            {
                                Console.Write(Moves[j] + " ");
                            }
                        }

                        Console.Write("\n\n");
                        PrintArgumentsHelp();
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void PrintArgumentsHelp()
        {
            Console.Write("Please provide odd number of unique arguments and\n" +
                    "make sure the overall amount of arguments equals or greater than 3.\n\n");
            PrintWithColor("CORRECT EXAMPLE:\n\n\t", ConsoleColor.Green);
            Console.Write("Rock Scissors Paper Lizard Spok\n\n");
            PrintWithColor("INCORRECT EXAMPLE:\n\n\t");
            Console.Write("Rock Scissors Paper Scissors\n\n");
        }

        private static void PrintWithColor(string input, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(input);
            Console.ForegroundColor = originalColor;
        }

        private void CreateHelpTable()
        {
            for (int i = 0; i < Moves.Length; i++)
            {
                for (int j = 0; j < Moves.Length; j++)
                {
                    if (j == i)
                    {
                        HelpTable[i, j] = "Draw";
                        j++;
                        int k = 0;
                        while (j < Moves.Length && k < Moves.Length / 2)
                        {
                            HelpTable[i, j] = "Win!";
                            j++;
                            k++;
                        }
                        while (j < Moves.Length)
                        {
                            HelpTable[i, j] = "Lose";
                            j++;
                        }
                    }
                }
                for (int j = Moves.Length - 1; j >= 0; j--)
                {
                    if (j == i)
                    {
                        j--;
                        int k = 0;
                        while (j >= 0 && k < Moves.Length / 2)
                        {
                            HelpTable[i, j] = "Lose";
                            j--;
                            k++;
                        }
                        while (j >= 0)
                        {
                            HelpTable[i, j] = "Win!";
                            j--;
                        }
                    }
                }
            }
        }
    }
}