using System;
using System.Collections.Generic;
using System.IO;

public class HomeEvening : Activity
{
    private const int _pointsPerRegister = 100;
    private const int _pointsForUnlokJournal = 400;
    private const string _journalFile = "Journal.txt";

    public HomeEvening()
    {
        _level = 1;
        _pointsNeccesaryByLevel = 0;
    }

    public override void RegisterActivity()
    {
        _points += _pointsPerRegister;

        if (_points >= _pointsForUnlokJournal)
        {
            WriteInJournal();
        }

        Console.WriteLine("You have earned points for doing the Home Evening!");
    }

    private void WriteInJournal()
    {
        Console.WriteLine("Congratulations! You have unloked the 'Journal activity'.");

        Console.WriteLine("What was your favorite Home Evening?, What did you learn?");
        string journalEntry = Console.ReadLine();
        using (StreamWriter sw = File.AppendText(_journalFile))
        {
            sw.WriteLine(journalEntry);
        }
    }
}