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
                int rightMinusOne = HORIZONTAL_LINES_IN_GAME - 1;         //loop doesnt run out of array range
                int downMinusOne = VERTICAL_LINES_IN_GAME - 1;

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

                int rightLineMatching = 0;               //horizontal -  line check and win output

                int rowsToPlay = VERTICAL_LINES_IN_GAME;
                if (amountOfLanesPlay < HORIZONTAL_LINES_IN_GAME)
                {
                    rowsToPlay = amountOfLanesPlay;
                }

                for (int down = 0; down < rowsToPlay; down++)                  //horizontal lines check/win output
                {
                    for (int right = 0; right < HORIZONTAL_LINES_IN_GAME; right++)
                    {
                        if (right != rightMinusOne && slotMachineArray[down, right] == slotMachineArray[down, right + 1])
                        {
                            rightLineMatching++;
                            if (rightLineMatching == rightMinusOne)
                            {
                                Console.WriteLine($"Win - line nr: {down + 1}");
                            }
                        }
                        else
                        {
                            rightLineMatching = 0;
                            break;
                        }
                    }
                }
                int downLineMatching = 0;              //vertical | line check and win output    
                int columnsToPlay = HORIZONTAL_LINES_IN_GAME;
                if (amountOfLanesPlay - HORIZONTAL_LINES_IN_GAME < VERTICAL_LINES_IN_GAME)
                {
                    columnsToPlay = amountOfLanesPlay - HORIZONTAL_LINES_IN_GAME;
                }

                for (int right = 0; right < columnsToPlay; right++)
                {
                    for (int down = 0; down < VERTICAL_LINES_IN_GAME; down++)
                    {
                        if (down != downMinusOne && slotMachineArray[down, right] == slotMachineArray[down + 1, right])
                        {
                            downLineMatching++;
                            if (downLineMatching == downMinusOne)
                            {
                                Console.WriteLine($"Win | line nr: {right + 1}");
                            }
                        }
                        else
                        {
                            downLineMatching = 0;
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