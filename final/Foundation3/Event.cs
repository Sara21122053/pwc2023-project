using System;

class Event
{
    protected string _type;
    protected string _title;
    protected string _description;
    protected DateTime _date;
    protected TimeSpan _time;
    protected string _address;

    public Event(string type, string title, string description, DateTime date, TimeSpan time, string address)
    {
        this._type = type;
        this._title = title;
        this._description = description;
        this._date = date;
        this._time = time;
        this._address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\ndate: {_date.ToShortDateString()}\nTime: {_time.ToString()}\nAddress: {_address.ToString()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: {_type}\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}
