﻿namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int[,] slotMachineArray = new int[LogicMethods.ROW_LINES_IN_GAME, LogicMethods.COLUMN_LINES_IN_GAME];          //slot machine array size
            int rowAndColumnLines = LogicMethods.COLUMN_LINES_IN_GAME + LogicMethods.ROW_LINES_IN_GAME;                         //rows and column lines amount
            int allLinesTogether = LogicMethods.COLUMN_LINES_IN_GAME + LogicMethods.ROW_LINES_IN_GAME + LogicMethods.DIAGONAL_LINES_IN_GAME;  // sum of all lines together
            double playerBalanceTotal = LogicMethods.PLAYER_STARTING_BALANCE;
            int amountOfLanesPlay = 0;

            while (playerBalanceTotal > 0)
            {
                // Game starting text
                UIMethods.DisplayWelcomeScreen(slotMachineArray, LogicMethods.DIAGONAL_LINES_IN_GAME);
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
                        UIMethods.DisplayInsufficientFundsMessage();
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

                int rowsToPlay = Math.Min(amountOfLanesPlay, LogicMethods.ROW_LINES_IN_GAME);
                // row lines check and output to the screen

                // Rows matching lines loop 
                lineWinAmount += LogicMethods.GetHorizontalLineMatches(slotMachineArray, rowsToPlay);

                //  calculation of column lanes to be played + columns are played if amount of lanes played is more than rows in array
                if (amountOfLanesPlay > LogicMethods.ROW_LINES_IN_GAME)      // if columns are playable 
                {
                    int columnLinesToPlay = Math.Min(
                        LogicMethods.COLUMN_LINES_IN_GAME,
                        amountOfLanesPlay - LogicMethods.ROW_LINES_IN_GAME);      // set variable with min amount out of 2 numbers
                    lineWinAmount += LogicMethods.GetVerticalLineMatches(slotMachineArray, columnLinesToPlay);
                }
                //Diagonal lines check

                if (amountOfLanesPlay > rowAndColumnLines)
                {
                    int diagonalCharStoreOne = slotMachineArray[0, 0];
                    int diagonalOneMatch = 0;
                    int diagonalCharStoreTwo = slotMachineArray[0, LogicMethods.DIAGONAL_LINE_LENGTH - 1];
                    int diagonalTwoMatch = 0;
                    int diagonalColumn = LogicMethods.DIAGONAL_LINE_LENGTH - 1;

                    for (int diagonal = 0; diagonal < LogicMethods.DIAGONAL_LINE_LENGTH; diagonal++)
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
                    if (diagonalOneMatch == LogicMethods.DIAGONAL_LINE_LENGTH)
                    {
                        lineWinAmount++;
                        UIMethods.PrintDiagonalLineWinOne();
                    }
                    if (diagonalTwoMatch == LogicMethods.DIAGONAL_LINE_LENGTH)
                    {
                        lineWinAmount++;
                        UIMethods.PrintDiagonalLineWinTwo();
                    }
                }

                playerBalanceTotal += (lineWinAmount * LogicMethods.WIN_MULTIPLIER * betPerLane);
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);

                if (UIMethods.ContinueGameDecision() == false)
                {
                    Environment.Exit(0);
                }

            }//end of while loop
        }
    }
}
