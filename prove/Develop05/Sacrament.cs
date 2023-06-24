using System;
using System.Collections.Generic;
using System.IO;

public class Sacrament : Activity
{
    private const int _pointsPerRegister = 100;
    private const int _pointsForGoldMedal = 400;
    private const string _medalsFile = "Medals.txt";

    public Sacrament()
    {
        _level = 1;
        _pointsNeccesaryByLevel = 0;
    }

    public override void RegisterActivity()
    {
        _points += _pointsPerRegister;

        if (_points >= _pointsForGoldMedal)
        {
            WinGoldMedal();
        }

        Console.WriteLine("You have earned points for participating in the Sacrament!");
    }

    private void WinGoldMedal()
    {
        Console.WriteLine("Congratulations! You have won a gold medal");
        
        string register = $"{DateTime.Now}: Gold Medal - Sacrament";
        using (StreamWriter sw = File.AppendText(_medalsFile))
        {
            sw.WriteLine(register);
        }
    }
}