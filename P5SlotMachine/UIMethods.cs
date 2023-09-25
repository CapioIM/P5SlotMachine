using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5SlotMachine
{
    internal class UIMethods
    {
        /// <summary>
        /// Ask Player For Number
        /// </summary>
        /// <param name="t"> Enter Question </param>
        /// <returns> returns number 1-999.... or 0 if letter is used </returns>
        public static int AskPlayerForNumber(string t)           // Ask player to enter number
        {
            Console.WriteLine(t);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("You have entered letter ! Please try to enter Number !");
                return 0;
            }
        }

        /// <summary>
        /// Print Win Lane 
        /// </summary>
        /// <param name="line"> which line has won  </param>
        public static void DisplayWin(int line)
        {
            Console.WriteLine($" Win line nr: {line + 1} !");            //output win lane
        }
    }
}
