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



            for (int i = 0; i < input.Length; i++)
            {
                int firstIndex = 0;
                int secondIndex = 0;
                bool foundNumberAgain = false;
                bool isInt = int.TryParse(input[i].ToString(), out int number);
                // if the number is an int change the color until same number found again
                if (isInt)
                {
                    // for the rest of the string (beginning one index to the right)
                    // search for the same number again
                    for (int j = i+1; j < input.Length; j++)
                    {
                        bool isIntAgain = int.TryParse(input[j].ToString(), out int numberAgain);
                        if (isIntAgain)
                        {
                            // the numbers between current (numberAgain) and original (number) 
                            if (numberAgain == number)
                            {
                                foundNumberAgain = true;
                                firstIndex = i;
                                secondIndex = j;
                            }
                            //don't think these bools do anything really?
                            else
                            {
                                foundNumberAgain = false;
                            }
                        }
                    }
                }
                // from firstIndex to secondIndex - print in color 
                for (int index = 0; index < input.Length; index++)
                {
                    if (index >= firstIndex && index <= secondIndex)
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
            

            //for (int i = 0; i < text.Length; i++)
            //{
            //    // has to be ' ' not " here because searching for 
            //    if (text[i] == 'e')
            //    {
            //        hittadeOrdEtt = !hittadeOrdEtt;
            //    }
            //    if (hittadeOrdEtt)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.Write(text[i]);
            //    }
            //    else
            //    {
            //        Console.Write(text[i]);
            //        Console.ForegroundColor = ConsoleColor.White;
            //    }
            //}




        }
    }
}