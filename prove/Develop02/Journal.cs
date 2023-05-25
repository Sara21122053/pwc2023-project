using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private string _multimediaFolder = "Multimedia";

    public void Write()
    {
        Random rnd = new Random();
        string[] query = {"What have you learned today?", "What places did you visit?", "What was the best part of your day?", "What did you do in your free time?", "How did you feel today? Why?", "What would you like to do tomorrow?", "Which wish would you like to make today?", "Anything special you want to tell me today?"};
        int queryIndex = rnd.Next(query.Length);
        Console.WriteLine(query[queryIndex]);
        string answer = Console.ReadLine();

        _entries.Add(new Entry() {_questions = query[queryIndex], _entries = answer, _dateText = DateTime.Now});
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine("Date: {0}\n Question: {1}\n Entry: {2}", entry._dateText, entry._questions, entry._entries);
            
            Console.WriteLine("Multimedia files");
            foreach(string file in entry._multimediaFiles)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("------------------------");
        }
    }

    public void Save()
    {
        Console.WriteLine("Enter the name of the file to save the journal");
        string fileName = Console.ReadLine();

        using (StreamWriter file = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                file.WriteLine("{0}; {1}; {2}", entry._dateText, entry._questions, entry._entries);
            }
        }
    }

    public void Load()
    {
        Console.WriteLine("Enter the name of the file to load the journal");
        string fileName = Console.ReadLine();
        _entries.Clear();
        
        using (StreamReader file = new StreamReader(fileName))
        {
            string line;
            while((line = file.ReadLine()) != null)
            {
                string [] content = line.Split(';');
                Entry entry = new Entry() {_dateText = DateTime.Parse(content[0]), _questions = content[1], _entries = content[2]};
                
                _entries.Add(entry); 
            }
        }
    }

    public void LoadMultimedia()
    {
        Console.WriteLine("Enter the index of the entry to load multimedia files");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _entries.Count)
        {
            Console.WriteLine("Invalid index");
            return;
        }

        Console.WriteLine("Enter the name of the multimedia file (including the extension) or 'q' to finish");

        while (true)
        {
            string fileName = Console.ReadLine();
            if (fileName == "q")
            {
                break;
            }

            string sourceFilePath = Path.Combine(_multimediaFolder, fileName);
            if (!File.Exists(sourceFilePath))
            {
                Console.WriteLine("The file does not exist");
                continue;
            }

            string destFilePath = Path.Combine(_multimediaFolder, _entries[index]._dateText.ToString("yyyy-MM-ddTHHmmss") + "_" + fileName);
            File.Copy(sourceFilePath, destFilePath, true);
            _entries[index]._multimediaFiles.Add(destFilePath);
        }
    }
}
