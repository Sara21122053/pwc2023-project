using System;

class Reception: Event
{
    private string _rsvpEmail;

    public Reception(string type, string title, string description, DateTime date, TimeSpan time, string address, string rsvpEmail) : base(type, title, description, date, time, address)
    {
        this._rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: {_type}\nRSVP Email: {_rsvpEmail}";
    }
    
}
