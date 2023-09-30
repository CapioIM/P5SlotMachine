﻿using System;
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

        public static void DisplayInsufficientFunds()
        {
            Console.WriteLine("You have insufficient funds! Please place lower bet!");
        }

        /// <summary>
        /// Prints array numbers to the screen
        /// </summary>
        /// <param name="array"> array variable/name</param>
        /// <param name="i"> Row Index </param>
        /// <param name="j"> Column Index </param>
        public static void DisplaySlotNumbers(int[,] array, int i, int j)
        {
            Console.Write($"{array[i, j]} ");
        }
        public static void NewLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Asks Player question, if answer is no game Closes, if yes Continues
        /// </summary>
        /// <returns></returns>
        public static bool ContinueGameDecision()
        {
            Console.WriteLine("Do you want to continue game? Y = Yes , N = No");
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

        public static void DisplayWinMessage(int i)
        {
            Console.WriteLine($" Win - line nr: {i + 1} !");            //output win lane
        }
    }
}
