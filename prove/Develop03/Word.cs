using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string text {get {return _text;}}
    public bool isHidden {get {return _isHidden;}}

    public void Hide()
    {
        _isHidden = true;
    }

    public void Display()
    {
        _isHidden = false;
    }
}
