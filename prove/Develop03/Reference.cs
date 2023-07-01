using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _initialVerse;
    private int? _finalVerse;

    public Reference(string book, int chapter, int initialVerse, int? finalVerse)
    {
        _book = book;
        _chapter = chapter;
        _initialVerse = initialVerse;
        _finalVerse = finalVerse;
    }

    public override string ToString()
    {
        if (_finalVerse == null)
        {
            return $"{_book} {_chapter}:{_initialVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_initialVerse}-{_finalVerse}";
        }
    }
}
