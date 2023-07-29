namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int HORIZONTAL = 3;     //how many horizontal lines
        const int VERTICAL = 3;      // how many vertical lines
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome to Slot Machine Game!");
            string[] slotSymbols = { "0", "1" };//, "2", "3", "4", "5", "6", "7", "8", "9", "J" };
            string[,] slotMachineArray = new string[HORIZONTAL, VERTICAL];

            while (true)
            {
                Console.WriteLine();
                //fill array with random strings from slotSymbols array
                for (int i = 0; i < HORIZONTAL; i++)
                {
                    for (int c = 0; c < VERTICAL; c++)
                    {
                        int randomIndex = rand.Next(slotSymbols.Length);
                        slotMachineArray[i, c] = slotSymbols[randomIndex];
                        Console.Write($"{slotMachineArray[i, c]} ");
                    }
                    Console.WriteLine();

                }
                if (slotMachineArray[1, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 0] == slotMachineArray[1, 2])
                {
                    Console.WriteLine("Win");
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