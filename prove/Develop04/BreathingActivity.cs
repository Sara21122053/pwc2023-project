using System;
using System.Collections.Generic;
using System.IO;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        ShowStartMessage();

        while (_duration > 0)
        {
            Console.WriteLine("Breathe in...");
            Pause(_countdownDuration);
            Console.WriteLine("Breathe out...");
            Pause(_countdownDuration);
            _duration -= 2;
        }

        ShowEndMessage();
    }
}