using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    private static List<Goal> goals;
    private static string fileName = string.Empty;
    private static int totalPointsEarned = 0;
    
    public static void Main(string[] args)
    {
        goals = new List<Goal>();

        int option;

        do
        {
            UpdateTotalPointsEarned();

            Console.WriteLine("Select an option:\n 1.Create New Goal\n 2.List Goals\n 3.Save Goals\n 4.Load Goals\n 5.Record Event\n 6.Quit");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateNewGoal();
                    Console.WriteLine();
                    break;
                case 2:
                    ListGoals();
                    Console.WriteLine();
                    break;
                case 3:
                    SaveGoals();
                    Console.WriteLine();
                    break;
                case 4:
                    LoadGoals();
                    Console.WriteLine();
                    break;
                case 5:
                    RecordEvent();
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Thanks for using the goal tracker. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    Console.WriteLine();
                    break;
            }
        } while (option != 6);
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine("Select a goal type:\n 1.Simple Goal\n 2.Eternal Goal\n 3.Checklist Goal");

        int option = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the description of the goal:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the points for each completation of the goal:");
        int pointsForEachCompletion = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("Enter the points neccesary to level up");
                int pointsNecessaryByLevel = int.Parse(Console.ReadLine());
                SimpleGoal simpleGoal = new SimpleGoal(name, description, pointsForEachCompletion, pointsNecessaryByLevel);
                goals.Add(simpleGoal);
                Console.WriteLine($"The simple goal '{name}' has been created.");
                break;
            case 2:
                Console.WriteLine("Enter the points neccesary to level up");
                int pointsNecessaryByLevel2 = int.Parse(Console.ReadLine());
                EternalGoal eternalGoal = new EternalGoal(name, description, pointsForEachCompletion, pointsNecessaryByLevel2);
                goals.Add(eternalGoal);
                Console.WriteLine($"The eternal goal '{name}' has been created.");
                break;
            case 3:
                Console.WriteLine("Enter the number of times to complete the goal:");
                int numberOfTimesToComplete = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the completetion bonus");
                int completionBonus = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the number of times needed to complete the goal:");
                int numberNeddedForCompletion = int.Parse(Console.ReadLine());

                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, pointsForEachCompletion,numberOfTimesToComplete, 0, completionBonus, numberNeddedForCompletion);
                goals.Add(checklistGoal);
                Console.WriteLine($"The checklist goal '{name}' has been created.");
                break;
            default:
                Console.WriteLine("Invalid option. The goal could not be created.");
                break;
        }
    }

    private static void ListGoals()
    {
        if (goals.Count > 0)
        {
            Console.WriteLine("List of Goals:");

            foreach (Goal goal in goals)
            {
                Console.WriteLine();
                goal.DisplayProgress();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No goals available. Create a new goal to get started.");
        }
    }

    private static void SaveGoals()
    {
        if (goals.Count > 0)
        {
            Console.WriteLine("Enter the file name to save the goals:");
            fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Goal goal in goals)
                {
                    goal.SaveGoal(writer);
                    writer.WriteLine("#");
                }
            }
            Console.WriteLine("Goals saved succesfully");
        }
        else
        {
            Console.WriteLine("No goals avaible to save.");
        }
    }

    private static void LoadGoals()
    {
        Console.WriteLine("Enter the name of the file to load the goals:");
        fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            List<Goal> loadedGoals = new List<Goal>(); 
            
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                Goal currentGoal = null;
                
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Type:"))
                    {
                        string goalType = line.Substring("Type:".Length).Trim();
                        
                        switch (goalType)
                        {
                            case nameof(SimpleGoal):
                                currentGoal = new SimpleGoal("", "", 0, 0);
                                break;
                            case nameof(EternalGoal):
                                currentGoal = new EternalGoal("", "", 0, 0);
                                break;
                            case nameof(ChecklistGoal):
                                currentGoal = new ChecklistGoal("", "", 0, 0, 0, 0, 0);
                                break;
                            default:
                                Console.WriteLine("Invalid goal type. Skipping goal.");
                                currentGoal = null;
                                break;
                        }
                    }
                    else if (line == "#")
                    {
                        if (currentGoal != null)
                        {
                            loadedGoals.Add(currentGoal);
                            currentGoal = null;
                        } 
                    }
                    else if (currentGoal != null)
                    {
                        string[] parts = line.Split(':');
                        string propertyName = parts[0].Trim();
                        string propertyValue = parts[1].Trim();
                        
                        switch (propertyName)
                        {
                            case "Name":
                                currentGoal.Name = propertyValue;
                                break;
                            case "Description":
                                currentGoal.Description = propertyValue;
                                break;
                            case "Completed":
                                currentGoal.Completed = bool.Parse(propertyValue);
                                break;
                            case "Points For Each Completion":
                                currentGoal.PointsForEachCompletion = int.Parse(propertyValue);
                                break;
                            case "Points Earned":
                                currentGoal.PointsEarned = int.Parse(propertyValue);
                                break;
                            case "Level":
                                if (currentGoal is SimpleGoal simpleGoal)
                                {
                                    simpleGoal.Level = int.Parse(propertyValue);
                                }
                                else if (currentGoal is EternalGoal eternalGoal)
                                {
                                    eternalGoal.Level = int.Parse(propertyValue);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid goal type. Skipping goal.");
                                    currentGoal = null;
                                }
                                break;
                            case "Points Necessary By Level":
                                if (currentGoal is SimpleGoal simpleGoal2)
                                {
                                    simpleGoal2.PointsNecessaryByLevel = int.Parse(propertyValue);
                                }
                                else if (currentGoal is EternalGoal eternalGoal2)
                                {
                                    eternalGoal2.PointsNecessaryByLevel = int.Parse(propertyValue);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid goal type. Skipping goal.");
                                    currentGoal = null;
                                }
                                break;
                            case "Number Of Times To Complete":
                                if (currentGoal is ChecklistGoal checklistGoal)
                                {
                                    checklistGoal.NumberOfTimesToComplete = int.Parse(propertyValue);
                                }
                                break;
                            case "Number Of Times Done":
                                if (currentGoal is ChecklistGoal checklistGoal2)
                                {
                                    checklistGoal2.NumberOfTimesDone = int.Parse(propertyValue);
                                }
                                break;
                            case "Completion Bonus":
                                if (currentGoal is ChecklistGoal checklistGoal3)
                                {
                                    checklistGoal3.CompletionBonus = int.Parse(propertyValue);
                                }
                                break;
                            case "Number Nedded For Completion":
                                if(currentGoal is ChecklistGoal checklistGoal4)
                                {
                                    checklistGoal4.NumberNeddedForCompletion = int.Parse(propertyValue);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid property name. Skipping property.");
                                break;
                        }
                    }
                }
            }
            
            goals = loadedGoals;
            
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found. Loading goals canceled.");
        }
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Select the goal to record an event:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int index;
        bool validSelection = false;

        do
        {
            Console.WriteLine("Enter the index of the goal: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out index) && index >= 1 && index <= goals.Count)
            {
                validSelection = true;
                index--;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid index.");
            }
        }while (!validSelection);

        Goal selectedGoal = goals[index];
        selectedGoal.CompleteGoal();
        Console.WriteLine("Event recorded successfully.");
        Console.WriteLine();
        Console.WriteLine($"Congratulations! You have earned {selectedGoal.PointsForEachCompletion} points.");

        if (!string.IsNullOrEmpty(fileName))
        {
            SaveGoalsToFile(fileName);
        }
        else
        {
            Console.WriteLine("File name is null or empty. Event recorded, but goals not saved.");
        }
        
        UpdateTotalPointsEarned();
    }

    private static void UpdateGoalInFile(string fileName)
    {
        if (goals.Count > 0)
        {
            List<Goal> updatedGoals = new List<Goal>();
            
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Goal goal in goals)
                {
                    if (goal.Completed)
                    {
                        goal.CompleteGoal();
                    }
                    goal.SaveGoal(writer);
                    writer.WriteLine("#");
                    updatedGoals.Add(goal);
                }
            }
            
            goals = updatedGoals;
            
            Console.WriteLine("Goal updated in the file successfully.");
        }
        else
        {
            Console.WriteLine("No goals available to update.");
        }
    }
    private static void SaveGoalsToFile(string fileName)
    {
        if (goals.Count > 0)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Goal goal in goals)
                {
                    goal.SaveGoal(writer);
                    writer.WriteLine("#");
                }
            }
            
            Console.WriteLine("Goals saved to file successfully.");
        }
        else
        {
            Console.WriteLine("No goals available to save.");
        }
    }

    private static void UpdateTotalPointsEarned()
    {
        totalPointsEarned = goals.Sum(goal => goal.PointsEarned);
        Console.WriteLine($"You have {totalPointsEarned} points.");
        Console.WriteLine();
    }
}
