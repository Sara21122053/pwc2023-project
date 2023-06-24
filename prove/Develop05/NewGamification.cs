using System;
using System.Collections.Generic;
using System.IO;

public class NewGamification : Activity
{
    private string _name;
    private int _pointsPerRegister;
    private int _pointsPerLevel;

    public NewGamification(string name, int pointsPerRegister, int pointsPerLevel)
    {
        this._name = name;
        this._pointsPerRegister = pointsPerRegister;
        this._pointsPerLevel = pointsPerLevel;
    }

    public override void RegisterActivity()
    {
        _points += _pointsPerRegister;

        if (_points >= _pointsPerLevel)
        {
            _level++;
            _points = 0;
        }
    }
}
