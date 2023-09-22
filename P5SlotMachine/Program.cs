﻿namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int ROW_LINES_IN_GAME = 3;      // how many vertical lines
        const int COLUMN_LINES_IN_GAME = 3;     //how many horizontal lines
        const int DIAGONAL_LINES_IN_GAME = 2;   // how many diagonal lines
        const int DIAGONAL_LINE_LENGTH = 3;     //length of diagonal line
        const int PLAYER_STARTING_BALANCE = 50;
        const double WIN_MULTIPLIER = 10;

        static void Main(string[] args)
        {
            int[,] slotMachineArray = new int[ROW_LINES_IN_GAME, COLUMN_LINES_IN_GAME];          //slot machine array size
            int rowAndColumnLines = COLUMN_LINES_IN_GAME + ROW_LINES_IN_GAME;                         //rows and column lines amount
            int allLinesTogether = COLUMN_LINES_IN_GAME + ROW_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME;
            double playerBalanceTotal = PLAYER_STARTING_BALANCE;
            int amountOfLanesPlay = 0;

            while (playerBalanceTotal > 0)
            {
                // Game starting text
                Console.WriteLine("Hello and Welcome to Slot Machine Game!");
                Console.WriteLine($"" +
                    $" Lines: 1-{ROW_LINES_IN_GAME} Vertical!\n" +
                    $" Lines {ROW_LINES_IN_GAME + 1}-{rowAndColumnLines} vertical and horizontal!\n" +
                    $" Lines {rowAndColumnLines + 1}-{allLinesTogether} vertical, horizontal and diagonal");
                Console.WriteLine();
                Console.WriteLine($"Your Balance is {playerBalanceTotal} !");
                Console.WriteLine();

                double betPerLane = 0;
                bool sufficientBetFunds = true;
                while (sufficientBetFunds)  // loop for bet as long as there is enough of balance program continues
                {
                    Console.WriteLine("How many lines would you like to play?");
                    Console.WriteLine();
                    amountOfLanesPlay = Convert.ToInt32(Console.ReadLine());                                    //enter how many lanes to play
                    if (amountOfLanesPlay > allLinesTogether)  // amountOfLanesPlay cannot be more than max amount of lanes to play
                    {
                        amountOfLanesPlay = allLinesTogether;
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

                for (int rowIndex = 0; rowIndex < ROW_LINES_IN_GAME; rowIndex++)                //fill array with random num 0-9
                {
                    for (int columnIndex = 0; columnIndex < COLUMN_LINES_IN_GAME; columnIndex++)
                    {
                        int randomIndex = rand.Next(0,10);
                        slotMachineArray[rowIndex, columnIndex] = randomIndex;
                        Console.Write($"{slotMachineArray[rowIndex, columnIndex]} ");
                    }
                    Console.WriteLine();
                }
                double lineWinAmount = 0;

                int rowsToPlay = Math.Min(amountOfLanesPlay, ROW_LINES_IN_GAME);
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
                        }
                    }
                    if (rowCharMatch == COLUMN_LINES_IN_GAME)                   // amount of chars matched has to equal to length of row
                    {
                        lineWinAmount++;
                        Console.WriteLine($" Win - line nr: {rowIndex + 1} !");            //output win lane
                    }
                }

                //  calculation of column lanes to be played + columns are played if amount of lanes played is more than rows in array
                if (amountOfLanesPlay > ROW_LINES_IN_GAME)      // if columns are playable 
                {
                    int columnLinesToPlay = Math.Min(COLUMN_LINES_IN_GAME, amountOfLanesPlay - ROW_LINES_IN_GAME);      // set variable with min amount out of 2

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
                            }
                        }
                        if (columnLinesMatch == COLUMN_LINES_IN_GAME)
                        {
                            lineWinAmount++;
                            Console.WriteLine($" Win | line nr: {columnIndex + 1} !");
                        }
                    }
                }

                //Diagonal lines check
                if (amountOfLanesPlay > rowAndColumnLines)
                {
                    int diagonalLanesPlay = Math.Min(DIAGONAL_LINES_IN_GAME, amountOfLanesPlay - rowAndColumnLines);
                    if (diagonalLanesPlay >= 0)       
                    {
                        diagonalLanesPlay--;
                        int diagonalCharStoreOne = slotMachineArray[0, 0];
                        int diagonalOneMatch = 0;
                        int diagonalCharStoreTwo = slotMachineArray[2, 0];
                        int diagonalTwoMatch = 0;
                        int diagonalColumn = 2;   

                        for (int diagonal = 0; diagonal < DIAGONAL_LINE_LENGTH; diagonal++)   
                        {
                            if (diagonalCharStoreOne == slotMachineArray[diagonal, diagonal])
                            {
                                diagonalOneMatch++;
                            }
                            if (diagonalLanesPlay > 0) // if diagonal line 2 is playing  (diagoanlLanesPlay = 1)
                            {
                                if (diagonalCharStoreTwo == slotMachineArray[diagonal, diagonalColumn])
                                {
                                    diagonalTwoMatch++;
                                }
                                diagonalColumn--;
                            }
                        }
                        if (diagonalOneMatch == DIAGONAL_LINE_LENGTH)
                        {
                            lineWinAmount++;
                            Console.WriteLine($" Win diagonal line 1 !");
                        }
                        if (diagonalTwoMatch == DIAGONAL_LINE_LENGTH)
                        {
                            lineWinAmount++;
                            Console.WriteLine($" Win diagonal line 2 !");
                        }
                    }
                }

                playerBalanceTotal += (lineWinAmount * WIN_MULTIPLIER * betPerLane);
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

