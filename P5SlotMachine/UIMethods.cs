namespace P5SlotMachine
{
    internal class UIMethods
    {

        /// <summary>
        /// Ask Player For Number and torturte untill number is entered
        /// </summary>
        /// <returns> returns positive number </returns>
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
        /// Enter number/get number
        /// </summary>
        /// <returns> int positive 0 - GetMaxPlayableLines </returns>
        public static int GetAmountOfLinesFromPlayer()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result > LogicMethods.GetMaxPlayableLines())
                    {
                        result = LogicMethods.GetMaxPlayableLines();
                    }
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
                $" Lines {Constants.ROW_LINES_IN_GAME + 1}-{LogicMethods.GetRowAndColumnLines()} Vertical and Horizontal!\n" +
                $" Lines {LogicMethods.GetRowAndColumnLines() + 1}-{LogicMethods.GetMaxPlayableLines()} Vertical, Horizontal and Diagonal");
            Console.WriteLine();
        }

        /// <summary>
        /// prints player balance
        /// </summary>
        /// <param name="balance"> enter player starting balance (double) </param>
        public static void DisplayPlayerBalance(double balance)
        {
            Console.WriteLine($"Your Balance is $ {balance} !");
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
                    Console.Write(" " + array[rowIndex, columnIndex]);
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
            DisplayQuestionToPlayer(Enums.QuestionsText.ContinueGame);
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
        public static string DisplayQuestionToPlayer(Enums.QuestionsText questionRelevance)
        {
            switch (questionRelevance)
            {
                case Enums.QuestionsText.HowManyLanes:
                    Console.Write("How many lines would you like to play? : ");
                    break;
                case Enums.QuestionsText.HowMuchBetPerLane:
                    Console.Write("How much would you like to bet per lane? : $ ");
                    break;
                case Enums.QuestionsText.InsufficientFunds:
                    Console.WriteLine("You have insufficient funds! Please place lower bet!");
                    break;
                case Enums.QuestionsText.ContinueGame:
                    Console.WriteLine("Do you want to continue game? Y = Yes , N = No");
                    break;
            }
            return questionRelevance.ToString();
        }
    }
}
