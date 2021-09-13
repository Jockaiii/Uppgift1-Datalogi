using System.Collections.Generic;

namespace Uppgift1_Datalogi
{
    class Prime
    {
        public static List<int> primeHolder = new List<int>();

        /// <summary>
        /// Metod som kontrollerar om användarens input är ett primtal eller inte. Och meddelar användaren om svaret. Samt tillkallar metod som sparar och sorterar
        /// eventuellt primtal i en lista.
        /// </summary>
        /// <param name="userInput">Användarens input</param>
        /// <returns>true eller false beroende på ifall inputen är ett primtal eller inte</returns>
        public static bool CheckPrime(int userInput)
        {
            if (userInput < 2 || (userInput % 2 == 0 && userInput != 2)) // var tvungen att lägga till denna exceptionen utanför loopen eftersom den inte körs om i < userInput
            {                                                             // la också userInput % 2 == 0 här för att använda mindre resurser i loopen
                InputOutput.OutputNotPrime(userInput);                    // userInput !=2 är till för att tillåta 2 (det ända jämna primtalet)
                return false;
            }
            for (int i = 2; i < userInput; i += 2) // Loopar igenom alla ojämna tal från 2 till det angivna värdet. (finns inga jämna primtal förutom 2)
                if (userInput % (userInput - i) == 0 && userInput - i > 1) // kollar ifall det är delbart alla ojämna tal mindre än sig självt. (till 3)
                {
                    InputOutput.OutputNotPrime(userInput);
                    return false;
                }
            AddPrimeToStorage(userInput); // Tillkallar metod för att lagra och sortera primtal.
            InputOutput.OutputPrime(userInput);
            return true;
        }

        /// <summary>
        /// Metod som testar större och större tal än det högsta lagrade i List<>primeHolder tills att den hittar ett primtal. vilket då lagras och skrivs ut till
        /// användaren som vanligt (eller tills att talet blir större än vanliga int ;P).
        /// </summary>
        public static void AddNextPrimeNumber()
        {
            int count = 0, testNumber;
            do
            {
                count += 2;
                if (primeHolder[^1] == 2) // Om man bara lagt till primtalet 2 kan den inte öka med 2 eftersom då kommer den bara testa ifall jämna tal och aldrig
                    testNumber = 3;       // hitta ett större primtal
                else
                    testNumber = primeHolder[^1] + count;
            } while (!CheckPrime(testNumber));
        }

        /// <summary>
        /// Metod som tar emot ett primtal för att sedan lagra och sortera det.
        /// </summary>
        /// <param name="userInput">Ancändarens angivna värde</param>
        public static void AddPrimeToStorage(int userInput)
        {
            primeHolder.Add(userInput);
            primeHolder.Sort();
        }
    }
}