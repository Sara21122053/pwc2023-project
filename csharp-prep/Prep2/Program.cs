using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        
        Console.WriteLine("What is the percentage of your qualification?");
        string qualification = Console.ReadLine();
        int value = int.Parse(qualification);

        string letter = "";

        if (value >= 90)
        {
            letter = "A";
        }
        else if (value >= 80)
        {
            letter = "B";
        }
        else if (value >= 70)
        {
            letter = "C";
        }
        else if (value >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your qualification is: {letter}");

        if (value >= 70)
        {
            Console.WriteLine("Congratulations!. You passed. Keep up the good work");
        }
        else
        {
            Console.WriteLine("Don't worry, you'll do better next time.");
        }
    }
}
