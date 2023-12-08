using Spectre.Console;

namespace TaskThreeGame
{
    public class ConsoleUi
    {
        private readonly GameMoves gameMoves;

        public ConsoleUi(GameMoves gameMoves)
        {
            this.gameMoves = gameMoves;
        }

        public void PrintHelpTable()
        {
            Table table = new();
            table.AddColumn(new TableColumn($"[khaki1]PC[/]\\[lightsteelblue]User[/]"));
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                table.AddColumn(new TableColumn($"[lightsteelblue]{gameMoves.Moves[i]}[/]"));
            }

            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                table.AddRow($"[khaki1]{gameMoves.Moves[i]}[/]");
            }

            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                for (int j = 0; j < gameMoves.Moves.Length; j++)
                {
                    table.UpdateCell(i, j + 1, gameMoves.HelpTable[i, j]);
                }
            }

            table.Title(" Help Table ",
                new Style(Color.White, Color.MediumPurple4, Decoration.None, " "));
            table.Border(TableBorder.Square).BorderColor(Color.Grey27).Centered();
            table.ShowRowSeparators();
            AnsiConsole.Write(table);
        }
    }
}