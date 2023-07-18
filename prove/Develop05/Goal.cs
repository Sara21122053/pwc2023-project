using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected bool _completed;
    protected int _pointsForEachCompletion;
    protected int _pointsEarned;

    public string Name
    {
        get {return _name;}
        set {_name = value;}
    }

    public string Description
    {
        get {return _description;}
        set {_description = value;}
    }

    public bool Completed
    {
        get {return _completed;}
        set {_completed = value;}
    }
    public int PointsForEachCompletion
    {
        get {return _pointsForEachCompletion;}
        set {_pointsForEachCompletion = value;}
    }

    public int PointsEarned
    {
        get {return _pointsEarned;}
        set {_pointsEarned = value;}
    }

    public abstract void CompleteGoal();
    public virtual void SaveGoal(StreamWriter writer)
    {
        writer.WriteLine("Type: " + GetType().Name);
        writer.WriteLine("Name: " + _name);
        writer.WriteLine("Description: " + _description);
        writer.WriteLine("Completed: " + _completed);
        writer.WriteLine("Points For Each Completion: " + _pointsForEachCompletion);
        writer.WriteLine("Points Earned: " + _pointsEarned);
    }
    public abstract void DisplayProgress();
}
