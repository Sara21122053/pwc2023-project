using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! Welcome to your personal journal");

        Journal journal = new Journal();

        int options = -1;

        SetAlarm();

        while (options != 6)
        {
            Console.WriteLine("How can I help you?\n 1.Write\n 2.Save\n 3.Load\n 4.Display\n 5.Load multimedia\n 6.Quit");
            options = int.Parse(Console.ReadLine());

            switch (options)
            {
                case 1:
                    journal.Write();
                    break;
                case 2:
                    journal.Save();
                    break;
                case 3:
                    journal.Load();
                    break;
                case 4:
                    journal.Display();
                    break;
                case 5:
                    journal.LoadMultimedia();
                    break;   
                case 6:
                    Console.WriteLine("Thank you for talking to me. I wish you a great day!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a number from 1 to 5.");
                    break;
            }
        }
    }

    static void SetAlarm()
    {
        DateTime now = DateTime.Now;
        DateTime nextAlarm = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
        if (nextAlarm < now)
        {
            nextAlarm = nextAlarm.AddDays(1);
        }

        TimeSpan timeUntilNextAlarm = nextAlarm - now;

        Timer timer = new Timer(_ =>
        {
            Console.WriteLine("Reminder: Don't forget to make a journal entry today!");
        }, null, timeUntilNextAlarm, TimeSpan.FromDays(1));
    }
}
