using Spectre.Console;

namespace TaskThreeGame
{
    public class ConsoleUi
    {
        private readonly GameMoves gameMoves;

        private readonly Table helpTable = new();

        private const int panelWidth = 74;

        #region GameConsoleUiColorScheme

        private const string colorDominant = "MediumPurple4";

        private const string colorDominantAuxiliary = "lightsteelblue";

        private const string colorAccent = "khaki1";

        private const string colorAccentAuxiliary = "White";

        private const string colorShade = "Grey27";

        private const string colorShadeAuxiliary = "grey74";

        private static readonly Color colorBorder = Color.Grey27;

        private static readonly Color colorGreeting = Color.LightSteelBlue;

        #endregion GameConsoleUiColorScheme

        private const string helpTableFirstCell =
            $"[{colorAccent}]PC [/]\\[{colorDominantAuxiliary}] User[/]";

        public ConsoleUi(GameMoves gameMoves)
        {
            this.gameMoves = gameMoves;
            CreateHelpTable();
        }

        public void PrintHelpTable() => AnsiConsole.Write(helpTable);

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
            AddMovesColumnsToTable();
        }

        private void AddMovesColumnsToTable()
        {
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                AddOneMovesColumnToTable(i);
            }
        }

        private void AddOneMovesColumnToTable(int i)
        {
            helpTable.AddColumn(new TableColumn(
                    $"[{colorDominantAuxiliary}]{gameMoves.Moves[i]}[/]"));
        }

        private void AddFirstColumnToTable() =>
            helpTable.AddColumn(new TableColumn(
                helpTableFirstCell));

        private void AddRowNamesToTable()
        {
            for (int i = 0; i < gameMoves.Moves.Length; i++)
            {
                helpTable.AddRow($"[{colorAccent}]{gameMoves.Moves[i]}[/]");
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
                helpTable.UpdateCell(i, j + 1, gameMoves.MovesTable[i, j]);
            }
        }

        private void SetTableParameters()
        {
            helpTable.Border(TableBorder.Square).BorderColor(colorBorder)
                .ShowRowSeparators().Centered()
                .Title($"[{colorAccentAuxiliary} on " +
                $"{colorDominant}] Help Table [/]");
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
                    $"[green]{item}[/] ");
        }

        public static void PrintMovesRowBlockWithColor(
            List<string> distinctMoves, string[] moves)
        {
            PrintMovesRowsWithColor(distinctMoves, moves);
            Console.WriteLine("\n\n");
        }

        private static void PrintMovesRowsWithColor(
            List<string> distinctMoves, string[] moves)
        {
            foreach (string item in moves)
            {
                PrintSingleMoveWithColor(distinctMoves, item);
            }
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
                .Header($"[{colorAccentAuxiliary} on {colorDominant}]HMAC[/]")
                .Border(BoxBorder.Rounded).BorderColor(colorBorder)))
                .Centered().MinimalBorder());
        }

        public static void ClearConsoleScreen() => AnsiConsole.Clear();

        public static void PrintHmacKey(string key)
        {
            AnsiConsole.Write(new Table().AddColumn(new TableColumn(
                new Panel(key).Header($"[{colorAccentAuxiliary} on " +
                $"{colorDominant}]HMAC key[/]").Border(BoxBorder.Rounded)
                .Padding(2, 1, 2, 1).BorderColor(colorBorder))).Centered()
                .MinimalBorder());
        }

        public static void PrintGreeting()
        {
            FigletFont font = FigletFont.Load("speed.flf");
            PrintGreetingMessage(font);
        }

        private static void PrintGreetingMessage(FigletFont font)
        {
            PrintFigletLine(font, "Welcome");
            PrintFigletLine(font, "to the");
            PrintFigletLine(font, "Task Three");
            PrintFigletLine(font, "Game!");
        }

        private static void PrintFigletLine(FigletFont font, string text)
        {
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn(new FigletText(font, text)
                .Justify(Justify.Center).Color(colorGreeting)))
                .Centered().MinimalBorder());
        }

        public void ShowHelpTableBlock()
        {
            PrintHelpTable();
            PrintPressEnter("Press Enter to continue...");
        }

        public static void PrintGoodbuy()
        {
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn(CreateGoodbuyPanel()))
                .Centered().MinimalBorder().Width(panelWidth));
        }

        private static Panel CreateGoodbuyPanel()
        {
            return new Panel("Thanks for the game!".PadRight(35).PadLeft(57))
                .Border(BoxBorder.Rounded).Padding(2, 1, 2, 1).Expand()
                .BorderColor(colorBorder).HeaderAlignment(Justify.Left)
                .Header($"[{colorAccentAuxiliary} on {colorDominant}]Buy[/]");
        }

        public void ShowGreeting()
        {
            PrintGreetingBlock();
            PrintPressEnter("Press Enter to start...");
        }

        private static void PrintPressEnter(string message)
        {
            AnsiConsole.Cursor.Hide();
            AnsiConsole.Write(new Table().AddColumn(new TableColumn(message))
                .Centered().MinimalBorder());
            Console.Read();
            AnsiConsole.Cursor.Show();
        }

        private static void PrintGreetingBlock()
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
            PrintResult(
                gameMoves.MovesTable[computerMove, int.Parse(choice) - 1]);
            PrintHmacKey(crypto.Key);
        }

        private static void PrintResult(string result)
        {
            AnsiConsole.Write(new Table()
                .AddColumn(new TableColumn($"[{colorAccentAuxiliary} on " +
                $"{colorDominant}]{result.PadRight(37).PadLeft(66)}[/]")
                .Centered()).Centered().RoundedBorder()
                .BorderColor(Color.Khaki1).Width(70));
        }

        private void PrintChoiceTable(string choice, int computerMove)
        {
            var choiceTable = new Table().Centered().MinimalBorder();
            AddColumnsToChoiceTable(ref choiceTable, choice);
            AddRowToChoiceTable(ref choiceTable, computerMove);
            AnsiConsole.Write(choiceTable);
        }

        private void AddRowToChoiceTable(ref Table choiceTable,
            int computerMove)
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
            AnsiConsole.Write(new Table().AddColumn(
                new TableColumn($"You entered: [{colorAccent}]{choice}[/]")
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
            menuTable.AddColumn(new TableColumn(
                $"[{colorShadeAuxiliary}]Available moves:[/]")
                .LeftAligned()).Centered();
        }

        private static void AddHeaderRowToMenuTable(ref Table menuTable)
        {
            menuTable.AddRow($"[{colorShade}](pick a number)[/]")
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
                AddMovesOptionsRowToMenuTable(ref menuTable, i);
            }
        }

        private void AddMovesOptionsRowToMenuTable(ref Table menuTable, int i)
        {
            menuTable.AddRow($"{i + 1} - [{colorDominantAuxiliary}]" +
                    $"{gameMoves.Moves[i]}[/]").LeftAligned().Centered();
        }

        private static void AddExitRowToMenuTable(ref Table menuTable)
        {
            menuTable.AddRow(
                $"[{colorAccent}]0[/] - [{colorAccentAuxiliary}]exit[/]")
                .LeftAligned().Centered();
        }

        private static void AddHelpRowToMenuTable(ref Table menuTable)
        {
            menuTable.AddRow($"[{colorAccent}]?[/] - [{colorAccentAuxiliary}" +
                $" on {colorDominant}]help[/]").LeftAligned().Centered();
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

        public static void PrintCheckLink()
        {
            AnsiConsole.Write(new Table().AddColumn(new TableColumn(
                CreateCheckLinkPanel()).Centered())
                .Centered().MinimalBorder().Width(panelWidth));
        }

        private static Panel CreateCheckLinkPanel()
        {
            return new Panel(CreateCheckLinkMessage())
                .Border(BoxBorder.Rounded).BorderColor(colorBorder)
                .Padding(2, 1, 2, 1).Expand();
        }

        private static string CreateCheckLinkMessage()
        {
            return "\nYou can check if the computer was honest\n" +
                "and did not change it\'s move by using this website:\n\n" +
                $"[underline {colorDominantAuxiliary}]" +
                $"https://appdevtools.com/hmac-generator[/]\n";
        }
    }
}