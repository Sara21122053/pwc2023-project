using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SimpleGoal : Goal
{
    protected int _level;
    protected int _pointsNecessaryByLevel;

    public int Level
    {
        get {return _level;}
        set {_level = value;}
    }
    public int PointsNecessaryByLevel
    {
        get {return _pointsNecessaryByLevel;}
        set {_pointsNecessaryByLevel = value;}
    }

    public SimpleGoal(string name, string description, int pointsForEachCompletion, int pointsNecessaryByLevel)
    {
        _name = name;
        _description = description;
        _pointsForEachCompletion = pointsForEachCompletion;
        _pointsNecessaryByLevel = pointsNecessaryByLevel;
        _level = 1;
        _completed = false;
        _pointsEarned = 0;
    }

    public override void CompleteGoal()
    {
        if (!_completed)
        {
            base.CompleteGoal();
            
            if (_pointsEarned >= _pointsNecessaryByLevel)
            {
                _level++;
                _pointsEarned = _pointsEarned - (_level - 1) * _pointsNecessaryByLevel;
                _completed = true;
            }
        }
    }

    public override void SaveGoal(StreamWriter writer)
    {
        base.SaveGoal(writer);
        writer.WriteLine("Level: " + _level);
        writer.WriteLine("Points Necessary By Level: " + _pointsNecessaryByLevel);
    }

    public override void DisplayProgress()
    {
        Console.WriteLine((_completed ? "[x]" : "[ ]") + _name + " (" + _description + ") - Level: " + _level);
    }
}