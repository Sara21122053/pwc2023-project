using System;
using System.Collections.Generic;

class Activity
{
    protected DateTime _date;
    protected int _duration;

    public Activity(DateTime date, int duration)
    {
        this._date = date;
        this._duration = duration;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        string activityType = this.GetType().Name;
        string summary = $"{_date.ToString("dd MMMM yyyy")} {activityType} ({_duration} min) - ";
        summary += $"Distance: {GetDistance()} {(GetDistanceUnit() == "miles" ? "miles" : "km")}, ";
        summary += $"Speed: {GetSpeed()} {(GetSpeedUnit() == "mph" ? "mph" : "kph")}, ";
        summary += $"Pace: {GetPace()} {(GetPaceUnit() == "min/mile" ? "min/mile" : "min/km")}";

        return summary;
    }

    protected virtual string GetDistanceUnit()
    {
        return "miles";
    }

    protected virtual string GetSpeedUnit()
    {
        return "mph";
    }

    protected virtual string GetPaceUnit()
    {
        return "min/mile";
    }
}