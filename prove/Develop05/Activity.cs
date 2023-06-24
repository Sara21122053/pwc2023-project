using System;
using System.Collections.Generic;
using System.IO;

public abstract class Activity
{
    public string _name;
    public int _level;
    public int _points;
    public int _pointsNeccesaryByLevel;

    public abstract void RegisterActivity();
}