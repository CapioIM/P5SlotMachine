namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int VERTICAL_LINES_IN_GAME = 3;      // how many vertical lines
        const int HORIZONTAL_LINES_IN_GAME = 3;     //how many horizontal lines
        static void Main(string[] args)
        {
            string[] slotSymbols = { "0" };//, "1", "2", "3", "4", "5", "6", "7", "8", "9", "J" };
            string[,] slotMachineArray = new string[VERTICAL_LINES_IN_GAME, HORIZONTAL_LINES_IN_GAME];

            while (true)
            {
                Console.WriteLine("Hello and Welcome to Slot Machine Game!");
                Console.WriteLine("Lines: 1-3 Vertical!\n Lines 4-6 vertical and horizontal!\n lines 7-8 vertical, horizontal and diagonal");
                Console.WriteLine("How many lines would you like to play?");
                Console.WriteLine();

                int amountOfLanesPlay = Convert.ToInt32(Console.ReadLine());
                int horizontalMinutsOne = HORIZONTAL_LINES_IN_GAME - 1;         //loop doesnt run out of array range
                int verticalMinutOne = VERTICAL_LINES_IN_GAME - 1;

                for (int i = 0; i < VERTICAL_LINES_IN_GAME; i++)                //fill array with random strings from slotSymbols array
                {
                    for (int c = 0; c < HORIZONTAL_LINES_IN_GAME; c++)
                    {
                        int randomIndex = rand.Next(slotSymbols.Length);
                        slotMachineArray[i, c] = slotSymbols[randomIndex];
                        Console.Write($"{slotMachineArray[i, c]} ");
                    }
                    Console.WriteLine();
                }

                int horizontalLineMatching = 0;               //horizontal -  line check and win output
                int verticalLineMatching = 0;              //vertical | line check and win output    

                for (int i = 0; i < VERTICAL_LINES_IN_GAME; i++)
                {
                    for (int c = 0; c < HORIZONTAL_LINES_IN_GAME; c++)
                    {
                        if (amountOfLanesPlay > i && c != horizontalMinutsOne && slotMachineArray[i, c] == slotMachineArray[i, c + 1])
                        {
                            horizontalLineMatching++;
                            if (horizontalLineMatching == verticalMinutOne)
                            {
                                Console.WriteLine($"Win line nr: {i + 1}");
                            }
                        }
                        if (amountOfLanesPlay > HORIZONTAL_LINES_IN_GAME)
                        {
                            if (amountOfLanesPlay - HORIZONTAL_LINES_IN_GAME > c && i != verticalMinutOne && slotMachineArray[i, c] == slotMachineArray[i + 1, c])
                            {
                                verticalLineMatching++;
                                if (verticalLineMatching == verticalMinutOne)
                                {
                                    Console.WriteLine($"Win vertical line nr: {i + 1}");
                                }
                            }
                        }
                    }
                    verticalLineMatching = 0;
                    horizontalLineMatching = 0;
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