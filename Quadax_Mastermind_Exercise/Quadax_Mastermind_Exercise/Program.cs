using System;

namespace Quadax_Mastermind_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] mastermindAnswer = new int[4];
            for (int i = 0; i < 4; i++)
            {
                mastermindAnswer[i] = random.Next(1, 7);
            }

            int userAttempts = 10;

            Console.WriteLine("Quadax Mastermind Exercise");
            Console.WriteLine("==========================");
            Console.WriteLine("");
            Console.WriteLine("You Get 10 Attempts to Guess the Answer");
            Console.WriteLine("A + indicates a correctly placed digit.");
            Console.WriteLine("A - indicates a digit in the answer, but in the wrong position.");
            Console.WriteLine("Digits not in the answer, give no response in the Hint.");
            Console.WriteLine("");

            while (userAttempts > 0)
            {
                Console.WriteLine($"{userAttempts} attempts remaining.");
                Console.WriteLine("Enter your guess (4 digits between 1 and 6):");
                string mastermindGuess = Console.ReadLine();

                Console.WriteLine("");

                userAttempts--;
                string hint = "";
                int[] guess = new int[4];

                bool validDataEntry = true;
                if (mastermindGuess.Length != 4)
                {
                    Console.WriteLine("Guess must be 4 digits.");
                    validDataEntry = false;
                }
                else
                {

                    // Confirm each guess digit is 1-6
                    for (int i = 0; i < 4; i++)
                    {
                        if (!int.TryParse(mastermindGuess[i].ToString(), out guess[i]) || guess[i] < 1 || guess[i] > 6)
                        {
                            string digitPosition = (i + 1).ToString();
                            Console.WriteLine(string.Concat("Confirm digit ", digitPosition, " is 1-6."));
                            validDataEntry = false;
                        }
                    }
                }

                if (validDataEntry)
                    {
                    // Check the guess against the answer
                    for (int i = 0; i < 4; i++)
                    {
                        if (guess[i] == mastermindAnswer[i])
                        {
                            hint += "+"; // digit in the correct position
                        }
                        else if (Array.IndexOf(mastermindAnswer, guess[i]) != -1)
                        {
                            hint += "-"; // digit is in the answer, but not in this position
                        }
                    }

                    // Need to display all the +'s first, hence the OrderBy
                    Console.WriteLine("Hint: " + new string(hint.OrderBy(c => c).ToArray()));
                }

                string exitMessage = "Press any key to exit...";
                if (hint == "++++")
                {
                    Console.WriteLine("Correct.");
                    Console.WriteLine(exitMessage);
                    Console.ReadKey();
                    break;
                }
                else if (userAttempts == 0)
                {
                    Console.WriteLine("Sorry, you've exhausted all attempts. The correct answer was: " + string.Join("", mastermindAnswer));
                    Console.WriteLine(exitMessage);
                    Console.ReadKey();                    
                    break;
                }
            }
        }
    }
}

