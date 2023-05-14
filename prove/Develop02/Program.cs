using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
public class Questions
{
    private List<Answers> entries = new List<Answers>();
    private string multimediaFolder = "Multimedia";

    public void Write()
    {
        Random rnd = new Random();
        string[] query = {"What have you learned today?", "What places did you visit?", "What was the best part of your day?", "What did you do in your free time?", "How did you feel today? Why?", "What would you like to do tomorrow?", "Which wish would you like to make today?"};
        int queryIndex = rnd.Next(query.Length);
        Console.WriteLine(query[queryIndex]);
        string answer = Console.ReadLine();

        entries.Add(new Answers() {questions = query[queryIndex], answers = answer, dateText = DateTime.Now});
    }

    public void Show()
    {
        foreach (Answers entry in entries)
        {
            Console.WriteLine("Date: {0}\n Question: {1}\n Answer: {2}", entry.dateText, entry.questions, entry.answers);
            
            Console.WriteLine("Multimedia files");
            foreach(string file in entry.multimediaFiles)
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
            foreach (Answers entry in entries)
            {
                file.WriteLine("{0}; {1}; {2}", entry.dateText, entry.questions, entry.answers);
            }
        }
    }

    public void Load()
    {
        Console.WriteLine("Enter the name of the file to load the journal");
        string fileName = Console.ReadLine();
        entries.Clear();
        
        using (StreamReader file = new StreamReader(fileName))
        {
            string line;
            while((line = file.ReadLine()) != null)
            {
                string [] content = line.Split(';');
                Answers entry = new Answers() {dateText = DateTime.Parse(content[0]), questions = content[1], answers = content[2]};
                
                entries.Add(entry); 
            }
        }
    }

    public void LoadMultimedia()
    {
        Console.WriteLine("Enter the index of the entry to load multimedia files");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= entries.Count)
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

            string sourceFilePath = Path.Combine(multimediaFolder, fileName);
            if (!File.Exists(sourceFilePath))
            {
                Console.WriteLine("The file does not exist");
                continue;
            }

            string destFilePath = Path.Combine(multimediaFolder, entries[index].dateText.ToString("yyyy-MM-ddTHHmmss") + "_" + fileName);
            File.Copy(sourceFilePath, destFilePath, true);
            entries[index].multimediaFiles.Add(destFilePath);
        }
    }
}
