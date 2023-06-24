using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Activity> gamifications;
    private static Activity gamificationSelected = null;
    public static void Main(string[] args)
    {
        gamifications = new List<Activity>
        {
            new ReadScriptures(),
            new MakePrayer(),
            new Sacrament(),
            new HomeEvening(),
            new GoTemple()
        };
        
        int option;
        int score = 0;

        do
        {
            Console.WriteLine("Welcome to Eternal Quest!");

            Console.WriteLine("Select an option\n 1.View score\n 2.View register score\n 3.Create a new gamification\n 4.Register objetive\n 5.Play\n 6.Exit\n");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Your current score is:" + score);
                    Console.WriteLine();
                    break;
                case 2:
                    ShowRegisterScore();
                    Console.WriteLine();
                    break;
                case 3:
                    CreateGamification();
                    Console.WriteLine();
                    break;
                case 4:
                    RegisterObjetive();
                    Console.WriteLine();
                    break;
                case 5:
                    PlayActivities();
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Thanks for playing Eternal Quest! See you later!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    Console.WriteLine();
                    break;
            }
        }while (option != 6);
    }

    private static void ShowRegisterScore()
    {
        string registerFile = "Register.txt";

        if (File.Exists(registerFile))
        {
            string[] registrations = File.ReadAllLines(registerFile);

            if (registrations.Length > 0)
            {
                Console.WriteLine("Recording of scores:");

                foreach (string register in registrations)
                {
                    Console.WriteLine(register);
                }
            }
            else
            {
                Console.WriteLine("No registrations are available. All data are zero.");
            }
        }
        else
        {
            Console.WriteLine("No registrations are available. All data are zero.");
        }
    }

    private static void CreateGamification()
    {
        Console.WriteLine("Enter the name of the new gamification:");
        string gamificationName = Console.ReadLine();

        Console.WriteLine("Enter the number of points earned for each register objetive:");
        int pointsPerRegister = int.Parse(Console.ReadLine());
        bool validNumber = int.TryParse(Console.ReadLine(), out pointsPerRegister);

        Console.WriteLine("Enter the amount of points needed to level up:");
        int pointsPerLevel = int.Parse(Console.ReadLine());
        bool validNumber2 = int.TryParse(Console.ReadLine(), out pointsPerLevel);

        if (validNumber && validNumber2)
        {
            Activity newGamification = new NewGamification(gamificationName, pointsPerRegister, pointsPerLevel);
            gamifications.Add(newGamification);
            gamificationSelected = newGamification;
            
            Console.WriteLine($"The gamification '{gamificationName}' has been successfully created.");
        }
        else
        {
            Console.WriteLine("Invalid entry. The gamification could not be created.");
        }
    }

    private static void RegisterObjetive()
    {
        Console.WriteLine("Select the gamification in which you want to register the objetive:");
        
        for (int i = 0; i < gamifications.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {gamifications[i]}");
        }

        Console.WriteLine("Enter the number corresponding to the gamification:");
        int option;
        bool validNumber = int.TryParse(Console.ReadLine(), out option);

        if (validNumber && option >= 1 && option <= gamifications.Count)
        {
            Activity gamification = gamifications[option - 1];
            gamification.RegisterActivity();
            
            string register = $"{DateTime.Now}: {gamification} - Level: {gamification._level} - Points: {gamification._points}";
            string registerFile = "Register.txt";
            using (StreamWriter sw = File.AppendText(registerFile))
            {
                sw.WriteLine(register);
            }

            Console.WriteLine("Successfully register objective!");
        }
        else
        {
            Console.WriteLine("Invalid option. Please select a valid option.");
        }
    }

    private static void PlayActivities()
    {
        Console.WriteLine("Activities:");
        foreach (Activity gamification in gamifications)
        {
            Console.WriteLine(gamification.GetType().Name);
            Console.WriteLine("Level:" + gamification._level);
            Console.WriteLine("Points:" + gamification._points);
            Console.WriteLine("Points needed to level up:" + gamification._pointsNeccesaryByLevel);
            Console.WriteLine();
        }
    }
}
