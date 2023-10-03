using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5SlotMachine
{


    internal class LogicMethods
    {
        /// <summary>
        /// Enum for row and column
        /// </summary>
        public enum RowOrColumn
        {
            Rows,
            Columns,
        }

        public static int[,] slotMachineArray = new int[
                        Constants.ROW_LINES_IN_GAME,
                        Constants.COLUMN_LINES_IN_GAME];

        public static Random rand = new Random();

        /// <summary>
        /// loop to match 2 diagonal lines in array
        /// </summary>
        /// <param name="array"> name of array loop will match through </param>
        /// <param name="playerPlaysLanes"> How many Lanes Player want to play </param>
        /// <returns> Returns amount of matching lanes </returns>
        public static int GetDiagonalLineMatch(int[,] array, int playerPlaysLanes)
        {
            int result = 0;
            if (playerPlaysLanes > Constants.ROW_LINES_IN_GAME + Constants.COLUMN_LINES_IN_GAME)
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
                    if (playerPlaysLanes == Constants.ROW_LINES_IN_GAME + Constants.COLUMN_LINES_IN_GAME + Constants.DIAGONAL_LINES_IN_GAME)  // execute code only when max lanes amount is chosen
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
        /// Fills array with random numbers and displays them
        /// </summary>
        /// <param name="slotMachineArray"> array name to fill with random numbers </param>
        public static void FillArraySlotMachine(int[,] slotMachineArray)
        {
            for (int rowIndex = 0; rowIndex < Constants.ROW_LINES_IN_GAME; rowIndex++)                //fill 2-D array with random num 0-9
            {
                for (int columnIndex = 0; columnIndex < Constants.COLUMN_LINES_IN_GAME; columnIndex++)
                {
                    int randomIndex = rand.Next(0, Constants.MAX_SLOT_NUMBER_OPTIONS);
                    slotMachineArray[rowIndex, columnIndex] = randomIndex;
                }
                UIMethods.PrintEmptyNewLine();
            }
        }

        /// <summary>
        /// Loop to Check matches in rows in Array
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
                result += GetAndDisplayWinLine(check, slotMachineArray, rowIndex, GetLengthRowOrColumn(RowOrColumn.Columns));
            }
            return result;
        }

        /// <summary>
        /// Vertical Line match and win Line Display
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
                result += GetAndDisplayWinLine(check, slotMachineArray, columnIndex, GetLengthRowOrColumn(RowOrColumn.Rows));
            }
            return result;
        }

        /// <summary>
        /// number of matches is same as length of array, display win message and return win lane to pay winnings
        /// </summary>
        /// <param name="matches"> amount of matched chars in line </param>
        /// <param name="array"> array name </param>
        /// <param name="lineMatchingIndex"> Which line is being checked </param>
        /// <param name="getLengthDimension"> GetLength() method dimension 0 - rows , 1 - columns </param>
        /// <returns> Returns amount of win lines </returns>
        public static int GetAndDisplayWinLine(int matches, int[,] array, int lineMatchingIndex, int getLengthDimension)
        {
            int result = 0;
            if (matches == array.GetLength(getLengthDimension))
            {
                result++;
                Console.WriteLine($"$$$ Win line nr: {lineMatchingIndex + 1} ! $$$");
            }
            return result;
        }
        /// <summary>
        /// provides with 0 or 1 for GetLength() method
        /// </summary>
        /// <param name="dimensionChoice"> Row - 0 , Column - 1 </param>
        /// <returns> Number 0 for Row, 1 for Columns </returns>
        public static int GetLengthRowOrColumn(RowOrColumn dimensionChoice)
        {
            int result = 0;
            if (dimensionChoice == RowOrColumn.Rows)
            {
                result = 0;
            }
            if (dimensionChoice == RowOrColumn.Columns)
            {
                result = 1;
            }
            return result;
        }

    }
}
