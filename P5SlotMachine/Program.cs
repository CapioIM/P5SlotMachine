using System.Runtime.CompilerServices;
using System.Transactions;

namespace P5SlotMachine
{
    internal class Program
    {
        static Random rand = new Random();
        const int ROW_LINES_IN_GAME = 3;      // how many vertical lines
        const int COLUMN_LINES_IN_GAME = 3;     //how many horizontal lines
        const int DIAGONAL_LINES_IN_GAME = 2;   // how many diagonal lines
        const int PLAYER_STARTING_BALANCE = 50;
        static void Main(string[] args)
        {
            int[] slotSymbols = { 0 };//, 1, 2, 3, 4, 5, 6, 7, 8, 9};             // test symbols
            int[,] slotMachineArray = new int[ROW_LINES_IN_GAME, COLUMN_LINES_IN_GAME];          //slot machine array size
            int rowAndColumnLines = COLUMN_LINES_IN_GAME + ROW_LINES_IN_GAME;                         //rows and column lines amount
            double playerBalance = PLAYER_STARTING_BALANCE;
            int amountOfLanesPlay = 0;
            double betPerLane = 0;

            while (true)
            {
                Console.WriteLine("Hello and Welcome to Slot Machine Game!");
                Console.WriteLine($"" +
                    $" Lines: 1-{ROW_LINES_IN_GAME} Vertical!\n" +
                    $" Lines {ROW_LINES_IN_GAME + 1}-{rowAndColumnLines} vertical and horizontal!\n" +
                    $" Lines {rowAndColumnLines + 1}-{rowAndColumnLines + DIAGONAL_LINES_IN_GAME} vertical, horizontal and diagonal");
                Console.WriteLine();
                Console.WriteLine($"Your Balance is {playerBalance} !");
                Console.WriteLine();
                while (true)  // loop for bet as long as there is enough of balance program continues
                {
                    Console.WriteLine("How many lines would you like to play?");
                    Console.WriteLine();
                    amountOfLanesPlay = Convert.ToInt32(Console.ReadLine());                                    //enter how many lanes to play
                    if (amountOfLanesPlay > ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME)  // amountOfLanesPlay cannot be more than max amount of lanes to play
                    {
                        amountOfLanesPlay = ROW_LINES_IN_GAME + COLUMN_LINES_IN_GAME + DIAGONAL_LINES_IN_GAME;
                    }

                    Console.WriteLine("How much would you like to bet per lane?");
                    betPerLane = Convert.ToInt32(Console.ReadLine());                                           //enter bet per lane
                    if (playerBalance < amountOfLanesPlay * betPerLane)                                         // balance has to be greater than bet * lanes
                    {
                        Console.WriteLine("You have insufficient funds! Please place lower bet!");
                    }
                    else                                                                                        // continue program if bet amount is less than money balance 
                    {
                        break;
                    }

                }
                Console.WriteLine();

                int columnMinusOne = COLUMN_LINES_IN_GAME - 1;         //loop doesnt run out of array range
                int rowMinusOne = ROW_LINES_IN_GAME - 1;                //loop doesnt run out of array range
              //  double winAmount = 0;

                for (int rowIndex = 0; rowIndex < ROW_LINES_IN_GAME; rowIndex++)                //fill array with random strings from slotSymbols array
                {
                    for (int columnIndex = 0; columnIndex < COLUMN_LINES_IN_GAME; columnIndex++)
                    {
                        int randomIndex = rand.Next(slotSymbols.Length);
                        slotMachineArray[rowIndex, columnIndex] = slotSymbols[randomIndex];
                        Console.Write($"{slotMachineArray[rowIndex, columnIndex]} ");
                    }
                    Console.WriteLine();
                }

                int rowsToPlay = ROW_LINES_IN_GAME;            //run for loop under for amount of times selected
                if (amountOfLanesPlay < ROW_LINES_IN_GAME)
                {
                    rowsToPlay = amountOfLanesPlay;
                }

                int rightLineMatching = 0;                      //horizontal -  line check and win output
                /*
                for (int rowIndex = 0; rowIndex < rowsToPlay; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex <= columnMinusOne; columnIndex++)
                    {
                        if (columnIndex != columnMinusOne && slotMachineArray[rowIndex, columnIndex] == slotMachineArray[rowIndex, columnIndex + 1])
                        {
                            rightLineMatching++;
                            if (rightLineMatching == columnMinusOne)
                            {

                                Console.WriteLine($"Win - line nr: {rowIndex + 1}"); 
                                //if (slotMachineArray[])
                            }
                        }
                        else
                        {
                            rightLineMatching = 0;
                            break;
                        }
                    }
                }
*/
                int rowCharCheck = 0;
                int rowLineMatch = 0;
                for (int rowIndex = 0; rowIndex < rowsToPlay; rowIndex++)
                {
                    rowCharCheck = slotMachineArray[rowIndex, 0];
                    int slotsMatched = 0;
                    for(int columnIndex = 0; columnIndex < COLUMN_LINES_IN_GAME;columnIndex++)
                    {
                        if (rowCharCheck == slotMachineArray[rowIndex, columnIndex])
                        {
                            slotsMatched++;
                            if (slotsMatched == columnMinusOne)
                            {
                                Console.WriteLine($"Win - line nr: {rowIndex + 1}");
                            }
                        }

                    }
                }


                int columnsToPlay = COLUMN_LINES_IN_GAME;   //run loop under when amountOfLanesPlay > 3 for amount of times = to width of array
                if (amountOfLanesPlay - ROW_LINES_IN_GAME < COLUMN_LINES_IN_GAME)
                {
                    columnsToPlay = amountOfLanesPlay - ROW_LINES_IN_GAME;
                }

                int downLineMatching = 0;              //vertical | line check and win output    
                for (int columnIndex = 0; columnIndex < columnsToPlay; columnIndex++)
                {
                    for (int rowIndex = 0; rowIndex < ROW_LINES_IN_GAME; rowIndex++)
                    {
                        if (rowIndex != rowMinusOne && slotMachineArray[rowIndex, columnIndex] == slotMachineArray[rowIndex + 1, columnIndex])
                        {
                            downLineMatching++;
                            if (downLineMatching == rowMinusOne)
                            {
                                Console.WriteLine($"Win | line nr: {columnIndex + 1}");
                            }
                        }
                        else
                        {
                            downLineMatching = 0;
                            break;
                        }
                    }
                }

                //Diagonal lines check

                int diagonalToPlay = amountOfLanesPlay;
                int diagonalCheckRight = 0;
                int diagonalCheckLeft = 0;


                if (diagonalToPlay - COLUMN_LINES_IN_GAME - ROW_LINES_IN_GAME <= DIAGONAL_LINES_IN_GAME)
                {
                    diagonalToPlay = amountOfLanesPlay - COLUMN_LINES_IN_GAME - ROW_LINES_IN_GAME;
                }
                else
                {
                    diagonalToPlay = DIAGONAL_LINES_IN_GAME;
                }

                for (int i = 0; i < DIAGONAL_LINES_IN_GAME; i++)
                {
                    if (diagonalToPlay >= 1)
                    {
                        if (slotMachineArray[i, i] == slotMachineArray[i + 1, i + 1])  // to check diagonal from left to righ
                        {
                            diagonalCheckRight++;
                        }
                        else
                        {
                            diagonalCheckRight = 0;
                        }
                    }
                    if (diagonalCheckRight == DIAGONAL_LINES_IN_GAME)
                    {
                        Console.WriteLine($"Win diagonal line 1 ");  // should I make another variable just for diagonal lines 1 and 2
                    }

                    if (diagonalToPlay == 2)
                    {
                        //to check diagonal line from right to left
                        if (slotMachineArray[rowMinusOne, columnMinusOne] == slotMachineArray[rowMinusOne - (1 + i), columnMinusOne - (1 + i)])
                        {
                            diagonalCheckLeft++;
                        }
                        else
                        {
                            diagonalCheckLeft = 0;
                        }
                        if (diagonalCheckLeft == DIAGONAL_LINES_IN_GAME)
                        {
                            Console.WriteLine("Win diagonal line 2 ");
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
