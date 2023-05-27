using System;

public class World
{
    private string _Text;
    private bool _Hide;

    public World (string text)
    {
        _Text = text;
        _Hide = false;
    }

    public string Text {get {return _Text;}}
    public bool Hide {get {return _Hide;} set {_Hide = value;}}
}