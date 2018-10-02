using System;
using System.Text;
using System.Threading;

namespace Project_1___Hangman
{
    class Program
    {
        private static object randomSeed;

        static void Main(string[] args)
        {
            string[] messages =
            {
                @"______  _____________   _______________  ______________   __
___  / / /__    |__  | / /_  ____/__   |/  /__    |__  | / /
__  /_/ /__  /| |_   |/ /_  / __ __  /|_/ /__  /| |_   |/ / 
_  __  / _  ___ |  /|  / / /_/ / _  /  / / _  ___ |  /|  /  
/_/ /_/  /_/  |_/_/ |_/  \____/  /_/  /_/  /_/  |_/_/ |_/   ",

                @"__  __                 ___       ______       ______
_ \/ /_________  __    __ |     / /__(_)_________  /
__  /_  __ \  / / /    __ | /| / /__  /__  __ \_  / 
_  / / /_/ / /_/ /     __ |/ |/ / _  / _  / / //_/  
/_/  \____/\__,_/      ____/|__/  /_/  /_/ /_/(_)   ",

                @"_____________________  ____________   __________    __________________ 
__  ____/__    |__   |/  /__  ____/   __  __ \_ |  / /__  ____/__  __ \
_  / __ __  /| |_  /|_/ /__  __/      _  / / /_ | / /__  __/  __  /_/ /
/ /_/ / _  ___ |  /  / / _  /___      / /_/ /__ |/ / _  /___  _  _, _/ 
\____/  /_/  |_/_/  /_/  /_____/      \____/ _____/  /_____/  /_/ |_|  "
            };
            int[] counting = { 1, 2, 3, 4, 5 };

            bool gameOver = false;

            string startWord = "smellykelly";
            char[] maskStartWord = new string('-', startWord.Length).ToCharArray();
            string currentGuessedCharacter = "";
            string guessedCharactersList = "";
            
            int guessingTries = startWord.Length * 2;
            int violations = 0;
            
            Console.CursorVisible = false;

            for (int i = counting.Length; i > 0; i--)
            {

                Console.WriteLine(messages[0]);
                Console.WriteLine();
                Console.WriteLine("Game beings in... " + counting[i - 1]);
                Thread.Sleep(100);
                Console.Clear();
            }

            while (!gameOver)
            {

                Console.Clear();
                Console.WriteLine("Guess the word: {0}", new string(maskStartWord));
                Console.WriteLine("Guessed characters: {0}", guessedCharactersList);
                Console.WriteLine("You have {0} tries left!", guessingTries);
                Console.WriteLine();
                Console.Write("Your next guess is: ");

                currentGuessedCharacter = Console.ReadLine();
                guessedCharactersList += currentGuessedCharacter[0] + ", ";

                if (currentGuessedCharacter.Length > 1)
                {
                    if (violations >= 1)
                    {
                        guessingTries--;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to input only 1 character!");
                    Console.WriteLine("You will lose 2 lives, for each following violation of the rule!");
                    Thread.Sleep(3000);
                    Console.ResetColor();

                    violations++;
                }

                if (startWord.Contains(currentGuessedCharacter[0].ToString()))
                {
                    for (int i = 0; i < startWord.Length; i++)
                    {
                        if (startWord[i] == currentGuessedCharacter[0])
                        {
                            maskStartWord[i] = currentGuessedCharacter[0];
                        }

                    }
                }

                guessingTries--;

                if (guessingTries == 0)
                {
                    gameOver = true;
                    Console.WriteLine(messages[2]);
                }
                else if (!(new string(maskStartWord).Contains("-")))
                {
                    gameOver = true;
                    Console.WriteLine(messages[1]);
                    Thread.Sleep(5000);
                }


            }
        }
    }
}
