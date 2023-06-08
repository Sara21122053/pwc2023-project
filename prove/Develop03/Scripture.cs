using System;

public class Scripture
{
    private Reference _Reference;
    private string _Text;
    private string _Image;

    public Scripture (Reference reference, string text, string image)
    {
        _Reference = reference;
        _Text = text;
        _Image = image;
    }

    public Reference Reference {get {return _Reference;}}
    public string Text {get {return _Text;}}
    public string Image {get {return _Image;}}
}
