using System;

public class Reference
{
    private string _Book;
    private int _Chapter;
    private int _InitialVerse;
    private int _FinalVerse;

    public Reference (string book, int chapter, int verse)
    {
        _Book = book;
        _Chapter = chapter;
        _InitialVerse = verse;
        _FinalVerse = 0;
    }

    public Reference (string book, int chapter, int initialVerse, int finalVerse)
    {
        _Book = book;
        _Chapter = chapter;
        _InitialVerse = initialVerse;
        _FinalVerse = finalVerse;
    }

    public override string ToString()
    {
        if (_InitialVerse == _FinalVerse)
        {
            return $"{_Book } {_Chapter}: {_InitialVerse}";
        }
        else
        {
            return $"{_Book } {_Chapter}: {_InitialVerse} - {_FinalVerse}";
        }
    }
}
