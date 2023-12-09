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
            AddFirstColumnToTable();
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                table.AddColumn(
                    new TableColumn($"[lightsteelblue]{gameMoves.Moves[i]}[/]"));
            }
        }

        private void AddFirstColumnToTable()
        {
            table.AddColumn(
                new TableColumn($"[khaki1]PC[/]\\[lightsteelblue]User[/]"));
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
            table.Border(TableBorder.Square).BorderColor(Color.Grey27)
                .Centered().ShowRowSeparators()
                .Title(" Help Table ",
                    new Style(Color.White, Color.MediumPurple4, Decoration.None));
        }

        public static void PrintArgumentsRequirements()
        {
            AnsiConsole.Markup("Please provide odd number of unique " +
                "arguments and\n" +
                "make sure the overall amount of arguments equals or " +
                "greater than 3.\n\n");
        }

        public static void PrintArgumentsAmountErrorMessage(int amount)
        {
            AnsiConsole.Markup($"Oops! Seems like you have entered wrong" +
                    $" amount of arguments...\n\nYou have entered " +
                    $"[underline red]{amount}[/] arguments.\n\n");
        }

        private static void PrintSingleMoveWithColor(List<string> distinctMoves,
            string item)
        {
            AnsiConsole.Markup(
                    distinctMoves.Contains(item) ?
                    $"[underline red]{item}[/] " :
                    $"[green]{item}[/] "
                    );
        }

        public static void PrintMovesRowWithColor(List<string> distinctMoves,
            string[] Moves)
        {
            foreach (string item in Moves)
            {
                PrintSingleMoveWithColor(distinctMoves, item);
            }

            Console.WriteLine("\n\n");
        }

        public static void PrintNonUniqueErrorMessage()
        {
            Console.WriteLine($"Oops! Arguments marked with red " +
                    $"are not unique:\n");
        }

        public static void PrintExample()
        {
            AnsiConsole.Write(CreateCorrectExamplePanel());
            AnsiConsole.Write(CreateIncorrectExampleTable());
        }

        private static Panel CreateCorrectExamplePanel()
        {
            return new Panel("Rock Scissors Paper Lizard Spok")
                .Header("[underline green]CORRECT EXAMPLE:[/]")
                .Border(BoxBorder.Rounded).HeaderAlignment(Justify.Left)
                .Padding(2, 1, 2, 1).PadLeft(8);
        }

        private static Panel CreateIncorrectExampleTable()
        {
            return new Panel("Rock Scissors Paper Scissors")
                .Header("[underline red]INCORRECT EXAMPLE:[/]")
                .Border(BoxBorder.Rounded).HeaderAlignment(Justify.Left)
                .Padding(2, 1, 2, 1).PadLeft(8).PadRight(5);
        }
    }
}