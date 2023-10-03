using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P5SlotMachine
{
    internal class UIMethods
    {

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
        /// <summary>
        /// Ask Player For Number
        /// </summary>
        /// <param name="AskQuestion"> Enter Question </param>
        /// <returns> returns number 1-999.... or 0 if letter is used </returns>
        public static int GetNumberFromPlayer()           // Get player to enter number
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("You have entered letter or zero ! Please try to enter Number,  !");
                return 0;
            }
        }

        /// <summary>
        /// prints welcome screen
        /// </summary>
        /// <param name="array"> slot machine array name </param>
        /// <param name="diagonal"> enter how many diagonal lines in game </param>
        public static void DisplayWelcomeScreen(int[,] array, int diagonal)
        {
            Console.WriteLine("Hello and Welcome to Slot Machine Game!");
            Console.WriteLine($"" +
                $" Lines: 1-{array.GetLength(0)} Vertical!\n" +
                $" Lines {array.GetLength(0) + 1}-{array.GetLength(0) + array.GetLength(1)} vertical and horizontal!\n" +
                $" Lines {array.GetLength(0) + array.GetLength(1) + 1}-{array.GetLength(0) + array.GetLength(1) + diagonal} vertical, horizontal and diagonal");
            Console.WriteLine();
        }

        /// <summary>
        /// prints player balance
        /// </summary>
        /// <param name="balance"> enter player starting balance </param>
        public static void DisplayPlayerBalance(double balance)
        {
            Console.WriteLine($"Your Balance is {balance} !");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints array numbers to the screen
        /// </summary>
        /// <param name="array"> array variable/name</param>
        /// <param name="rowIndex"> Row Index </param>
        /// <param name="columnIndex"> Column Index </param>
        public static void DisplaySlotNumbers(int[,] array)
        {
            for (int rowIndex = 0; rowIndex < array.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < array.GetLength(1); columnIndex++)
                {
                    Console.Write(array[rowIndex,columnIndex] + " ");
                }
                Console.WriteLine();
            }
        }


        public static void PrintEmptyNewLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Asks Player question, if answer is no game Closes, if yes Continues
        /// </summary>
        /// <returns> returns false if answer N/n , otherwise returns true </returns>
        public static bool ContinueGameDecision()
        {
            DisplayQuestionToPlayer(Questions.ContinueGame);
            if (Console.ReadKey().KeyChar.ToString().ToLower() != "n")
            {
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// prints to the screen diagonal line win 1
        /// </summary>
        public static void PrintDiagonalLineWinOne()
        {
            Console.WriteLine($" Win diagonal line 1 !");
        }

        /// <summary>
        /// prints to the screen diagonal line win 2
        /// </summary>
        public static void PrintDiagonalLineWinTwo()
        {
            Console.WriteLine($" Win diagonal line 2 !");
        }

        /// <summary>
        /// List of questions to ask Player
        /// </summary>
        /// <param name="questionRelevance"></param>
        /// <returns> prints chosen question </returns>
        public static string DisplayQuestionToPlayer(Questions questionRelevance)
        {
            switch (questionRelevance)
            {
                case Questions.HowManyLanes:
                    Console.WriteLine("How many lines would you like to play?");
                    break;
                case Questions.HowMuchBetPerLane:
                    Console.WriteLine("How much would you like to bet per lane?");
                    break;
                case Questions.InsufficientFunds:
                    Console.WriteLine("You have insufficient funds! Please place lower bet!");
                    break;
                case Questions.ContinueGame:
                    Console.WriteLine("Do you want to continue game? Y = Yes , N = No");
                    break;
            }
            return questionRelevance.ToString();
        }
    }
}
