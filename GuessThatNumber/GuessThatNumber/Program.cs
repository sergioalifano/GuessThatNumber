using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0; 
       
        static void Main(string[] args)
        {
            Random rng = new Random();
            int randomNumber = rng.Next(1, 101);
            bool found = false;
            int numberOfTry = 0;

            SetNumberToGuess(randomNumber);
            Console.WriteLine("Wanna guess what number (between 1-100) I'm thinking about? Pick a number: ");
            string userInput = Console.ReadLine();

            while (!found)
            {
                if (ValidateInput(userInput))
                {
                    if(IsGuessTooHigh(int.Parse(userInput)))
                    {
                        Console.WriteLine("Oops....to high. Try again");
                        userInput = Console.ReadLine();
                        numberOfTry++;
                    }
                    else if (IsGuessTooLow(int.Parse(userInput)))
                    {
                        Console.WriteLine("Too low....try with a higher one");
                        userInput = Console.ReadLine();
                        numberOfTry++;
                    }
                    else
                    {
                        Console.WriteLine("You did it!!! It took you {0} trys to guess the exact number!", numberOfTry);
                        found = true;
                    }
                }
                else
                {
                    userInput = Console.ReadLine();
                }
            }

            Console.ReadKey();
        }
        
        public static bool ValidateInput(string userInput)
        {
            int result;
            //check to see if the string is a number
            if (int.TryParse(userInput, out result))
            {
                //check to make sure that the users input is a valid number between 1 and 100.
                if (int.Parse(userInput) > 100 || int.Parse(userInput) < 1)
                {
                    Console.WriteLine("Value out of range. Insert a value between 1 and 100");
                    return false;
                }

            }
            else
            {
                Console.WriteLine("\"{0}\" is a number to you? Please insert a real number", userInput);
                return false;
            }
           
            return true;
     
        }

        public static void SetNumberToGuess(int number)
        {
            NumberToGuess = number;
           

            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
        }

        public static bool IsGuessTooHigh(int userGuess)
        {
            if (userGuess > NumberToGuess)
            {
                return true;
            }
            //TODO: return true if the number guessed by the user is too high
            return false;
        }

        public static bool IsGuessTooLow(int userGuess)
        {
            if (userGuess < NumberToGuess)
            {
                return true;
            }
            //TODO: return true if the number guessed by the user is too low
            return false;
        }
    }
}
