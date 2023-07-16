using System;
using System.Collections.Generic;

class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        this._speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return _speed * (_duration / 60.0);
    }

    public override double GetPace()
    {
        return (60.0 / _speed);
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