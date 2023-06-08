using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Scripture> scriptureLibrary = new List<Scripture>();
    private static Random random = new Random();
    static void Main(string[] args)
    {
        LoadScriptsFromFile("Scriptures.txt");

        Console.WriteLine("Welcome to the Scripture Memorizer");
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n 1.Display an existing script\n 2.Load new scrip\n 3.Load script from file\n 4.Quit");
            string options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    DisplayAnExistingScripture();
                    break;
                case "2":
                    LoadNewScripture();
                    break;
                case "3":
                    LoadScriptureFromFile();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void DisplayAnExistingScripture()
    {
        Console.Clear();
        
        string filePath = "Scriptures.txt";
        
        if (!File.Exists(filePath))
        {
            Console.WriteLine("The Scriptures file does not exist. Press any key to continue.");
            Console.ReadKey();
            return;
        }
        
        string[] lines = File.ReadAllLines(filePath);
        
        if (lines.Length == 0)
        {
            Console.WriteLine("There are no scriptures in the file. Press any key to continue.");
            Console.ReadKey();
            return;
        }
        
        Random random = new Random();
        int randomIndex = random.Next(lines.Length);
        string scriptureLine = lines[randomIndex];
        
        string[] data = scriptureLine.Split('|');
        
        if (data.Length == 3)
        {
            string reference = data[0];
            string text = data[1];
            string image = data[2];
            
            string[] referenceParts = reference.Split(' ');
            
            string book = referenceParts[0];
            string[] chapterVerseParts = referenceParts[1].Split(':');
            int chapter = int.Parse(chapterVerseParts[0]);

            string[] verseParts = chapterVerseParts[1].Split('-');
            int initialVerse = int.Parse(verseParts[0]);
            int finalVerse = verseParts.Length > 1 ? int.Parse(verseParts[1]) : 0;
            
            Reference scriptureReference = new Reference(book, chapter, initialVerse, finalVerse);
            Scripture scripture = new Scripture(scriptureReference, text, image);
            
            Console.WriteLine(scripture.Reference);
            Console.WriteLine(scripture.Text);
            Console.WriteLine(scripture.Image);
            
            Console.WriteLine("Press Enter to hide words or type 'quit' to return to the main menu");
            string option = Console.ReadLine();
            
            if (option.ToLower() == "quit")
                return;
            
            HideWords(scripture);
        }
    }

    static void LoadNewScripture()
    {
        Console.Clear();
        Console.WriteLine("Enter the book:");
        string book = Console.ReadLine();

        Console.WriteLine("Enter the chaper:");
        string chap = Console.ReadLine();
        int chapter = int.Parse(chap);

        Console.WriteLine("Enter the initial verse:");
        string iniVer = Console.ReadLine();
        int initialVerse = int.Parse(iniVer);

        Console.WriteLine("Enter the final verse (leave empty if there is only one verse):");
        string finVer = Console.ReadLine();
        int finalVerse = 0;
        if (!string.IsNullOrEmpty(finVer))
        {
            finalVerse = int.Parse(finVer);
        }

        Console.WriteLine("Enter the text:");
        string text = Console.ReadLine();

        Console.WriteLine("Enter the image:");
        string image = Console.ReadLine();

        Reference newReference = new Reference(book, chapter, initialVerse, finalVerse);
        Scripture newScripture = new Scripture(newReference, text, image);
        scriptureLibrary.Add(newScripture);

        SaveScriptureToFile(newScripture);

        Console.WriteLine("Scripture added successfuly. Press any key to continue");
        Console.ReadKey();
    }
    
    static void SaveScriptureToFile(Scripture scripture)
    {
        string filePath = "Scriptures.txt";

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            string referenceString = scripture.Reference.ToString();
            string[] referenceParts = referenceString.Split(' ');
            
            string book = referenceParts[0];
            int chapter = int.Parse(referenceParts[1].Replace(":", ""));
            int initialVerse = int.Parse(referenceParts[2]);
            int finalVerse = referenceParts.Length >= 5 ? int.Parse(referenceParts[4]) : 0;

            string formattedReference = finalVerse != 0 ? $"{book} {chapter}:{initialVerse}-{finalVerse}" : $"{book} {chapter}:{initialVerse}";
            writer.WriteLine($"{formattedReference}|{scripture.Text}|{scripture.Image}");
        }
    }

    static void HideWords(Scripture scripture)
    {
        List<int> hiddenWords = new List<int>();
        List<string> words = new List<string>(scripture.Text.Split(' '));

        while (hiddenWords.Count < words.Count)
        {
            Console.Clear();
            Console.WriteLine(scripture.Reference);
            
            for (int i = 0; i < words.Count; i++)
            {
                if (hiddenWords.Contains(i))
                    Console.Write("*****");
                else
                    Console.Write(words[i] + " ");
            }

            Console.WriteLine("\nPress Enter to hide more words or press any key to quit.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            
            if(keyInfo.Key == ConsoleKey.Enter)
            {
                int wordIndex = random.Next(words.Count);

                while (hiddenWords.Contains(wordIndex))
                   wordIndex = random.Next(words.Count);

                hiddenWords.Add(wordIndex);
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    static void LoadScriptureFromFile()
    {
        Console.Clear();
        Console.WriteLine("Enter the file path:");
        string filePath = Console.ReadLine();

        if(!File.Exists(filePath))
        {
            Console.WriteLine("File not found. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        LoadScriptsFromFile(filePath);

        Console.WriteLine("Scriptures loaded from file. Press any key to continue.");
        Console.ReadKey();
    }

    static void LoadScriptsFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] data = line.Split('|');

            if (data.Length == 3)
            {
                string reference = data[0];
                string text = data[1];
                string image = data[2];

                string[] referenceParts = reference.Split(' ');
                if (referenceParts.Length >= 3)
                {
                    string book = referenceParts[0];
                    int chapter = int.Parse(referenceParts[1].Replace(":",""));
                    int initialVerse = int.Parse(referenceParts[2]);
                    
                    int finalVerse = 0;
                    if (referenceParts.Length >= 5)
                    {
                        finalVerse = int.Parse(referenceParts[4]);
                    }

                    Reference newReference = new Reference(book, chapter, initialVerse, finalVerse);
                    Scripture newScripture = new Scripture(newReference, text, image);
                    scriptureLibrary.Add(newScripture);
                }
            }
        }
    }
}
