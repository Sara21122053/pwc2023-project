using System;
using System.Collections.Generic;

class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        this._distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / (_duration / 60.0);
    }

    public override double GetPace()
    {
        return (_duration / _distance);
    }
}