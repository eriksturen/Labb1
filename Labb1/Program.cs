namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FRÅN FÖRELÄNSNINGEN 
            //"Kan använda en forloop på en CharArray för att hitta alla "s" eller mellanrum eller något 
            string text = "Hejsan svejsan";

            bool hittadeOrdEtt = false;


            // This writes out from same to same in a different color with the rest of the string uncolored!
            for (int i = 0; i < text.Length; i++)
            {
                // has to be ' ' not " here because searching for 
                if (text[i] == 'e')
                {
                    hittadeOrdEtt = !hittadeOrdEtt;
                }
                if (hittadeOrdEtt)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(text[i]);
                }
                else
                {
                    Console.Write(text[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine();

            

            // ############## LABB 1 ##############
            // program prompts user to enter a text string to be searched 
            Console.WriteLine("Enter a string to search through: ");
            string input = Console.ReadLine();

            // text string is to be searched for substrings with numbers 
            // the substrings should start and end with the same number 
            // but not contain anything other than numbers 
            // for example input: 242m500005 
            // the program should tell us that there are two substrings of interest here:
            // 242 and 5000005

            // TODO 1: the program will tell us this by printing the full input string with 
            // each substring marked in a different color to the console
            // this happens once for each substring, so two times on this example. 

            // TODO 2: all substring numbers are also to be added - this needs a long instead of an int
            // because very large number is possible 

            // console.foregroundcolor = ConsoleColor.Green/white

            // pseudo code
            // for (the whole input string) 
            // { 
            //      if (input[i] is a number)
            //      { 
            //          change color to green
            //          search through rest of string for THE SAME number
            //          if (number is found) 
            //          {       
            //              print out everything from number to current position in green
            //          }


            
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
                    for (int j = i+1; j < input.Length; j++)
                    {
                        bool isIntAgain = int.TryParse(input[j].ToString(), out int numberAgain);
                        // skip round if it's anything other than a number
                        if (!isIntAgain)
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

            // now, for the amount of correct strings found, print out the whole string again
            // coloring the ones between what is stored in start/endindexes 
            for (int i = 0; i < numberStringsFound; i++)
            {
                for (int index = 0; index < input.Length; index++)
                {
                    if (index >= startIndexes[i] && index <= endIndexes[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(input[index]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(input[index]);
                    }
                }
                Console.WriteLine();
            }

            // debug strings: 121gkjn343ng565gckjnb787 29535123p48723487597645723645



        }
    }
}