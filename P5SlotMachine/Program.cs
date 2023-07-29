namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int VERTICAL = 3;      // how many vertical lines
        const int HORIZONTAL = 3;     //how many horizontal lines
        static void Main(string[] args)
        {
            string[] slotSymbols = { "0", "1" };//, "2", "3", "4", "5", "6", "7", "8", "9", "J" };
            string[,] slotMachineArray = new string[VERTICAL, HORIZONTAL];

            while (true)
            {
                Console.WriteLine("Hello and Welcome to Slot Machine Game!");
                Console.WriteLine();
                //fill array with random strings from slotSymbols array
                for (int i = 0; i < VERTICAL; i++)
                {
                    for (int c = 0; c < HORIZONTAL; c++)
                    {
                        int randomIndex = rand.Next(slotSymbols.Length);
                        slotMachineArray[i, c] = slotSymbols[randomIndex];
                        Console.Write($"{slotMachineArray[i, c]} ");
                    }
                    Console.WriteLine();
                }

                // Check for vertical lines
                int horizontalMinutsOne = HORIZONTAL - 1;
                int verticalMinutOne = VERTICAL - 1;
                for (int i = 0; i < VERTICAL; i++)
                {
                    int verticalMatchCount = 0;
                    for (int c = 0; c < HORIZONTAL; c++)
                    {
                        if (c + 1 != HORIZONTAL)
                        {
                            if (slotMachineArray[i, c] == slotMachineArray[i, c + 1])
                            {
                                verticalMatchCount++;
                                if (verticalMatchCount == horizontalMinutsOne)
                                {
                                    Console.Write($"Win horizontal line {i + 1}\n");
                                }
                            }
                            else
                            {
                                verticalMatchCount = 0;
                                break;
                            }
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