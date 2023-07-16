using System;
using System.Collections.Generic;

class SwimmingActivity : Activity
{
    private int _laps;
    private const double PoolLength = 50; 

    public SwimmingActivity(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        this._laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * PoolLength / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (_duration / 60.0);
    }

    public override double GetPace()
    {
        return (_duration / GetDistance());
    }

    protected override string GetDistanceUnit()
    {
        return "km";
    }

    protected override string GetSpeedUnit()
    {
        return "kph";
    }

    protected override string GetPaceUnit()
    {
        return "min/km";
    }
}