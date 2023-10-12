namespace P5SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerBalanceTotal = Constants.PLAYER_STARTING_BALANCE;
            int amountOfLanesPlay = 0;

            while (playerBalanceTotal > 0)
            {
                int[,] slotMachineArray = LogicMethods.ReturnFilledArray();  //fill 2D array 
                // Game starting text
                UIMethods.DisplayWelcomeScreen();
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);

                int betPerLane = 0;
                bool sufficientBetFunds = true;
                while (sufficientBetFunds)  // loop for bet as long as there is enough of balance program continues
                {
                    UIMethods.DisplayQuestionToPlayer(QuestionTexts.QuestionsText.HowManyLanes); //Display/print question
                    amountOfLanesPlay = UIMethods.GetAmountOfLinesFromPlayer();     // int how many lanes to play

                    UIMethods.DisplayQuestionToPlayer(QuestionTexts.QuestionsText.HowMuchBetPerLane);  // display question Bet amount per lane
                    betPerLane = UIMethods.GetNumberFromPlayer();                               //int bet per lane

                    sufficientBetFunds = LogicMethods.GetEnoughBalance(playerBalanceTotal, amountOfLanesPlay, betPerLane, QuestionTexts.QuestionsText.InsufficientFunds);            //if enough balance program continues
                }

                playerBalanceTotal -= amountOfLanesPlay * betPerLane;   //deduct bet from balance
                UIMethods.DisplaySlotNumbers(slotMachineArray);        //Display Array/ slot machine values
                int lineWinAmount = 0;                                // for amount of won lanes

                //rows
                int rowsToPlay = Math.Min(amountOfLanesPlay, Constants.ROW_LINES_IN_GAME); // how many row lines should be checked/played
                lineWinAmount += LogicMethods.GetHorizontalLineMatches(slotMachineArray, rowsToPlay);  // row lines match,+print win lines, and count win lines

                //columns
                if (amountOfLanesPlay > Constants.ROW_LINES_IN_GAME)      // if columns are playable 
                {
                    int columnLinesToPlay = Math.Min(                   // set variable with min amount out of 2 numbers 
                        Constants.COLUMN_LINES_IN_GAME,                         
                        amountOfLanesPlay - Constants.ROW_LINES_IN_GAME);      // for how many column lines should be checked/played

                    lineWinAmount += LogicMethods.GetVerticalLineMatches(slotMachineArray, columnLinesToPlay);  // column lines match,+print win lines, and count win lines
                }

                //Diagonal lines check
                if (amountOfLanesPlay > LogicMethods.GetRowAndColumnLines())  // check if number is higher than sum of row and column int's
                {
                    lineWinAmount += LogicMethods.GetDiagonalLineMatch(slotMachineArray, amountOfLanesPlay);   //diagonal lines match, and print win lines, + count win lines
                }

                playerBalanceTotal += (lineWinAmount * Constants.WIN_MULTIPLIER * betPerLane);      // calculation of win and add to the balance
                UIMethods.DisplayPlayerBalance(playerBalanceTotal);                                 //print player balance

                if (UIMethods.ContinueGameDecision() == false)                                      //repeat game ?
                {
                    Environment.Exit(0);
                }
            }//end of while/game loop
        }
    }
}
