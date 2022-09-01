namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // program prompts user to enter a text string to be searched 
            Console.WriteLine("Enter a string to search through: ");
            string input = Console.ReadLine();
            

            // text string is to be searched for substrings with numbers 
            // the substrings should start and end with the same number 
            // but not contain anything other than numbers 
            // for example input: 242m500005 
            // the program should tell us that there are two substrings of interest here:
            // 242 and 5000005

            // the program will tell us this by printing the full input string with 
            // each substring marked in a different color to the console
            // this happens once for each substring, so two times on this example. 

            // all substring numbers are also to be added - this needs a long instead of an int
            // because very large number is possible 

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    Console.Write(input[i]);
                }
            }
        }
    }
}