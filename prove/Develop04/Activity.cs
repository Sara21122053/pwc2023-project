using System;
using System.Collections.Generic;
using System.IO;
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected int _countdownDuration = 3;

    protected Activity (string name, string description)
    {
        this._name = name;
        this._description = description;
    }

    protected virtual void ShowStartMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(_description);
        Console.WriteLine("Enter the duration in seconds:");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Get ready to start...");
        Pause(_countdownDuration);
    }

    protected void Pause (int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(seconds * 1000);
        }
    }

    protected void ShowEndMessage()
    {
        Console.WriteLine("¡Good job!");
        Console.WriteLine($"Your have completed the {_name} activity in {_duration} seconds");
    }

    public abstract void Run();

    public string Name {get {return _name; } }
}