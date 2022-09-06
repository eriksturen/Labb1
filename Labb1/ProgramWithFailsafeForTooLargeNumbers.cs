// NOTE: This is a version of the exact same program as the original one. 
// Only difference is that a failsafe is included for VERY large testingstrings
// In case a string is inputed with too long numbersubstrings the sum cannot be stored correctly in a ulong
// in that case the orignal program breaks down. This version runs the rest of the program while telling user
// that the sum cannot be calculated safely since one or more of the numbers in the string made the sum too large


namespace Labb1
{
    internal class ProgramWithFailsafe
    {
        static void MainWithFailsafe(string[] args)
        {
            // ############## LABB 1 ##############
            // Prompt user to enter a text string to be searched:
            // the string can now be relatively large but there still is a limit,
            // especially if the numbersubstrings are too long - the sum in the end is what's limiting now
            Console.WriteLine("Enter a string to search through: ");
            string input = Console.ReadLine();

            // TODO 1: the program will tell us this by printing the full input string with 
            // each substring marked in a different color to the console
            // this happens once for each substring, so two times on this example. 

            // TODO 2: all substring numbers are also to be added - this needs a long instead of an int
            // because very large number is possible --> changed to ulong because even larger!
            // --------------------------------------------------------------------------------- // 

            // this is a counter for the amount of numberstrings found - needed later to make the printout work
            int numberStringsFound = 0;
            // two int arrays to hold indexes of start and end of numberstrings
            int[] startIndexes = new int[input.Length];
            int[] endIndexes = new int[input.Length];

            // loop through the inputed string in search of numbers
            for (int i = 0; i < input.Length; i++)
            {
                bool isInt = int.TryParse(input[i].ToString(), out int number);
                if (isInt)
                {
                    // when number is found 
                    // search for the same number again - beginning two indexed to the right because minimum numberstringlength is 3
                    for (int j = i + 2; j < input.Length; j++)
                    {
                        // skip round if it's anything other than a number
                        // also if theres anything else than number just to the left
                        // otherwise letters can sneak in there!
                        if (!int.TryParse(input[j].ToString(), out int numberAgain) ||
                            !int.TryParse(input[j - 1].ToString(), out int result2))
                        {
                            break;
                        }
                        else
                        {
                            // when same number is found save the start and end indexes in the arrays
                            if (numberAgain == number)
                            {
                                startIndexes[numberStringsFound] = i;
                                endIndexes[numberStringsFound] = j;
                                numberStringsFound++;
                                break;
                            }
                        }
                    }
                }
            }

            // perhaps overkill to use array of ulongs for the sum to printout
            // but people might write REALLY large numbers in the strings for testing purposes
            ulong[] numbersToSum = new ulong[numberStringsFound];

            // now, for the amount of correct strings found, print out the whole string again
            // coloring the ones between what is stored in start/endindexes 
            bool parsingError = false;
            for (int i = 0; i < numberStringsFound; i++)
            {
                // this temp var is used to store numbers that are to be summed 
                string tempNumber = "";
                for (int index = 0; index < input.Length; index++)
                {
                    if (index >= startIndexes[i] && index <= endIndexes[i])
                    {
                        // print in green because Matrix!
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
                // empty line for formatting purposes
                Console.WriteLine();
                // save the number to sum to the list of ulongs
                bool ulongParseOk = ulong.TryParse(tempNumber, out ulong parsedUlong);
                if (ulongParseOk)
                {
                    numbersToSum[i] = parsedUlong;
                }
                else
                {
                    parsingError = true;
                    break;
                }
                //numbersToSum[i] = ulong.Parse(tempNumber);
            }

            //create a REALLY large number variable to store the sum to be printed
            ulong sumToPrint = 0;

            // simple loop to add numbers to the sum
            Console.ForegroundColor = ConsoleColor.White;
            foreach (ulong number in numbersToSum)
            {
                sumToPrint += number;
            }
            // print out the sum of all found numbers if no errors happened earlier:
            if (parsingError == false)
            {
                Console.WriteLine($"Total = {sumToPrint}");
            }
            else if (parsingError == true)
            {
                Console.WriteLine($"One or many of the numbersubstrings were to large to be parsed as ulongs. \n" +
                    $"The sum cannot be calculated accurately");
            }

            // weird debug strings: 121gkjn343ng565gckjnb787 from instruction: 29535123p48723487597645723645

        }
    }
}