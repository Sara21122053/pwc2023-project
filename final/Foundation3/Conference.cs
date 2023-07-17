using System;

class Conference : Event
{
    private string _speakerName;
    private int _capacity;

    public Conference(string type, string title, string description, DateTime date, TimeSpan time, string address, string speakerName, int capacity) : base(type, title, description, date, time, address)
    {
        this._speakerName = speakerName;
        this._capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: {_type}\nSpeaker: {_speakerName}\nCapacity: {_capacity}";
    }
}
