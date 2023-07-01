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
            Console.WriteLine("What would you like to do?\n 1. Display an existing scripture\n 2. Load new scripture\n 3. Load scripture from file\n 4. Quit");
            string option = Console.ReadLine();

            switch (option)
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
        
        string[] lines = File.ReadAllLines(filePath);
        
        if (lines.Length == 0)
        {
            Console.WriteLine("There are no scriptures in the file. Press any key to continue.");
            Console.ReadKey();
            return;
        }
        
        
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
            string chapterVerse = referenceParts[1];
            
            string[] chapterVerseParts = chapterVerse.Split(':');
            int chapter = int.Parse(chapterVerseParts[0]);
            int initialVerse = 0;
            int finalVerse = 0;
            
            if (chapterVerseParts.Length > 1)
            {
                string[] verseParts = chapterVerseParts[1].Split('-');
                initialVerse = int.Parse(verseParts[0]);
                
                if (verseParts.Length > 1)
                {
                    finalVerse = int.Parse(verseParts[1]);
                }
            }
            
            Reference scriptureReference = new Reference(book, chapter, initialVerse, finalVerse);
            Scripture scripture = new Scripture(scriptureReference, text, image);
            
            Console.WriteLine(scripture.Reference);
            Console.WriteLine(scripture.Text);
            Console.WriteLine(scripture.Image);
            
            Console.WriteLine("Press Enter to hide words or type 'quit' to return to the main menu");
            string option = Console.ReadLine();
            
            if (option.ToLower() == "quit")
                return;
            else
            {
                scripture.HideWords();  
            }
        }
    }

    static void LoadNewScripture()
    {
        Console.Clear();
        Console.WriteLine("Enter the book:");
        string book = Console.ReadLine();

        Console.WriteLine("Enter the chapter:");
        int chapter = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the initial verse:");
        int initialVerse = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the final verse (leave empty if there is only one verse):");
        string finalVerseStr = Console.ReadLine();
        int? finalVerse = null;
        if (!string.IsNullOrEmpty(finalVerseStr))
        {
            finalVerse = int.Parse(finalVerseStr);
        }

        Console.WriteLine("Enter the text:");
        string text = Console.ReadLine();

        Console.WriteLine("Enter the image:");
        string image = Console.ReadLine();

        Reference newReference = new Reference(book, chapter, initialVerse, finalVerse);
        Scripture newScripture = new Scripture(newReference, text, image);
        scriptureLibrary.Add(newScripture);

        SaveScriptureToFile(newScripture);

        Console.WriteLine("Scripture added successfully. Press any key to continue");
        Console.ReadKey();
    }

    static void SaveScriptureToFile(Scripture scripture)
    {
        string filePath = "Scriptures.txt";

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            string referenceString = scripture.Reference.ToString();
            string formattedReference = referenceString.Replace(":", "");

            writer.WriteLine($"{formattedReference}|{scripture.Text}|{scripture.Image}");
        }
    }

    static void LoadScriptureFromFile()
    {
        Console.Clear();
        Console.WriteLine("Enter the file path:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
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
                
                string[] referenceParts = reference.Split(':');
                if (referenceParts.Length >= 2)
                {
                    string bookChapter = referenceParts[0];
                    int initialVerse = 0;
                    int finalVerse = 0;
                    
                    string[] bookChapterParts = bookChapter.Split(' ');
                    if (bookChapterParts.Length >= 2)
                    {
                        string book = bookChapterParts[0];
                        int chapter = int.Parse(bookChapterParts[1]);
                        
                        string verseRange = referenceParts[1];
                        string[] verseRangeParts = verseRange.Split('-');
                        if (verseRangeParts.Length >= 1)
                        {
                            initialVerse = int.Parse(verseRangeParts[0]);
                            
                            if (verseRangeParts.Length >= 2)
                            {
                                finalVerse = int.Parse(verseRangeParts[1]);
                            }
                        }
                        
                        Reference newReference = new Reference(book, chapter, initialVerse, finalVerse);
                        Scripture newScripture = new Scripture(newReference, text, image);
                        scriptureLibrary.Add(newScripture);
                    }
                }
            }
        }
    }
}
