﻿using System;
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
        /// <param name="HowManyColumnsInArray"> array width amount to provide accurate line match </param>
        /// <param name="rowLinesPlayCounter"> how many lanes are playing </param>
        /// <returns> amount of matched lanes </returns>
        public static int RowArrayLoop(int[,] array, int HowManyColumnsInArray, int rowLinesPlayCounter)
        {
            int result = 0;
            for (int i = 0; i < rowLinesPlayCounter; i++)
            {
                int store = array[i, 0];
                int Check = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (store == array[i, j])
                    {
                        Check++;
                    }
                }
                if (Check == HowManyColumnsInArray)
                {
                    result++;
                    Console.WriteLine($" Win - line nr: {i + 1} !");            //output win lane
                }
            }
            return result;
        }

    }
}
