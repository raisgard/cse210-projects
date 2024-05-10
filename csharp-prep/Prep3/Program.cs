using System;

class Program
{
    static void Main(string[] args)
    {
        //Generates a random magic number
        Random randomGenerator = new Random ();
        //Range: 1(inclusive) to 100(exclusive)
        int magicNumber = randomGenerator.Next(1,101);
        
        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess?");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Bravo! You guessed it right.");
            }
        }
    }
}