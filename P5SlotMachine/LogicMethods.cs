using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5SlotMachine
{


    internal class LogicMethods
    {
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


        public static void PrintSlotMachine(int[,] slotMachineArray)
        {
            for (int rowIndex = 0; rowIndex < Constants.ROW_LINES_IN_GAME; rowIndex++)                //fill 2-D array with random num 0-9
            {
                for (int columnIndex = 0; columnIndex < Constants.COLUMN_LINES_IN_GAME; columnIndex++)
                {
                    int randomIndex = rand.Next(0, 2);
                    slotMachineArray[rowIndex, columnIndex] = randomIndex;
                    UIMethods.DisplaySlotNumbers(slotMachineArray, rowIndex, columnIndex);      // print slot machine results to the screen
                }
                UIMethods.PrintEmptyNewLine();
            }
        }


        /// <summary>
        /// Loop to Check matches in rows in Array
        /// </summary>
        /// <param name="array"> Array Name ? </param>
        /// <param name="linesPlayCounter"> specific dimension lanes playing </param>
        /// <returns> amount of matched lanes </returns>
        public static int GetHorizontalLineMatches(int[,] array, int linesPlayCounter)
        {
            int result = 0;
            for (int RowIndex = 0; RowIndex < linesPlayCounter; RowIndex++)
            {
                int store = array[RowIndex, RowIndex];
                int CheckRow = 0;

                for (int ColumnIndex = 0; ColumnIndex < array.GetLength(1); ColumnIndex++)
                {

                    if (store == array[RowIndex, ColumnIndex])
                    {
                        CheckRow++;
                    }

                }

                if (CheckRow == array.GetLength(1))
                {
                    result++;
                    Console.WriteLine($" Win - line nr: {RowIndex + 1} !");
                }
            }
            return result;
        }

        /// <summary>
        /// Vertical Line match and win Line Display
        /// </summary>
        /// <param name="array"> Enter Array </param>
        /// <param name="linesPlayCounter"> Loop iteretion Amount </param>
        /// <returns> Int of matched Lanes </returns>
        public static int GetVerticalLineMatches(int[,] array, int linesPlayCounter)
        {
            int result = 0;
            for (int ColumnIndex = 0; ColumnIndex < linesPlayCounter; ColumnIndex++)
            {
                int store = array[ColumnIndex, ColumnIndex];
                int Check = 0;

                for (int RowIndex = 0; RowIndex < array.GetLength(0); RowIndex++)
                {
                    if (store == array[RowIndex, ColumnIndex])
                    {
                        Check++;
                    }
                }
                if (Check == array.GetLength(0))
                {
                    result++;
                    Console.WriteLine($" Win | line nr: {ColumnIndex + 1} !");
                }
            }
            return result;
        }
    }
}
