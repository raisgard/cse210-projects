using System;

class Program
{
    static void Main(string[] args)
    { 
        //Get the grade percentage from the user
        Console.WriteLine("What is your grade percentage?");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        //Determine the letter grade
        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        //Print the letter grade
        Console.WriteLine($"Your grade is: {letter}");
        
        //Determine pass or fail
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Keep studying! You can do better next time.");
        }

    }
}