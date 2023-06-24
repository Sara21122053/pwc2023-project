using System;
using System.Collections.Generic;
using System.IO;

public class MakePrayer : Activity
{
    private const int _pointsPerRegister = 20;
    private const int _pointsPerLevel = 700;
    private const int _levelBonus= 25;

    public MakePrayer()
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

        Console.WriteLine("You have earned points for doing the Prayer!");
    }
}