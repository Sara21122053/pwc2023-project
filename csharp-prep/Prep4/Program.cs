using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        List<int> numbers = new List<int>();
        
        int enteredNumber = -1;

        while (enteredNumber != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished");

            string response = Console.ReadLine();
            enteredNumber = int.Parse(response);

            if (enteredNumber != 0)
            {
                numbers.Add(enteredNumber);
            }
        }

        int sum = 0;
        foreach (int data in numbers)
        {
            sum += data;
        }
        Console.WriteLine($"The total sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers [0];
        foreach (int data in numbers)
        {
            if (data > max)
            {
                max = data;
            }
        }
        Console.WriteLine($"The max is: {max}");

    }
}
