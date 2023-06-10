using System;
using System.Collections.Generic;
using System.IO;

public class ListingActivity : Activity
{
    private List<string> questions = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        ShowStartMessage();

        Random random = new Random();
        int questionIndex = random.Next(questions.Count);
        Console.WriteLine(questions[questionIndex]);
        Pause(_countdownDuration);

        List<string> items = new List<string>();

        while (_duration > 0)
        {
            Console.WriteLine("Enter an item:");
            string item = Console.ReadLine();
            items.Add(item);
            _duration--;
        }

        Console.WriteLine($"You entered {items.Count} items.");
        
        ShowEndMessage();
    }
}