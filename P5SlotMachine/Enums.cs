using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5SlotMachine
{
    internal class Enums
    {
        /// <summary>
        /// Enum for rows and columns, Rows = 0 , Columns = 1
        /// </summary>
        public enum RowOrColumn
        {
            Rows = 0,
            Columns = 1
        }


        /// <summary>
        /// Enum with short Question discription
        /// </summary>
        public enum Questions
        {
            HowManyLanes,
            HowMuchBetPerLane,
            InsufficientFunds,
            ContinueGame
        }

    }
}
