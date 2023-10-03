namespace P5SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowAndColumnLines =
                Constants.COLUMN_LINES_IN_GAME +
                Constants.ROW_LINES_IN_GAME;//rows and column lines amount
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
                        UIMethods.DisplayQuestionToPlayer(Enums.Questions.HowManyLanes);     //Display/print question
                        amountOfLanesPlay = UIMethods.GetNumberFromPlayer();                       //enter how many lanes to play
                    }
                    while (amountOfLanesPlay == 0);                                                 //torture untill number is entered

                    do
                    {
                        UIMethods.DisplayQuestionToPlayer(Enums.Questions.HowMuchBetPerLane);  // display question Bet amount per lane
                        betPerLane = UIMethods.GetNumberFromPlayer();                               //enter bet per lane
                    }
                    while (betPerLane == 0);                                                        //torture untill number is entered

                    if (amountOfLanesPlay > allLinesTogether)  // amountOfLanesPlay cannot be more than max amount of total lanes
                    {
                        amountOfLanesPlay = allLinesTogether;
                    }

                    if (playerBalanceTotal < amountOfLanesPlay * betPerLane)                                    // balance has to be greater than bet * lanes
                    {
                        UIMethods.DisplayQuestionToPlayer(Enums.Questions.InsufficientFunds);               // Display quiestion 
                    }
                    else                                                                                        // continue program if bet amount is less than money balance 
                    {
                        playerBalanceTotal -= amountOfLanesPlay * betPerLane;                                   //deduct bet from balance
                        sufficientBetFunds = false;                                                             //if enough balance program continues
                    }
                }

                LogicMethods.FillArraySlotMachine(LogicMethods.slotMachineArray);  //fill 2D array 
                UIMethods.DisplaySlotNumbers(LogicMethods.slotMachineArray);
                double lineWinAmount = 0;
                //rows
                int rowsToPlay = Math.Min(amountOfLanesPlay, Constants.ROW_LINES_IN_GAME); // how many row lines should be checked/played
                lineWinAmount += LogicMethods.GetHorizontalLineMatches(LogicMethods.slotMachineArray, rowsToPlay);  // row lines match,+print win lines, and count win lines
                //columns
                if (amountOfLanesPlay > Constants.ROW_LINES_IN_GAME)      // if columns are playable 
                {
                    int columnLinesToPlay = Math.Min(
                        Constants.COLUMN_LINES_IN_GAME,                         // set variable with min amount out of 2 numbers 
                        amountOfLanesPlay - Constants.ROW_LINES_IN_GAME);      // for how many column lines should be checked/played

                    lineWinAmount += LogicMethods.GetVerticalLineMatches(LogicMethods.slotMachineArray, columnLinesToPlay);  // column lines match,+print win lines, and count win lines
                }

                //Diagonal lines check
                if (amountOfLanesPlay > rowAndColumnLines)
                {
                    lineWinAmount += LogicMethods.GetDiagonalLineMatch(LogicMethods.slotMachineArray, amountOfLanesPlay);   //diagonal lines match, and print win lines, + count win lines
                }

                playerBalanceTotal += (lineWinAmount * Constants.WIN_MULTIPLIER * betPerLane);      // calculation of win and add to the balance
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);                                 //print player balance

                if (UIMethods.ContinueGameDecision() == false)                                      //repeat game ?
                {
                    Environment.Exit(0);
                }

            }//end of while loop
        }
    }
}
