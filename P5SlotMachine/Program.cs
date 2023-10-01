namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int ROW_LINES_IN_GAME = 3;      // how many vertical lines
        const int COLUMN_LINES_IN_GAME = 3;     //how many horizontal lines
        const int DIAGONAL_LINES_IN_GAME = 2;   // how many diagonal lines
        const int DIAGONAL_LINE_LENGTH = 3;     //length of diagonal line
        const int PLAYER_STARTING_BALANCE = 50;   // player starting balance
        const double WIN_MULTIPLIER = 10;        //win multiplier

        static void Main(string[] args)
        {
            int[,] slotMachineArray = new int[ROW_LINES_IN_GAME, COLUMN_LINES_IN_GAME];          //slot machine array size
            int rowAndColumnLines = COLUMN_LINES_IN_GAME + ROW_LINES_IN_GAME;                         //rows and column lines amount
            int allLinesTogether = COLUMN_LINES_IN_GAME + ROW_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME;  // sum of all lines together
            double playerBalanceTotal = PLAYER_STARTING_BALANCE;
            int amountOfLanesPlay = 0;

            while (playerBalanceTotal > 0)
            {
                // Game starting text
                UIMethods.DisplayWelcomeScreen(slotMachineArray, DIAGONAL_LINES_IN_GAME);
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);

                double betPerLane = 0;
                bool sufficientBetFunds = true;
                while (sufficientBetFunds)  // loop for bet as long as there is enough of balance program continues
                {
                    do
                    {
                        amountOfLanesPlay = UIMethods.AskPlayerForNumber("How many lines would you like to play?");      //enter how many lanes to play
                    }
                    while (amountOfLanesPlay == 0);

                    do
                    {
                        betPerLane = UIMethods.AskPlayerForNumber("How much would you like to bet per lane?");          //enter bet per lane
                    }
                    while (betPerLane == 0);

                    if (amountOfLanesPlay > allLinesTogether)  // amountOfLanesPlay cannot be more than max amount of lanes to play
                    {
                        amountOfLanesPlay = allLinesTogether;
                    }

                    if (playerBalanceTotal < amountOfLanesPlay * betPerLane)                                         // balance has to be greater than bet * lanes
                    {
                        UIMethods.DisplayInsufficientFunds();
                    }
                    else                                                                                        // continue program if bet amount is less than money balance 
                    {
                        playerBalanceTotal -= amountOfLanesPlay * betPerLane;
                        sufficientBetFunds = false;
                    }
                }

                LogicMethods.PrintSlotMachine(slotMachineArray);

                //for (int rowIndex = 0; rowIndex < ROW_LINES_IN_GAME; rowIndex++)                //fill 2-D array with random num 0-9
                //{
                //    for (int columnIndex = 0; columnIndex < COLUMN_LINES_IN_GAME; columnIndex++)
                //    {
                //        int randomIndex = rand.Next(0, 2);
                //        slotMachineArray[rowIndex, columnIndex] = randomIndex;
                //        UIMethods.DisplaySlotNumbers(slotMachineArray, rowIndex, columnIndex);      // print slot machine results to the screen
                //    }
                //    UIMethods.PrintEmptyNewLine();
                //}

                double lineWinAmount = 0;

                int rowsToPlay = Math.Min(amountOfLanesPlay, ROW_LINES_IN_GAME);
                // row lines check and output to the screen

                // Rows matching lines loop 
                lineWinAmount += LogicMethods.GetHorizontalLineMatches(slotMachineArray, rowsToPlay);

                //  calculation of column lanes to be played + columns are played if amount of lanes played is more than rows in array
                if (amountOfLanesPlay > ROW_LINES_IN_GAME)      // if columns are playable 
                {
                    int columnLinesToPlay = Math.Min(COLUMN_LINES_IN_GAME, amountOfLanesPlay - ROW_LINES_IN_GAME);      // set variable with min amount out of 2 numbers
                    lineWinAmount += LogicMethods.GetVerticalLineMatches(slotMachineArray, columnLinesToPlay);
                }
                //Diagonal lines check

                if (amountOfLanesPlay > rowAndColumnLines)
                {
                    int diagonalCharStoreOne = slotMachineArray[0, 0];
                    int diagonalOneMatch = 0;
                    int diagonalCharStoreTwo = slotMachineArray[0, DIAGONAL_LINE_LENGTH - 1];
                    int diagonalTwoMatch = 0;
                    int diagonalColumn = DIAGONAL_LINE_LENGTH - 1;

                    for (int diagonal = 0; diagonal < DIAGONAL_LINE_LENGTH; diagonal++)
                    {
                        if (diagonalCharStoreOne == slotMachineArray[diagonal, diagonal])
                        {
                            diagonalOneMatch++;
                        }
                        if (amountOfLanesPlay == allLinesTogether)
                        {
                            if (diagonalCharStoreTwo == slotMachineArray[diagonal, diagonalColumn - diagonal])
                            {
                                diagonalTwoMatch++;
                            }
                        }
                    }
                    if (diagonalOneMatch == DIAGONAL_LINE_LENGTH)
                    {
                        lineWinAmount++;
                        UIMethods.PrintDiagonalLineWinOne();
                    }
                    if (diagonalTwoMatch == DIAGONAL_LINE_LENGTH)
                    {
                        lineWinAmount++;
                        UIMethods.PrintDiagonalLineWinTwo();
                    }
                }

                playerBalanceTotal += (lineWinAmount * WIN_MULTIPLIER * betPerLane);
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);

                if (UIMethods.ContinueGameDecision() == false)
                {
                    Environment.Exit(0);
                }

            }//end of while loop
        }
    }
}
