namespace P5SlotMachine
{
    internal class LogicMethods
    {

        /// <summary>
        /// Get sum of row and column constants
        /// </summary>
        /// <returns> int sum of row and column</returns>
        public static int GetRowAndColumnLines()
        {
            int result =
                Constants.ROW_LINES_IN_GAME +
                Constants.COLUMN_LINES_IN_GAME;
            return result;
        }

        /// <summary>
        /// Sum of rows,columns and diagonal constants
        /// </summary>
        /// <returns> Sum of rows,columns and diagonal lines </returns>
        public static int GetMaxPlayableLines()
        {
            int result =
                Constants.ROW_LINES_IN_GAME +
                Constants.COLUMN_LINES_IN_GAME +
                Constants.DIAGONAL_LINES_IN_GAME;
            return result;
        }

        /// <summary>
        /// Compare total bet to the balance
        /// </summary>
        /// <param name="balance"> Player balance to check against other parameteres </param>
        /// <param name="linesPlays"> how many lines were chosen to play </param>
        /// <param name="betPerLane"> What is bet per lane </param>
        /// <param name="message"> returns false when balance is more than multiplier of other parametres </param>
        /// <returns></returns>
        public static bool GetEnoughBalance(double balance, int linesPlays, double betPerLane, Enums.Questions message)
        {
            if (balance < linesPlays * betPerLane)                   // balance has to be greater than bet * lanes
            {
                UIMethods.DisplayQuestionToPlayer(message);          // Display quiestion 
            }
            else                                                     // insufficient balance
            {
                return false;                                       
            }
            return true;
        }

        /// <summary>
        /// loop to match 2 diagonal lines in array
        /// </summary>
        /// <param name="array"> name of array, loop will match through </param>
        /// <param name="playerPlaysLanes"> How many Lanes Player want to play </param>
        /// <returns> Returns amount of matching lanes </returns>
        public static int GetDiagonalLineMatch(int[,] array, int playerPlaysLanes)
        {
            int result = 0;
            if (playerPlaysLanes > GetRowAndColumnLines())
            {
                int diagonalCharStoreOne = array[0, 0];
                int diagonalOneMatch = 0;
                int diagonalCharStoreTwo = array[0, Constants.DIAGONAL_LINE_LENGTH - 1];
                int diagonalTwoMatch = 0;
                int diagonalColumn = Constants.DIAGONAL_LINE_LENGTH - 1;
                for (int diagonal = 0; diagonal < Constants.DIAGONAL_LINE_LENGTH; diagonal++)
                {
                    if (diagonalCharStoreOne == array[diagonal, diagonal])
                    {
                        diagonalOneMatch++;
                    }
                    if (playerPlaysLanes == GetMaxPlayableLines())  // execute code only when max lanes amount is chosen
                    {
                        if (diagonalCharStoreTwo == array[diagonal, diagonalColumn - diagonal])
                        {
                            diagonalTwoMatch++;
                        }
                    }
                }
                if (diagonalOneMatch == Constants.DIAGONAL_LINE_LENGTH)
                {
                    result++;
                    UIMethods.PrintDiagonalLineWinOne();
                }
                if (diagonalTwoMatch == Constants.DIAGONAL_LINE_LENGTH)
                {
                    result++;
                    UIMethods.PrintDiagonalLineWinTwo();
                }
            }
            return result;
        }

        /// <summary>
        /// Fills 2D array with random numbers and returns to Array
        /// </summary>
        /// <returns> Array with Numbers </returns>
        public static int[,] ReturnFilledArray()
        {
            Random rand = new Random();
            int[,] slotMachineArray = new int[
                        Constants.ROW_LINES_IN_GAME,
                        Constants.COLUMN_LINES_IN_GAME];
            for (int rowIndex = 0; rowIndex < Constants.ROW_LINES_IN_GAME; rowIndex++)                //fill 2-D array with random num 0-9
            {
                for (int columnIndex = 0; columnIndex < Constants.COLUMN_LINES_IN_GAME; columnIndex++)
                {
                    int randomIndex = rand.Next(0, Constants.MAX_SLOT_NUMBER_OPTIONS + 1);
                    slotMachineArray[rowIndex, columnIndex] = randomIndex;
                }
            }
            return slotMachineArray;
        }

        /// <summary>
        /// Loop to Check matches of rows in Array and display line nr
        /// </summary>
        /// <param name="array"> Array Name ? </param>
        /// <param name="linesPlayCounter"> specific dimension,amount of lanes playing </param>
        /// <returns> amount of matched lanes </returns>
        public static int GetHorizontalLineMatches(int[,] array, int linesPlayCounter)
        {
            int result = 0;
            for (int rowIndex = 0; rowIndex < linesPlayCounter; rowIndex++)
            {
                int store = array[rowIndex, rowIndex];
                int check = 0;
                for (int columnIndex = 0; columnIndex < array.GetLength(1); columnIndex++)
                {
                    if (store == array[rowIndex, columnIndex])
                    {
                        check++;
                    }
                }
                // check if whole lane match , display win lane, increments win moneys
                result += GetAndDisplayWinLine(check, rowIndex, Constants.COLUMN_LINES_IN_GAME);
            }
            return result;
        }

        /// <summary>
        /// Loop to Check matches of columns in Array and display line nr
        /// </summary>
        /// <param name="array"> Enter Array name </param>
        /// <param name="linesPlayCounter"> specific dimension,amount of lanes playing </param>
        /// <returns> Int of matched Lanes </returns>
        public static int GetVerticalLineMatches(int[,] array, int linesPlayCounter)
        {
            int result = 0;
            for (int columnIndex = 0; columnIndex < linesPlayCounter; columnIndex++)
            {
                int store = array[columnIndex, columnIndex];
                int check = 0;
                for (int rowIndex = 0; rowIndex < array.GetLength(0); rowIndex++)
                {
                    if (store == array[rowIndex, columnIndex])
                    {
                        check++;
                    }
                }
                // check if whole lane match , display win lane, increments win moneys
                result += GetAndDisplayWinLine(check, columnIndex, Constants.ROW_LINES_IN_GAME);
            }
            return result;
        }

        /// <summary>
        /// number of matches is same as Dimension lenght of chars, display win message and return win lane to pay winnings
        /// </summary>
        /// <param name="matches"> amount of matched chars in line </param>
        /// <param name="lineMatchingIndex"> Displays which lane wins </param>
        /// <param name="dimensionLinesInGameLength"> amount of checked value has to match length of line characters/this int/number </param>
        /// <returns> Returns amount of win lines </returns>
        public static int GetAndDisplayWinLine(int matches, int lineMatchingIndex, int dimensionLinesInGameLength)
        {
            int result = 0;
            if (matches == dimensionLinesInGameLength)
            {
                result++;
                Console.WriteLine($"$$$ Win line nr: {lineMatchingIndex + 1} ! $$$");
            }
            return result;
        }
    }
}
