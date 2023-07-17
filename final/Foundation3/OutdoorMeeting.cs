using System;

class OutdoorMeeting : Event
{
    private string _weatherForecast;

    public OutdoorMeeting(string type, string title, string description, DateTime date, TimeSpan time, string address, string weatherForecast)
        : base(type, title, description, date, time, address)
    {
        this._weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: {_type}\nWeather Forecast: {_weatherForecast}";
    }
}
