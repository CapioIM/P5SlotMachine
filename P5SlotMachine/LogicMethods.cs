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
/// Loop for Slot Machine
/// </summary>
/// <param name="howManyLines"> Amount of Rows/column lines to loop through </param>
/// <param name="howLongLinesAre"> Length of line </param>
/// <param name="charToCheckAgainst"> Which character to check against </param>
/// <param name="slots"> 2D array </param>
/// <param name="result"> How many char matches </param>
/// <returns> returns matches  </returns>
/// <exception cref="NotImplementedException"></exception>
        public static int SlotMachineIndexLoop(int howManyLines, int howLongLinesAre, int[,] slots, int result)
        {
            for (int i = 0; i < howManyLines; i++)
            {
                int charToCheckAgainst = slots[0, 0];
                for (int j = 0; j < howLongLinesAre; j++)
                {
                    if (slots[i, j] == charToCheckAgainst)
                    {
                        result++;
                    }
                }
            }
            return result;

            throw new NotImplementedException();
        }

        /// <summary>
        /// Character Match
        /// </summary>
        /// <param name="CharMatch"> Whats the character to be matched</param>
        /// <param name="LinesToMatch"> How many matches should be / how long is line </param>
        /// <param name="lineWinAmount"> win win </param>
        /// <returns> how many lines win </returns>
        public static int CharMatch(int CharMatch, int LinesToMatch)
        {
            int lineWinAmount = 0;
            if (CharMatch == LinesToMatch)                   // amount of chars matched has to equal to length of row
            {
               lineWinAmount++;
            }
            return lineWinAmount;
        }


    }
}
