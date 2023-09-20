namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int ROW_LINES_IN_GAME = 3;      // how many vertical lines
        const int COLUMN_LINES_IN_GAME = 3;     //how many horizontal lines
        const int DIAGONAL_LINES_IN_GAME = 2;   // how many diagonal lines
        const int DIAGONAL_LINE_LENGTH = 3;     //length of diagonal line
        const int PLAYER_STARTING_BALANCE = 50;
        static void Main(string[] args)
        {
            int[] slotSymbols = { 0 };//, 1, 2, 3, 4, 5, 6, 7, 8, 9};             // test symbols
            int[,] slotMachineArray = new int[ROW_LINES_IN_GAME, COLUMN_LINES_IN_GAME];          //slot machine array size
            int rowAndColumnLines = COLUMN_LINES_IN_GAME + ROW_LINES_IN_GAME;                         //rows and column lines amount
            double playerBalanceTotal = PLAYER_STARTING_BALANCE;
            int amountOfLanesPlay = 0;
            double betPerLane = 0;

            while (true)
            {
                // Game starting text

                Console.WriteLine("Hello and Welcome to Slot Machine Game!");
                Console.WriteLine($"" +
                    $" Lines: 1-{ROW_LINES_IN_GAME} Vertical!\n" +
                    $" Lines {ROW_LINES_IN_GAME + 1}-{rowAndColumnLines} vertical and horizontal!\n" +
                    $" Lines {rowAndColumnLines + 1}-{rowAndColumnLines + DIAGONAL_LINES_IN_GAME} vertical, horizontal and diagonal");
                Console.WriteLine();
                Console.WriteLine($"Your Balance is {playerBalanceTotal} !");
                Console.WriteLine();

                bool sufficientBetFunds = true;
                while (sufficientBetFunds)  // loop for bet as long as there is enough of balance program continues
                {
                    Console.WriteLine("How many lines would you like to play?");
                    Console.WriteLine();
                    amountOfLanesPlay = Convert.ToInt32(Console.ReadLine());                                    //enter how many lanes to play
                    if (amountOfLanesPlay > ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME)  // amountOfLanesPlay cannot be more than max amount of lanes to play
                    {
                        amountOfLanesPlay = ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME;
                    }

                    Console.WriteLine("How much would you like to bet per lane?");
                    betPerLane = Convert.ToInt32(Console.ReadLine());                                           //enter bet per lane
                    if (playerBalanceTotal < amountOfLanesPlay * betPerLane)                                         // balance has to be greater than bet * lanes
                    {
                        Console.WriteLine("You have insufficient funds! Please place lower bet!");
                    }
                    else                                                                                        // continue program if bet amount is less than money balance 
                    {
                        playerBalanceTotal -= amountOfLanesPlay * betPerLane;
                        sufficientBetFunds = false;
                    }
                }


                for (int rowIndex = 0; rowIndex < ROW_LINES_IN_GAME; rowIndex++)                //fill array with random strings from slotSymbols array
                {
                    for (int columnIndex = 0; columnIndex < COLUMN_LINES_IN_GAME; columnIndex++)
                    {
                        int randomIndex = rand.Next(slotSymbols.Length);
                        slotMachineArray[rowIndex, columnIndex] = slotSymbols[randomIndex];
                        Console.Write($"{slotMachineArray[rowIndex, columnIndex]} ");
                    }
                    Console.WriteLine();
                }

                //how many row lines to be played
                int rowsToPlay = ROW_LINES_IN_GAME;
                if (amountOfLanesPlay < ROW_LINES_IN_GAME)
                {
                    rowsToPlay = amountOfLanesPlay;
                }

                double lineWinAmount = 0;
                double winMultiplyer = 10;

                // row lines check and output to the screen
                for (int rowIndex = 0; rowIndex < rowsToPlay; rowIndex++)
                {
                    int rowCharCheck = slotMachineArray[rowIndex, 0];       // store character
                    int rowCharMatch = 0;                                   // reset chars matched against stored character
                    for (int columnIndex = 0; columnIndex < COLUMN_LINES_IN_GAME; columnIndex++)
                    {
                        if (rowCharCheck == slotMachineArray[rowIndex, columnIndex])        //check char against stored char
                        {
                            rowCharMatch++;
                            if (rowCharMatch == COLUMN_LINES_IN_GAME)                   // amount of chars matched has to equal to length of row
                            {
                                lineWinAmount = betPerLane * winMultiplyer;
                                playerBalanceTotal = playerBalanceTotal + lineWinAmount;
                                Console.WriteLine($" Win - line nr: {rowIndex + 1} . You Won {lineWinAmount} !");            //output win lane
                            }
                        }
                    }
                }

                //  calculation of column lanes to be played + columns are played if amount of lanes played is more than rows in array
                if (amountOfLanesPlay > ROW_LINES_IN_GAME)      // if columns are playable 
                {
                    int columnLinesToPlay = COLUMN_LINES_IN_GAME;      // set amount of playable columns to max amount

                    // if columns are playable and not max column amount are playing, calculate how many columns are playing
                    if (ROW_LINES_IN_GAME <= amountOfLanesPlay && amountOfLanesPlay < ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME)
                    {
                        columnLinesToPlay = amountOfLanesPlay - ROW_LINES_IN_GAME;
                    }
                    // column lanes match and output on screen
                    for (int columnIndex = 0; columnIndex < columnLinesToPlay; columnIndex++)
                    {
                        int columnLinesMatch = 0;
                        int charStore = slotMachineArray[0, columnIndex];           // line character stored in a variable
                        for (int rowIndex = 0; rowIndex < ROW_LINES_IN_GAME; rowIndex++)
                        {
                            if (charStore == slotMachineArray[rowIndex, columnIndex])       //stored character is checked against character at specific place array
                            {
                                columnLinesMatch++;
                                if (columnLinesMatch == COLUMN_LINES_IN_GAME)
                                {
                                    lineWinAmount = betPerLane * winMultiplyer;
                                    playerBalanceTotal = playerBalanceTotal + lineWinAmount;
                                    Console.WriteLine($" Win | line nr: {columnIndex + 1} . You Won {lineWinAmount} !");
                                }
                            }
                        }
                    }
                }

                //Diagonal lines check

                if (amountOfLanesPlay > ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME)
                {
                    int diagonalLanesPlays = DIAGONAL_LINES_IN_GAME;
                    if (ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME >= amountOfLanesPlay && amountOfLanesPlay < ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME)
                    {
                        diagonalLanesPlays = amountOfLanesPlay - ROW_LINES_IN_GAME - COLUMN_LINES_IN_GAME;
                    }


                    if (diagonalLanesPlays >= 0)                //    if (diagonalLanesPlays >= 0)
                    {
                        int diagonalCharStore = slotMachineArray[0, 0];
                        int diagonalCharMatch = 0;
                        for (int diagonal = 0; diagonal < DIAGONAL_LINE_LENGTH; diagonal++)   // magic Number ????????? seems like i picked DIAGONAL_LINES_IN_GAME  BECAUSE IT FITS
                        {
                            if (diagonalCharStore == slotMachineArray[diagonal, diagonal])
                            {
                                diagonalCharMatch++;
                            }
                            if (diagonalCharMatch == DIAGONAL_LINE_LENGTH)
                            {
                                lineWinAmount = betPerLane * winMultiplyer;
                                playerBalanceTotal = playerBalanceTotal + lineWinAmount;
                                Console.WriteLine($" Win diagonal line 1 . You Won {lineWinAmount} !");
                            }
                        }
                        diagonalLanesPlays--;
                    }

                    //2nd/reverse diagonal line check
                    if (0 < diagonalLanesPlays && diagonalLanesPlays < DIAGONAL_LINES_IN_GAME) // if diagonal line 2 is playing  (diagoanlLanesPlays = 1)
                    {
                        int diagonalCharStore = slotMachineArray[2, 0];
                        int diagonalCharMatch = 0;
                        int diagonalRow = 0;

                        for (int diagonalColumn = DIAGONAL_LINES_IN_GAME; diagonalColumn >= 0; diagonalColumn--)
                        {
                            if (diagonalCharStore == slotMachineArray[diagonalRow, diagonalColumn])
                            {
                                diagonalCharMatch++;
                            }
                            if (diagonalCharMatch == DIAGONAL_LINE_LENGTH)
                            {
                                lineWinAmount = betPerLane * winMultiplyer;
                                playerBalanceTotal = playerBalanceTotal + lineWinAmount;
                                Console.WriteLine($" Win diagonal line 2 . You Won {lineWinAmount} !");
                            }
                            diagonalRow++;
                        }
                    }
                }

                Console.WriteLine($"Your new balance {playerBalanceTotal} !");
                Console.WriteLine("If want to play again press any key, if dont want to play press N .");
                string playAgain = Console.ReadKey().KeyChar.ToString().ToLower();

                Console.Clear();
                if (playAgain == "n")
                {
                    break;
                }

            }//end of while loop
        }
    }
}
