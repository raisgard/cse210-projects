using System;

class Program
{
    static void Main(string[] args)
    {
        //List to store numbers
        List<int> numbers = new List<int>();

        //Get number from user
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit):");

            string userResponse = Console.ReadLine();
            userNumber= int.Parse(userResponse);

            // add number to the list if it is not zero(0)
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        //Calculate Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        //Calculate the Average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //Find the maximum number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}