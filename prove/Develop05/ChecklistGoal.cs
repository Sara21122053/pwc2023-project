using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ChecklistGoal : Goal
{
    protected int _numberOfTimesToComplete;
    protected int _numberOfTimesDone;
    protected int _completionBonus;
    protected int _numberNeddedForCompletion;

    public int NumberOfTimesToComplete
    {
        get {return _numberOfTimesToComplete;}
        set {_numberOfTimesToComplete = value;}
    }

    public int NumberOfTimesDone
    {
        get {return _numberOfTimesDone;}
        set {_numberOfTimesDone = value;}
    }

    public int CompletionBonus
    {
        get {return _completionBonus;}
        set {_completionBonus = value;}
    }

    public int NumberNeddedForCompletion
    {
        get {return _numberNeddedForCompletion;}
        set {_numberNeddedForCompletion = value;}
    }

    public ChecklistGoal(string name, string description, int pointsForEachCompletion, int numberOfTimesToComplete, int numberOfTimesDone, int completionBonus, int numberNeddedForCompletion)
    {
        _name = name;
        _description = description;
        _pointsForEachCompletion = pointsForEachCompletion;
        _numberOfTimesToComplete = numberOfTimesToComplete;
        _numberOfTimesDone = numberOfTimesDone;
        _completionBonus = completionBonus;
        _numberNeddedForCompletion = numberNeddedForCompletion;
        _completed = false;
        _pointsEarned = 0;
    }

    public override void CompleteGoal()
    {
        if (!_completed)
        {
            _numberOfTimesDone++;                
            _pointsEarned += _pointsForEachCompletion;                
            
            if (_numberOfTimesDone == _numberNeddedForCompletion)
            {
                _pointsEarned += _completionBonus;
            }
            else if (_numberOfTimesDone == _numberOfTimesToComplete)                
            {                    
                _completed = true;                                   
            }
        }
    }

    public override void SaveGoal(StreamWriter writer)
    {
        base.SaveGoal(writer);
        writer.WriteLine("Number Of Times To Complete: " + _numberOfTimesToComplete);
        writer.WriteLine("Number Of Times Done: " + _numberOfTimesDone);
        writer.WriteLine("Completion Bonus: " + _completionBonus);
        writer.WriteLine("Number Nedded For Completion: " + _numberNeddedForCompletion);
    }

    public override void DisplayProgress()
    {
        Console.WriteLine((_completed ? "[x]" : "[ ]") + _name + " (" + _description + ") - Currently completed: " + _numberOfTimesDone + " / " + _numberOfTimesToComplete);
    }
}
