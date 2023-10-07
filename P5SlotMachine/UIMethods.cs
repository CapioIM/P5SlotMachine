namespace P5SlotMachine
{
    internal class UIMethods
    {

        /// <summary>
        /// Ask Player For Number
        /// </summary>
        /// <returns> returns number 1-999.... or 0 if letter is used </returns>
        public static int GetNumberFromPlayer()           // Get player to enter number
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return Math.Abs(result);
                }
                else
                {
                    Console.WriteLine("Invalid number! Try again !");
                }
            }
        }

        /// <summary>
        /// prints welcome screen
        /// </summary>

        public static void DisplayWelcomeScreen()
        {
            Console.WriteLine("Hello and Welcome to Slot Machine Game!");
            Console.WriteLine($"" +
                $" Lines: 1-{Constants.ROW_LINES_IN_GAME} Vertical!\n" +
                $" Lines {Constants.ROW_LINES_IN_GAME + 1}-{LogicMethods.GetRowAndColumnLines()} vertical and horizontal!\n" +
                $" Lines {LogicMethods.GetRowAndColumnLines() + 1}-{LogicMethods.GetMaxPlayableLines()} vertical, horizontal and diagonal");
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

        public static void DisplaySlotNumbers(int[,] array)
        {
            for (int rowIndex = 0; rowIndex < array.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < array.GetLength(1); columnIndex++)
                {
                    Console.Write(array[rowIndex, columnIndex] + " ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Asks Player question, if answer is no game Closes, if yes Continues
        /// </summary>
        /// <returns> returns false if answer N/n , otherwise returns true </returns>
        public static bool ContinueGameDecision()
        {
            DisplayQuestionToPlayer(Enums.Questions.ContinueGame);
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
        public static string DisplayQuestionToPlayer(Enums.Questions questionRelevance)
        {
            switch (questionRelevance)
            {
                case Enums.Questions.HowManyLanes:
                    Console.WriteLine("How many lines would you like to play?");
                    break;
                case Enums.Questions.HowMuchBetPerLane:
                    Console.WriteLine("How much would you like to bet per lane?");
                    break;
                case Enums.Questions.InsufficientFunds:
                    Console.WriteLine("You have insufficient funds! Please place lower bet!");
                    break;
                case Enums.Questions.ContinueGame:
                    Console.WriteLine("Do you want to continue game? Y = Yes , N = No");
                    break;
            }
            return questionRelevance.ToString();
        }
    }
}
