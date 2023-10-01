using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5SlotMachine
{


    internal class LogicMethods
    {

        public static Random rand = new Random();
        public const int ROW_LINES_IN_GAME = 3;      // how many vertical lines
        public const int COLUMN_LINES_IN_GAME = 3;     //how many horizontal lines
        public const int DIAGONAL_LINES_IN_GAME = 2;   // how many diagonal lines
        public const int DIAGONAL_LINE_LENGTH = 3;     //length of diagonal line
        public const int PLAYER_STARTING_BALANCE = 50;   // player starting balance
        public const double WIN_MULTIPLIER = 10;        //win multiplier

        /// <summary>
        /// loop to match 2 diagonal lines in array
        /// </summary>
        /// <param name="array"> name of array loop will match through </param>
        /// <param name="PlayerPlaysLanes"> How many Lanes Player want to play </param>
        /// <returns> Returns amount of matching lanes </returns>
        public static int GetDiagonalLineMatch(int[,] array, int PlayerPlaysLanes)
        {
            int result = 0;
            if (PlayerPlaysLanes > ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME)
            {
                int diagonalCharStoreOne = array[0, 0];
                int diagonalOneMatch = 0;
                int diagonalCharStoreTwo = array[0, DIAGONAL_LINE_LENGTH - 1];
                int diagonalTwoMatch = 0;
                int diagonalColumn = DIAGONAL_LINE_LENGTH - 1;

                for (int diagonal = 0; diagonal < DIAGONAL_LINE_LENGTH; diagonal++)
                {
                    if (diagonalCharStoreOne == array[diagonal, diagonal])
                    {
                        diagonalOneMatch++;
                    }
                    if (PlayerPlaysLanes == ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME)
                    {
                        if (diagonalCharStoreTwo == array[diagonal, diagonalColumn - diagonal])
                        {
                            diagonalTwoMatch++;
                        }
                    }
                }
                if (diagonalOneMatch == DIAGONAL_LINE_LENGTH)
                {
                    result++;
                    UIMethods.PrintDiagonalLineWinOne();
                }
                if (diagonalTwoMatch == DIAGONAL_LINE_LENGTH)
                {
                    result++;
                    UIMethods.PrintDiagonalLineWinTwo();
                }
            }
            return result;
        }


        public static void PrintSlotMachine(int[,] slotMachineArray)
        {
            for (int rowIndex = 0; rowIndex < ROW_LINES_IN_GAME; rowIndex++)                //fill 2-D array with random num 0-9
            {
                for (int columnIndex = 0; columnIndex < COLUMN_LINES_IN_GAME; columnIndex++)
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
        /// <param name="LinesPlayCounter"> specific dimension lanes playing </param>
        /// <returns> amount of matched lanes </returns>
        public static int GetHorizontalLineMatches(int[,] array, int LinesPlayCounter)
        {
            int result = 0;
            for (int RowIndex = 0; RowIndex < LinesPlayCounter; RowIndex++)
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
        /// <param name="LinesPlayCounter"> Loop iteretion Amount </param>
        /// <returns> Int of matched Lanes </returns>
        public static int GetVerticalLineMatches(int[,] array, int LinesPlayCounter)
        {
            int result = 0;
            for (int ColumnIndex = 0; ColumnIndex < LinesPlayCounter; ColumnIndex++)
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
