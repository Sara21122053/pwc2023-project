using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        
        //Parts 1 and 2
        //Console.WriteLine("What is the magic number?");
        //int magicNumber = int.Parse(Console.ReadLine());

        //Console.WriteLine("What is your guess?");
        //int guessedNumber = int.Parse(Console.ReadLine());

        //while (guessedNumber != magicNumber)
        //{
        //    if (guessedNumber < magicNumber)
        //    {
        //        Console.WriteLine("Try a higher one");
        //    }
        //    else if (guessedNumber > magicNumber)
        //    {
        //        Console.WriteLine("Try a lower one");
        //    }

        //    Console.WriteLine("Try again");
        //    guessedNumber = int.Parse(Console.ReadLine());
        //}

        //while (guessedNumber == magicNumber)
        //{
        //    Console.WriteLine("Congratulations! You got it right");
        //    guessedNumber = int.Parse(Console.ReadLine());
        //}

        //Part 3
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guessedNumber = -1;

        while (guessedNumber != magicNumber)
        {
            Console.WriteLine("What do you think is the magic number?");
            guessedNumber = int.Parse(Console.ReadLine());

            if (guessedNumber < magicNumber)
            {
                Console.WriteLine("Try a higher one");
            }
            else if (guessedNumber > magicNumber)
            {
                Console.WriteLine("Try a lower one");
            }
        }

        while (guessedNumber == magicNumber)
        {
            Console.WriteLine("Congratulations! You got it right");
            guessedNumber = int.Parse(Console.ReadLine());
        }
    }
}
