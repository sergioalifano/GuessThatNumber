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
            bool playAgain = true;
            while (playAgain)
            {
                //call the function to play the game
                Play();

                //ask the user if wants to play again
                Console.WriteLine("This is your lucky day! Would you like to give another shot? (Y/N)");
                string play = Console.ReadLine();

                //check the answer
                if (play.ToLower() == "n")
                {
                    playAgain = false;
                }
               
            }
        }

        /// <summary>
        /// This function choose a random number and ask the user to guess the number
        /// </summary>
        public static void Play() {
            Random rng = new Random();
            int randomNumber = rng.Next(1, 101);
            bool found = false;
            int numberOfTry = 0;

            //call the function to set rhe random number
            SetNumberToGuess(randomNumber);

            Console.WriteLine("Wanna guess what number (between 1-100) I'm thinking about? Pick a number: ");
            string userInput = Console.ReadLine();

            //loop until the user guess the number
            while (!found)
            {
                //check if the inuput is a valid number
                if (ValidateInput(userInput))
                {
                    //if the user is close to the number, but a little bit high
                    if (IsGuessHighClose(int.Parse(userInput)))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("It's getting hot in here...too high though");
                        Console.ResetColor();

                        userInput = Console.ReadLine();
                        numberOfTry++;
                    }
                        //if the user choose a number a little bit lower
                    else if (IsGuessLowClose(int.Parse(userInput)))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ohhhh close!!!! Try a little bit high");
                        Console.ResetColor();

                        userInput = Console.ReadLine();
                        numberOfTry++;
                    }
                        //if the number is too far high
                    else if (IsGuessTooHigh(int.Parse(userInput)))
                    {
                        Console.WriteLine("Oops....to high. Try again");
                        userInput = Console.ReadLine();
                        numberOfTry++;
                    }
                        //if the number is too low
                    else if (IsGuessTooLow(int.Parse(userInput)))
                    {
                        Console.WriteLine("Too low....try with a higher one");
                        userInput = Console.ReadLine();
                        numberOfTry++;
                    }
                    else
                    {
                        //Winner
                        Console.WriteLine("You did it!!! It took you {0} trys to guess the exact number!", ++numberOfTry);
                        found = true;
                       
                    }
                }
                else
                {
                    //wait for the user to insert a number
                    userInput = Console.ReadLine();
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Check if the input is a valid number
        /// </summary>
        /// <param name="userInput">the input string</param>
        /// <returns>true if the input is valid. False otherwise</returns>
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
                //if the input is not a number
                Console.WriteLine("\"{0}\" is a number to you? Please insert a real number", userInput);
                return false;
            }
           
            return true;
     
        }

        /// <summary>
        /// This function override the global variable holding the number the user needs to guess
        /// </summary>
        /// <param name="number">the number to guess</param>
        public static void SetNumberToGuess(int number)
        {
            NumberToGuess = number;
        }

        /// <summary>
        /// Check if the number guessed is too high
        /// </summary>
        /// <param name="userGuess">the number guessed</param>
        /// <returns>return true if the number guessed by the user is too high</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            if (userGuess > NumberToGuess)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the number guessed is too low
        /// </summary>
        /// <param name="userGuess">the number guessed</param>
        /// <returns>return true if the number guessed by the user is too low</returns>
        public static bool IsGuessTooLow(int userGuess)
        {
            if (userGuess < NumberToGuess)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the number guessed is close but higher than the number to find
        /// </summary>
        /// <param name="userGuess">the number guessed</param>
        /// <returns>return true if the number guessed by the user is a bit higher</returns>
        public static bool IsGuessHighClose(int userGuess)
        {
            if (userGuess > NumberToGuess && userGuess < NumberToGuess + 10)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the number guessed is close but lower than the number to find
        /// </summary>
        /// <param name="userGuess">the number to guess</param>
        /// <returns>return true if the number guessed by the user is a bit lower</returns>
        public static bool IsGuessLowClose(int userGuess)
        {
            if (userGuess < NumberToGuess && userGuess > NumberToGuess - 10)
            {
                return true;
            }
            return false;
        }
    }
}
