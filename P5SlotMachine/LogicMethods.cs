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


    }
}
