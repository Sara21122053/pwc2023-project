using System;

class Event
{
    private string _title;
    private string _description;
    private DateTime _date;
    private TimeSpan _time;
    private string _address;

    public Event(string title, string description, DateTime date, TimeSpan time, string address)
    {
        this._title = title;
        this._description = description;
        this._date = date;
        this._time = time;
        this._address = address;
    }

    public virtual string GetStadartDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\ndate: {_date.ToShortDateString()}\nTime: {_time.ToString()}\nAddress: {_address.ToString()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStadartDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Event\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}