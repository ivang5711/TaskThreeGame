namespace TaskThreeGame
{
    public class GameMoves
    {
        private readonly string[] moves;
        public GameMoves(string[] moves)
        {
            this.moves = moves;
        }
        public void CheckMoves()
        {
            if (moves.Length < 3 || moves.Length % 2 == 0)
            {
                Console.Write($"Oops! Seems like you have entered wrong amount of arguments...\n\n" +
                    "You have entered ");
                PrintWithColor(moves.Length.ToString());
                Console.Write(" arguments.\n\n");
                PrintArgumentsHelp();
                Environment.Exit(0);
            }
            else
            {
                string[] temp = (string[])moves.Clone();
                Array.Sort(temp, StringComparer.CurrentCulture);
                for (int i = 1; i < temp.Length; i++)
                {
                    if (temp[i - 1] == temp[i])
                    {
                        var k = Array.IndexOf(moves, temp[i]);
                        Console.WriteLine($"Oops! Argument number {k + 1} is not unique:\n");
                        for (int j = 0; j < moves.Length; j++)
                        {
                            if (moves[j] == moves[k])
                            {
                                PrintWithColor($"{moves[j]} ");
                            }
                            else
                            {
                                Console.Write(moves[j] + " ");
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
    }
}
