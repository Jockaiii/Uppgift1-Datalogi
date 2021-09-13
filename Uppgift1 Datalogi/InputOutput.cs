using System;

namespace Uppgift1_Datalogi
{
    internal static class InputOutput
    {
        /// <summary>
        /// Metod som ber och hanterar vilken funktion användaren väljer. Samt tillkallar eventuellt nödvändiga metoder.
        /// </summary>
        public static void UserChoice()
        {
            string userChoice;
            do
            {
                Console.WriteLine("Press 1 to see stored prime numbers \nPress 2 to automatically add the next prime number to storage \npress 3 to check if a number is a that of a primenumber \nPress 4 to exit the application");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        if (Prime.primeHolder.Count > 0)
                            foreach (var primeNumber in Prime.primeHolder)
                                Console.WriteLine($"{primeNumber}\n");
                        else
                            OutputNoStoredPrimeNumbers();
                        break;

                    case "2":
                        if (Prime.primeHolder.Count > 0)
                            Prime.AddNextPrimeNumber();
                        else
                            OutputNoStoredPrimeNumbers();
                        break;

                    case "3":
                        Console.Clear();
                        Prime.CheckPrime(CheckInput());
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("wrong type of input, requires a number, please try again\n");
                        break;
                }
            } while (userChoice != "4");
        }

        /// <summary>
        /// Metod som ber om och kontrollerar användarens input. Och om inte inputen är godkänd så fortsätter programmet att be om en ny input.
        /// </summary>
        /// <returns>returnerar den godkända inputen från användaren</returns>
        public static int CheckInput()
        {
            string userInput;
            Console.WriteLine("Choose a number to check whether its a prime number or not");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result) && result <= int.MaxValue)
                return result;
            else
            {
                Console.Clear();
                Console.WriteLine("”wrong type of input, requires a number, please try again.");
                CheckInput();
            }
            return result; // la till pga "not all code paths return a value.
        }

        /// <summary>
        /// Metod som meddelar användaren om att det angivna värdet inte var ett primtal
        /// </summary>
        /// <param name="userInput">det angivna värdet</param>
        public static void OutputNotPrime(int userInput)
        {
            Console.Clear();
            Console.WriteLine($"{userInput} is not a prime number :(\n");
        }

        /// <summary>
        /// Metod som meddelar användaren om att det angivna värdet är ett primtal
        /// </summary>
        /// <param name="userInput">Det angivna värdet</param>
        public static void OutputPrime(int userInput)
        {
            Console.Clear();
            Console.WriteLine($"{userInput} is a prime number ;)\n");
        }

        /// <summary>
        /// Metod som meddelar användaren att det i nuläget inte finns några lagrade primtal att visa upp.
        /// </summary>
        public static void OutputNoStoredPrimeNumbers()
        {
            Console.Clear();
            Console.WriteLine("It appears there are currently no stored prime numbers.\n");
        }
    }
}
