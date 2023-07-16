using System;

class OutdoorMeeting : Event
{
    private string _weatherForecast;

    public OutdoorMeeting(string title, string description, DateTime date, TimeSpan time, string address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this._weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Meeting\nWeather Forecast: {_weatherForecast}";
    }
}