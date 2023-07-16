using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        DateTime _date = new DateTime(2022, 11, 3);
        Activity running = new RunningActivity(_date, 30, 3.0);
        Activity cycling = new CyclingActivity(_date, 30, 9.7);
        Activity swimming = new SwimmingActivity(_date, 30, 10);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }
    }
}
