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

    public Reference (string reference)
    {
        string[] parts = reference.Split(' ');
        
        if (parts.Length >= 3)
        {
            _Book = parts[0];
            _Chapter = int.Parse(parts[1].Replace(":",""));
            _InitialVerse = int.Parse(parts[2]);
            if (parts.Length >= 5)
            {
                _FinalVerse = int.Parse(parts[4]);
            }
        }
    }

    public override string ToString()
    {
        if (_InitialVerse == _FinalVerse)
        {
            return $"{_Book} {_Chapter}: {_InitialVerse}";
        }
        else
        {
            return $"{_Book} {_Chapter}: {_InitialVerse} - {_FinalVerse}";
        }
    }
}