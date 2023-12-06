namespace TaskThreeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMoves moves = new(args);
            moves.CheckMoves();
        }
    }
}
