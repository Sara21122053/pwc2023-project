using System;
using System.Collections.Generic;
using System.IO;

public class ReadScriptures : Activity
{
    private const int _pointsPerRegister = 50;
    private const int _pointsPerLevel = 700;
    private const int _levelBonus = 25;
    private const int _pointsToUnlockTestimony = 2800;
    private const string _fileTestimony = "Testimony.txt";

    public ReadScriptures()
    {
        _level = 1;
        _pointsNeccesaryByLevel = _pointsPerLevel;
    }

    public override void RegisterActivity()
    {
        _points += _pointsPerRegister;

        if (_points >= _pointsNeccesaryByLevel)
        {
            _level++;
            _pointsNeccesaryByLevel += _pointsPerLevel;
            _points += _levelBonus;
        }

        if (_points >= _pointsToUnlockTestimony)
        {
            UnlockTestimony();
        }

        Console.WriteLine("You have earned points for reading the Scriptures!");
    }

    private void UnlockTestimony()
    {
        Console.WriteLine("Congratulations! You have unlocked the activity 'Give Testimony'.");
        
        Console.WriteLine("Write your testimony");
        string testimony = Console.ReadLine();
        
        using (StreamWriter sw = File.AppendText(_fileTestimony))
        {
            sw.WriteLine(testimony);
        }
    }
}   