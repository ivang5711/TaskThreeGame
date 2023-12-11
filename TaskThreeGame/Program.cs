namespace TaskThreeGame
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            GameMoves moves = new(args);
            CryptographicKeys crypto = new();
            ConsoleUi consoleUi = new(moves);
            try
            {
                moves.CheckMoves();
            }
            catch (ArgumentException ex)
            {
                ConsoleUi.PrintArgumentsHelp();
#if DEBUG
                Console.WriteLine(ex);
#endif
                return;
            }
            catch (Exception ex)
            {
                ConsoleUi.PrintUnexpectedErrorMessage();
#if DEBUG
                Console.WriteLine(ex);
#endif
                return;
            }

            Gameplay gameplay = new(moves, consoleUi, crypto);
            consoleUi.GreetUser();
            try
            {
                gameplay.PlayGame();
            }
            catch (Exception ex)
            {
                ConsoleUi.PrintUnexpectedErrorMessage();
#if DEBUG
                Console.WriteLine(ex);
#endif
                return;
            }

            ConsoleUi.PrintGoodbuy();
        }
    }
}