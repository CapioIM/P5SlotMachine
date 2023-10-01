namespace P5SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowAndColumnLines =
                Constants.COLUMN_LINES_IN_GAME +
                Constants.ROW_LINES_IN_GAME;              //rows and column lines amount
            int allLinesTogether =
                Constants.COLUMN_LINES_IN_GAME +
                Constants.ROW_LINES_IN_GAME +
                Constants.DIAGONAL_LINES_IN_GAME;  // sum of all lines together

            double playerBalanceTotal = Constants.PLAYER_STARTING_BALANCE;
            int amountOfLanesPlay = 0;

            while (playerBalanceTotal > 0)
            {
                // Game starting text
                UIMethods.DisplayWelcomeScreen(LogicMethods.slotMachineArray, Constants.DIAGONAL_LINES_IN_GAME);
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);

                double betPerLane = 0;
                bool sufficientBetFunds = true;

                while (sufficientBetFunds)  // loop for bet as long as there is enough of balance program continues
                {
                    do
                    {
                        UIMethods.DisplayQuestionToPlayer(UIMethods.Questions.HowManyLanes);     //Display quiestion
                        amountOfLanesPlay = UIMethods.GetNumberFromPlayer();                       //enter how many lanes to play
                    }
                    while (amountOfLanesPlay == 0);

                    do
                    {
                        UIMethods.DisplayQuestionToPlayer(UIMethods.Questions.HowMuchBetPerLane);  // display question Bet amount per lane
                        betPerLane = UIMethods.GetNumberFromPlayer();                               //enter bet per lane
                    }
                    while (betPerLane == 0);

                    if (amountOfLanesPlay > allLinesTogether)  // amountOfLanesPlay cannot be more than max amount of total lanes
                    {
                        amountOfLanesPlay = allLinesTogether;
                    }

                    if (playerBalanceTotal < amountOfLanesPlay * betPerLane)                                    // balance has to be greater than bet * lanes
                    {
                        UIMethods.DisplayQuestionToPlayer(UIMethods.Questions.InsufficientFunds);               // Display quiestion 
                    }
                    else                                                                                        // continue program if bet amount is less than money balance 
                    {
                        playerBalanceTotal -= amountOfLanesPlay * betPerLane;
                        sufficientBetFunds = false;
                    }
                }

                LogicMethods.PrintSlotMachine(LogicMethods.slotMachineArray);  //fill 2D array with numbers

                double lineWinAmount = 0;

                int rowsToPlay = Math.Min(amountOfLanesPlay, Constants.ROW_LINES_IN_GAME);
                // row lines check and output to the screen

                // Rows matching lines loop 
                lineWinAmount += LogicMethods.GetHorizontalLineMatches(LogicMethods.slotMachineArray, rowsToPlay);

                //  calculation of column lanes to be played + columns are played if amount of lanes played is more than rows in array
                if (amountOfLanesPlay > Constants.ROW_LINES_IN_GAME)      // if columns are playable 
                {
                    int columnLinesToPlay = Math.Min(
                        Constants.COLUMN_LINES_IN_GAME,
                        amountOfLanesPlay - Constants.ROW_LINES_IN_GAME);      // set variable with min amount out of 2 numbers

                    lineWinAmount += LogicMethods.GetVerticalLineMatches(LogicMethods.slotMachineArray, columnLinesToPlay);
                }

                //Diagonal lines check
                if (amountOfLanesPlay > rowAndColumnLines)
                {
                    lineWinAmount += LogicMethods.GetDiagonalLineMatch(LogicMethods.slotMachineArray, amountOfLanesPlay);
                }

                playerBalanceTotal += (lineWinAmount * Constants.WIN_MULTIPLIER * betPerLane);
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);

                if (UIMethods.ContinueGameDecision() == false)
                {
                    Environment.Exit(0);
                }

            }//end of while loop
        }
    }
}
