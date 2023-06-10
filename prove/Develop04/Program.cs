using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Activity> activities = new List<Activity>()
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity(),
            new StretchingActivity()
        };

        private static List<string> usedPrompts = new List<string>();
        private static string logFile = "Log.txt";
    
    static void Main(string[] args)
    {
        while (true)
        {
            ShowMenu();

            int choice = GetMenuChoice();
            if (choice == activities.Count + 1)
            {
                Console.WriteLine("¡Goodbye! Thank you for using the mindfulness program. Have a great day.");
                break;
            }

            Activity activity = activities[choice - 1];
            activity.Run();
            LogActivity(activity);
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Welcome to Mindfulness Program");

        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].Name}");
        }

        Console.WriteLine($"{activities.Count + 1}. Exit");
    }

    static int GetMenuChoice()
    {
        int choice;
        while (true)
        {
            Console.WriteLine("Choose an activity");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= activities.Count + 1)
                break;

            Console.WriteLine("Invalid option. Please, choose a valid option.");
        }

        Console.WriteLine();
        return choice;
    }

    static void LogActivity(Activity activity)
    {
        string logEntry = $"{DateTime.Now}: {activity.Name}";
        File.AppendAllText(logFile, logEntry + Environment.NewLine);
    }
}
