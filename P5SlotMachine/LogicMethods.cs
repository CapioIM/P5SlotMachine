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
        /// Character Match
        /// </summary>
        /// <param name="CharMatch"> nter how many matches ,variable</param>
        /// <param name="LenghtOfMatch"> int how long is line  </param>
        /// <returns> how many lines win </returns>
        public static int CharMatch(int CharMatch, int LenghtOfMatch)
        {
            int lineWinAmount = 0;
            if (CharMatch == LenghtOfMatch)         // amount of chars matched has to equal to length of row/Column
            {
                lineWinAmount++;
            }
            return lineWinAmount;
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
                    Console.WriteLine($" Win - line nr: {ColumnIndex + 1} !");
                }
            }
            return result;
        }


    }
}
