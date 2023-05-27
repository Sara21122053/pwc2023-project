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
        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine("There aren't scriptures in library. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
        Console.Clear();

        Console.WriteLine(scripture.Reference);
        Console.WriteLine(scripture.Text);
        Console.WriteLine(scripture.Image);

        Console.WriteLine("Press Enter to hide words or type 'quit' to retur to the main menu");
        string option = Console.ReadLine();

        if (option.ToLower() == "quit")
            return;

        HideWords(scripture);
    }

    static void LoadNewScripture()
    {
        Console.Clear();
        Console.WriteLine("Enter the reference:");
        string reference = Console.ReadLine();

        Console.WriteLine("Enter the text:");
        string text = Console.ReadLine();

        Console.WriteLine("Enter the image:");
        string image = Console.ReadLine();

        Reference newReference = new Reference(reference);
        Scripture newScripture = new Scripture(newReference, text, image);
        scriptureLibrary.Add(newScripture);

        Console.WriteLine("Scripture added successfuly. Press any key to continue");
        Console.ReadKey();
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

                Reference newReference = new Reference(reference);
                Scripture newScripture = new Scripture(newReference, text, image);
                scriptureLibrary.Add(newScripture);
            }
        }
    }
}
