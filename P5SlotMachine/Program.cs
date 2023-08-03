using System.Runtime.CompilerServices;

namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int COLUMNS_LINES_IN_GAME = 3;      // how many vertical lines
        const int ROWS_LINES_IN_GAME = 5;     //how many horizontal lines
        const int DIAGONAL_LINES = 2;
        static void Main(string[] args)
        {
            string[] slotSymbols = { "0" };//, "1", "2", "3", "4", "5", "6", "7", "8", "9", "J" };             // test symbols
            string[,] slotMachineArray = new string[COLUMNS_LINES_IN_GAME, ROWS_LINES_IN_GAME];          //slot machine array size
            int rowAndColumnLines = ROWS_LINES_IN_GAME + COLUMNS_LINES_IN_GAME;                         //rows and column lines amount

            while (true)
            {
                Console.WriteLine("Hello and Welcome to Slot Machine Game!");
                Console.WriteLine($"" +
                    $" Lines: 1-{COLUMNS_LINES_IN_GAME} Vertical!\n" +
                    $" lines {COLUMNS_LINES_IN_GAME+1}-{rowAndColumnLines} vertical and horizontal!\n" +
                    $" lines {rowAndColumnLines+1}-{rowAndColumnLines+DIAGONAL_LINES} vertical, horizontal and diagonal");
                Console.WriteLine("How many lines would you like to play?");
                Console.WriteLine();

                int amountOfLanesPlay = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                int rowMinusOne = ROWS_LINES_IN_GAME - 1;         //loop doesnt run out of array range
                int columnMinusOne = COLUMNS_LINES_IN_GAME - 1;

                for (int columnIndex = 0; columnIndex < COLUMNS_LINES_IN_GAME; columnIndex++)                //fill array with random strings from slotSymbols array
                {
                    for (int rowIndex = 0; rowIndex < ROWS_LINES_IN_GAME; rowIndex++)
                    {
                        int randomIndex = rand.Next(slotSymbols.Length);
                        slotMachineArray[columnIndex, rowIndex] = slotSymbols[randomIndex];
                        Console.Write($"{slotMachineArray[columnIndex, rowIndex]} ");
                    }
                    Console.WriteLine();
                }

                int rowsToPlay = COLUMNS_LINES_IN_GAME;            //run for loop under for amount of times selected
                if (amountOfLanesPlay < COLUMNS_LINES_IN_GAME)
                {
                    rowsToPlay = amountOfLanesPlay;
                }

                int rightLineMatching = 0;                      //horizontal -  line check and win output
                for (int columnIndex = 0; columnIndex < rowsToPlay; columnIndex++)
                {
                    for (int rowIndex = 0; rowIndex < ROWS_LINES_IN_GAME; rowIndex++)
                    {
                        if (rowIndex != rowMinusOne && slotMachineArray[columnIndex, rowIndex] == slotMachineArray[columnIndex, rowIndex + 1])
                        {
                            rightLineMatching++;
                            if (rightLineMatching == rowMinusOne)
                            {
                                Console.WriteLine($"Win - line nr: {columnIndex + 1}");
                            }
                        }
                        else
                        {
                            rightLineMatching = 0;
                            break;
                        }
                    }
                }

                int columnsToPlay = ROWS_LINES_IN_GAME;   //run loop under when amountOfLanesPlay > 3 for amount of times = to width of array
                if (amountOfLanesPlay - COLUMNS_LINES_IN_GAME < ROWS_LINES_IN_GAME)
                {
                    columnsToPlay = amountOfLanesPlay - COLUMNS_LINES_IN_GAME;
                }

                int downLineMatching = 0;              //vertical | line check and win output    
                for (int rowIndex = 0; rowIndex < columnsToPlay; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < COLUMNS_LINES_IN_GAME; columnIndex++)
                    {
                        if (columnIndex != columnMinusOne && slotMachineArray[columnIndex, rowIndex] == slotMachineArray[columnIndex + 1, rowIndex])
                        {
                            downLineMatching++;
                            if (downLineMatching == columnMinusOne)
                            {
                                Console.WriteLine($"Win | line nr: {rowIndex + rowMinusOne}");
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