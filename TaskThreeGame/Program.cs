namespace TaskThreeGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameMoves moves = new(args);
            ConsoleUi consoleUi = new(moves);

            try
            {
                moves.CheckMoves();
            }
            catch (ArgumentException ex)
            {
#if DEBUG
                Console.WriteLine(ex);
#endif
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            consoleUi.PrintHelpTable();
        }
    }
}