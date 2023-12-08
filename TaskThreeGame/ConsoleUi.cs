using Spectre.Console;

namespace TaskThreeGame
{
    public class ConsoleUi
    {
        private readonly GameMoves gameMoves;

        private readonly Table table = new();

        public ConsoleUi(GameMoves gameMoves)
        {
            this.gameMoves = gameMoves;
            CreateHelpTable();
        }

        public void PrintHelpTable()
        {
            AnsiConsole.Write(table);
        }

        private void CreateHelpTable()
        {
            AddColumsToTable();
            AddRowNamesToTable();
            PopulateTableWithData();
            SetTableParameters();
        }

        private void AddColumsToTable()
        {
            table.AddColumn(new TableColumn($"[khaki1]PC[/]\\[lightsteelblue]User[/]"));
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                table.AddColumn(new TableColumn($"[lightsteelblue]{gameMoves.Moves[i]}[/]"));
            }
        }

        private void AddRowNamesToTable()
        {
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                table.AddRow($"[khaki1]{gameMoves.Moves[i]}[/]");
            }
        }

        private void PopulateTableWithData()
        {
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                PopulateRowWithData(i);
            }
        }

        private void PopulateRowWithData(int i)
        {
            for (int j = 0; j < gameMoves.Moves.Length; j++)
            {
                table.UpdateCell(i, j + 1, gameMoves.HelpTable[i, j]);
            }
        }

        private void SetTableParameters()
        {
            table.Border(TableBorder.Square).BorderColor(Color.Grey27).Centered()
                .ShowRowSeparators()
                .Title(" Help Table ",
                    new Style(Color.White, Color.MediumPurple4, Decoration.None));
        }
    }
}