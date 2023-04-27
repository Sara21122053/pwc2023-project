using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string name = UserName();

        int number = UserNumber();

        int squareNumber = SquareNumber(number);

        DisplayResponse(name, squareNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string UserName()
    {
        Console.WriteLine("Please enter your name:");
        string responseName = Console.ReadLine();
        return responseName;
    }

    static int UserNumber()
    {
        Console.WriteLine("Pleae enter your favorite number:");
        int responseNumber = int.Parse(Console.ReadLine());
        return responseNumber;
    }

    static int SquareNumber(int responseNumber)
    {
        int square = responseNumber * responseNumber;
        return square;
    }

    static void DisplayResponse(string responseName, int square)
    {
        Console.WriteLine($"Your name is {responseName} and the square of your favorite number is {square}");
    }
}
