using System;
using System.Collections.Generic;
using System.IO;

public class StretchingActivity : Activity
{
    private List<string> stretches = new List<string>()
    {
        "neck stretch (turns the head from one side to the other)",
        "back stretch (sitting or standing stretch until you touch your feet without bending your knees)",
        "arm stretch (interlace fingers and raise arms overhead)",
        "foot stretch (stand on tiptoe and lower)",
        "leg stretch (kneeling, extend one leg and apply a little pressure, then repeat with the other leg)."
    };

    public StretchingActivity() : base("Stretching Activity", "This activity will help you relax your body and clear your mind. Do each exercise calmly")
    {
    }

    public override void Run()
    {
        ShowStartMessage();

        Console.Write("Get ready to start...");
        Pause(_countdownDuration);

        foreach (string stretch in stretches)
        {
            Console.WriteLine("Perform the:" + stretch);
            Pause(_countdownDuration);
        }

        ShowEndMessage();
    }
}
