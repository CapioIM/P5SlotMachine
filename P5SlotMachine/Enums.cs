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
        /// Enum for row and column
        /// </summary>
        public enum RowOrColumn
        {
            Rows,
            Columns,
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
