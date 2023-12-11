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
                table.AddColumn(new TableColumn(
                    $"[lightsteelblue]{gameMoves.Moves[i]}[/]"));
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
                table.UpdateCell(i, j + 1, gameMoves.MovesTable[i, j]);
            }
        }

        private void SetTableParameters()
        {
            table.Border(TableBorder.Square).BorderColor(Color.Grey27)
                .ShowRowSeparators().Centered()
                .Title(" Help Table ", new Style(
                    Color.White, Color.MediumPurple4, Decoration.None));
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

        private static void PrintSingleMoveWithColor(
            List<string> distinctMoves, string item)
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

        public static void PrintArgumentsHelp()
        {
            PrintArgumentsRequirements();
            PrintExample();
        }

        public static void PrintHmac(string hmac)
        {
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn(new Panel(hmac).Padding(2, 1, 2, 1)
                .Header("[white on MediumPurple4]HMAC[/]")
                .Border(BoxBorder.Rounded).BorderColor(Color.Grey27)))
                .Centered().MinimalBorder());
        }

        public static void ClearConsoleScreen()
        {
            AnsiConsole.Clear();
        }

        public static void PrintHmacKey(byte[] key)
        {
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn(new Panel(Convert.ToHexString(key))
                .Header("[white on MediumPurple4]HMAC key[/]")
                .Border(BoxBorder.Rounded).Padding(2, 1, 2, 1)
                .BorderColor(Color.Grey27))).Centered().MinimalBorder());
        }

        public static void PrintGreeting()
        {
            FigletFont font = FigletFont.Load("speed.flf");
            PrintFigletLine(font, "Welcome");
            PrintFigletLine(font, "to the");
            PrintFigletLine(font, "Task Three");
            PrintFigletLine(font, "Game!");
        }

        private static void PrintFigletLine(FigletFont font, string text)
        {
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn(new FigletText(font, text)
                .Justify(Justify.Center).Color(Color.MediumPurple4)))
                .Centered().MinimalBorder());
        }

        public void ShowHelpTableBlock()
        {
            PrintHelpTable();
            PrintPressEnter("Press Enter to continue...");
        }

        public static void PrintGoodbuy()
        {
            var panel = new Panel("Thanks for the game!")
                .Border(BoxBorder.Rounded).BorderColor(Color.Grey27)
                .Header("[white on MediumPurple4]Buy[/]").Padding(2, 1, 2, 1);
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn(panel)).Centered().MinimalBorder());
        }

        public void ShowGreeting()
        {
            PrintGreetingBlock();
            PrintPressEnter("Press Enter to start...");
        }

        private void PrintPressEnter(string message)
        {
            AnsiConsole.Cursor.Hide();
            AnsiConsole.Write(new Table().AddColumn(new TableColumn(message))
                .Centered().MinimalBorder());
            Console.Read();
            AnsiConsole.Cursor.Show();
        }

        private void PrintGreetingBlock()
        {
            AnsiConsole.Clear();
            AnsiConsole.WriteLine();
            PrintGreeting();
            AnsiConsole.WriteLine();
        }

        public static void MoveToZeroPosition()
        {
            AnsiConsole.Cursor.MoveLeft();
            AnsiConsole.Cursor.MoveUp();
        }

        public static void PrintUnexpectedErrorMessage()
        {
            Console.WriteLine("Unexpected error.\n" +
                    "The program will be terminated.\n");
        }

        public void GreetUser()
        {
            ShowGreeting();
            ClearConsoleScreen();
            MoveToZeroPosition();
        }

        public void PrintGameOutcome(string choice,
            CryptographicKeys crypto, int computerMove)
        {
            PrintChoiceTable(choice, computerMove);
            PrintResult(gameMoves.MovesTable[computerMove, int.Parse(choice) - 1]);
            PrintHmacKey(crypto.Key);
        }

        private void PrintResult(string result)
        {
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn($"[white on MediumPurple4]" +
                $"{result.PadRight(37).PadLeft(66)}[/]").Centered())
                .Centered().RoundedBorder()
                .BorderColor(Color.Khaki1).Width(70));
        }

        private void PrintChoiceTable(string choice, int computerMove)
        {
            var choiceTable = new Table().Centered().MinimalBorder();
            AddColumnsToChoiceTable(ref choiceTable, choice);
            AddRowToChoiceTable(ref choiceTable, computerMove);
            AnsiConsole.Write(choiceTable);
        }

        private void AddRowToChoiceTable(ref Table choiceTable, int computerMove)
        {
            choiceTable.AddRow("Computer move:", gameMoves.Moves[computerMove])
                .Centered();
        }

        private void AddColumnsToChoiceTable(
            ref Table choiceTable, string choice)
        {
            choiceTable.AddColumn(new TableColumn($"Your move:")).Centered();
            choiceTable.AddColumn(new TableColumn(
                $"{gameMoves.Moves[int.Parse(choice) - 1]}")).Centered();
        }

        public static void PrintChoice(string choice)
        {
            AnsiConsole.Cursor.MoveUp(3);
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn($"You entered: [Khaki1]{choice}[/]")
                .Centered()).Centered().MinimalBorder());
        }

        public void PrintMenu()
        {
            Table menuTable = CreateMenuTable();
            SetUpMenuTableHeader(ref menuTable);
            SetUpMenuOptionsRows(ref menuTable);
            AddInputRequestRowToMenuTable(ref menuTable);
            AnsiConsole.Write(menuTable);
        }

        private static Table CreateMenuTable()
        {
            return new Table().Centered().NoBorder()
                .HideRowSeparators();
        }

        private static void SetUpMenuTableHeader(ref Table menuTable)
        {
            AddColumnToMenuTable(ref menuTable);
            AddHeaderRowToMenuTable(ref menuTable);
        }

        private static void AddColumnToMenuTable(ref Table menuTable)
        {
            menuTable.AddColumn(new TableColumn("[grey74]Available moves:[/]")
                .LeftAligned()).Centered();
        }

        private static void AddHeaderRowToMenuTable(ref Table menuTable)
        {
            menuTable.AddRow("[Grey27](pick a number)[/]")
                .LeftAligned().Centered().AddEmptyRow();
        }

        private void SetUpMenuOptionsRows(ref Table menuTable)
        {
            AddMovesOptionsToMenuTable(ref menuTable);
            AddExitRowToMenuTable(ref menuTable);
            AddHelpRowToMenuTable(ref menuTable);
        }

        private void AddMovesOptionsToMenuTable(ref Table menuTable)
        {
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                menuTable.AddRow(
                    $"{i + 1} - [MediumPurple4]{gameMoves.Moves[i]}[/]")
                    .LeftAligned().Centered();
            }
        }

        private static void AddExitRowToMenuTable(ref Table menuTable)
        {
            menuTable.AddRow($"[khaki1]0[/] - [white]exit[/]")
                .LeftAligned()
                .Centered();
        }

        private static void AddHelpRowToMenuTable(ref Table menuTable)
        {
            menuTable.AddRow($"[khaki1]?[/] - [white on MediumPurple4]help[/]")
                .LeftAligned().Centered();
        }

        private static void AddInputRequestRowToMenuTable(ref Table menuTable)
        {
            menuTable.AddEmptyRow().Centered()
                .AddRow("Enter your move: ").LeftAligned().Centered();
        }

        public static void CollectUserInput(ref string choice)
        {
            choice = Console.ReadLine()!;
            AnsiConsole.Cursor.MoveUp(1);
            AnsiConsole.Cursor.MoveLeft();
            Console.WriteLine(new string(' ', 200));
        }
    }
}