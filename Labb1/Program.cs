namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ############## LABB 1 ##############
            // program prompts user to enter a text string to be searched 
            Console.WriteLine("Enter a string to search through: ");
            string input = Console.ReadLine();



            // TODO 1: the program will tell us this by printing the full input string with 
            // each substring marked in a different color to the console
            // this happens once for each substring, so two times on this example. 

            // TODO 2: all substring numbers are also to be added - this needs a long instead of an int
            // because very large number is possible 

            // console.foregroundcolor = ConsoleColor.Green/white



            
            // With a counter for the amount of found correct strings things should work out with the printouts
            // fixed some of it - now it prints the correct number of times but only the last numberstring
            int numberStringsFound = 0;
            bool foundNumberAgain = false;
            // an int array to hold indexes of start and end of numberstrings
            int[] startIndexes = new int[input.Length];
            int[] endIndexes = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                bool isInt = int.TryParse(input[i].ToString(), out int number);
                // if the number is an int change the color until same number found again
                if (isInt)
                {
                    // for the rest of the string (beginning one index to the right)
                    // search for the same number again
                    for (int j = i+2; j < input.Length; j++)
                    {
                        //bool isIntAgain = int.TryParse(input[j].ToString(), out int numberAgain);
                        // skip round if it's anything other than a number
                        if (!int.TryParse(input[j].ToString(), out int numberAgain) ||
                            !int.TryParse(input[j-1].ToString(), out int result2))
                        {
                            break;
                        }
                        else
                        {
                            // the numbers between current (numberAgain) and original (number) 
                            if (numberAgain == number)
                            {
                                startIndexes[numberStringsFound] = i;
                                endIndexes[numberStringsFound] = j;
                                foundNumberAgain = true;
                                numberStringsFound++;
                                break;
                            }
                            else
                            {
                                foundNumberAgain = false;
                            }
                        }
                    }
                }
            }

            // perhaps overkill to use ulong
            // but people might write REALLY large numbers in the strings for testing purposes
            ulong[] numbersToSum = new ulong[numberStringsFound];

            // now, for the amount of correct strings found, print out the whole string again
            // coloring the ones between what is stored in start/endindexes 
            for (int i = 0; i < numberStringsFound; i++)
            {
                string tempNumber = "";
                for (int index = 0; index < input.Length; index++)
                {
                    if (index >= startIndexes[i] && index <= endIndexes[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(input[index]);

                        if (ulong.TryParse(input[index].ToString(), out ulong result))
                        {
                            tempNumber += input[index];
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(input[index]);
                    }
                }
                Console.WriteLine();
                numbersToSum[i] = ulong.Parse(tempNumber);
            }

            //create a REALLY large numberspace to store the sum to be printed
            ulong sumToPrint = 0;

            Console.ForegroundColor = ConsoleColor.White;
            foreach (ulong number in numbersToSum)
            {
                sumToPrint += number;
            }
            // print out the sum of all found numbers:
            Console.WriteLine($"Total = {sumToPrint}");

            // debug strings: 121gkjn343ng565gckjnb787 29535123p48723487597645723645



        }
    }
}