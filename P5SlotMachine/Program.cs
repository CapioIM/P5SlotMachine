namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int VERTICAL_LINES_IN_GAME = 3;      // how many vertical lines
        const int HORIZONTAL_LINES_IN_GAME = 3;     //how many horizontal lines
        static void Main(string[] args)
        {
            string[] slotSymbols = { "0" };//, "1", "2", "3", "4", "5", "6", "7", "8", "9", "J" };             // test symbols
            string[,] slotMachineArray = new string[VERTICAL_LINES_IN_GAME, HORIZONTAL_LINES_IN_GAME];          //slot machine array size

            while (true)
            {
                Console.WriteLine("Hello and Welcome to Slot Machine Game!");
                Console.WriteLine("Lines: 1-3 Vertical!\n Lines 4-6 vertical and horizontal!\n lines 7-8 vertical, horizontal and diagonal");
                Console.WriteLine("How many lines would you like to play?");
                Console.WriteLine();

                int amountOfLanesPlay = Convert.ToInt32(Console.ReadLine());
                int horizontalMinusOne = HORIZONTAL_LINES_IN_GAME - 1;         //loop doesnt run out of array range
                int verticalMinusOne = VERTICAL_LINES_IN_GAME - 1;

                for (int down = 0; down < VERTICAL_LINES_IN_GAME; down++)                //fill array with random strings from slotSymbols array
                {
                    for (int right = 0; right < HORIZONTAL_LINES_IN_GAME; right++)
                    {
                        int randomIndex = rand.Next(slotSymbols.Length);
                        slotMachineArray[down, right] = slotSymbols[randomIndex];
                        Console.Write($"{slotMachineArray[down, right]} ");
                    }
                    Console.WriteLine();
                }

                int horizontalLineMatching = 0;               //horizontal -  line check and win output

                for (int down = 0; down < VERTICAL_LINES_IN_GAME; down++)
                {
                    for (int right = 0; right < HORIZONTAL_LINES_IN_GAME; right++)
                    {
                        //horizontal lines check/win output
                        if (amountOfLanesPlay >down && right != horizontalMinusOne && slotMachineArray[down, right] == slotMachineArray[down, right + 1])
                        {
                            horizontalLineMatching++;
                            if (horizontalLineMatching == horizontalMinusOne)
                            {
                                Console.WriteLine($"Win - line nr: {down + 1}");
                            }
                        }
                        else
                        {
                            horizontalLineMatching = 0;
                            break;
                        }
                    }
                }
                int verticalLineMatching = 0;              //vertical | line check and win output    
                for (int right = 0; right < HORIZONTAL_LINES_IN_GAME; right++)
                {
                    for (int down = 0; down < VERTICAL_LINES_IN_GAME; down++)
                    {
                        if (amountOfLanesPlay - VERTICAL_LINES_IN_GAME > right && down != verticalMinusOne && slotMachineArray[down, right] == slotMachineArray[down + 1, right])
                        {
                            verticalLineMatching++;
                            if (verticalLineMatching == verticalMinusOne)
                            {
                                Console.WriteLine($"Win | line nr: {right +1}");
                            }
                        }
                        else
                        {
                            verticalLineMatching = 0;
                            break;
                        }
                    }
                }

                Console.WriteLine("If want to play again press Y");
                string playAgain = Console.ReadKey().KeyChar.ToString().ToLower();

                Console.Clear();
                if (playAgain != "y")
                {
                    break;
                }

            }//end of while loop
        }
    }
}