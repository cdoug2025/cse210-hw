using System;

class Program
{
    static void Main(string[] args)
    {
        //game loop
        string playAgain;
        do
        {
            //generate number
            Console.Write("I'm thinking of a magic number between one and... ");
            int maxRange = int.Parse(Console.ReadLine());
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, maxRange + 1);

            //loop
            int guessNumber;
            do
            {
                //guess number
                Console.Write("\nWhat is your guess? ");
                guessNumber = int.Parse(Console.ReadLine());

                //higher
                if (magicNumber > guessNumber)
                {
                    Console.WriteLine($"The magic number is higher than {guessNumber}");
                }

                //lower
                else if (magicNumber < guessNumber)
                {
                    Console.WriteLine($"The magic number is lower than {guessNumber}");
                }

                //equals
                else if (magicNumber == guessNumber)
                {
                    Console.WriteLine($"You guessed it!\nThe magic number was {magicNumber}");
                }

            } while (guessNumber != magicNumber);

            //play again
            Console.Write("\nWould you like to play again (y/n)? ");
            playAgain = Console.ReadLine();
        } while (playAgain == "y");
    }
}