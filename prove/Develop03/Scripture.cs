using System;

public class Scripture
{
    private Reference _reference;
    private string _text;
    private string _image;
    private List<Word> _words;
    private static Random random = new Random();

    public Scripture(Reference reference, string text, string image)
    {
        _reference = reference;
        _text = text;
        _image = image;
        _words = new List<Word>();

        string[] wordArray = _text.Split(' ');

        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public Reference Reference { get { return _reference; } }
    public string Text { get { return _text; } }
    public string Image { get { return _image; } }

    public void HideWords()
    {
        List<int> hiddenWords = new List<int>();
        
        while (hiddenWords.Count < _words.Count)
        {
            Console.Clear();
            Console.WriteLine(Reference);
            
            for (int i = 0; i < _words.Count; i++)
            {
                if (hiddenWords.Contains(i))
                    Console.Write("_____ ");
                else
                    Console.Write(_words[i].text + " ");
            }
            
            Console.WriteLine("\nPress Enter to hide more words or press any key to quit.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                int wordIndex = random.Next(_words.Count);
                
                while (hiddenWords.Contains(wordIndex))
                   wordIndex = random.Next(_words.Count);
                   
                hiddenWords.Add(wordIndex);
                _words[wordIndex].Hide();
            }
            else
            {
               break;
            }
        }

        if (hiddenWords.Count == _words.Count)
        {
            Console.WriteLine("\nAll words have been hidden.");
        }
        
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }
}
