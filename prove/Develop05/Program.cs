using System;
using System.IO;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Goal Tracker Program! ");
        Menu();
    }
    public static void Menu()
    {
        int menuChoice = -1;
        int points = 0;
        List<SimpleGoal> simpleGoals = new List<SimpleGoal>();
        List<EternalGoal> eternalGoals = new List<EternalGoal>();
        List<ChecklistGoal> checklistGoals = new List<ChecklistGoal>();
        Console.WriteLine($"You have {points} points.");
        while (menuChoice != 6)
        {
            Console.WriteLine("");
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {

                case 1:
                    // Create New Goal
                    Console.WriteLine("The types of goals are:");
                    Console.WriteLine("1. Simple Goal ");
                    Console.WriteLine("2. Eternal Goal ");
                    Console.WriteLine("3. Checklist Goal ");
                    Console.Write("Which type of goal would you like to create? ");
                    int goalChoice = int.Parse(Console.ReadLine());
                    Console.Write($"What is the name of your goal? ");
                    string goalName = Console.ReadLine();
                    Console.Write($"What is a short description of your goal? ");
                    string goalDescription = Console.ReadLine();
                    Console.Write($"What is the amount of points associated with this goal? ");
                    int goalPointValue = int.Parse(Console.ReadLine());
                    switch (goalChoice)
                    {
                        case 1:
                            // Simple Goal Creation!
                            SimpleGoal aSimpleGoalPlease = new SimpleGoal(goalName, goalDescription, goalPointValue, false);
                            simpleGoals.Add(aSimpleGoalPlease);
                            break;

                        case 2:
                            // Eternal Goal Creation!
                            EternalGoal oneEternalGoalPlease = new EternalGoal(goalName, goalDescription, goalPointValue);
                            eternalGoals.Add(oneEternalGoalPlease);
                            break;

                        case 3:
                            // Checklist Goal Creation!
                            Console.Write($"How many times does this goal need to be accomplished for a bonus?");
                            int completionIterations = int.Parse(Console.ReadLine());
                            Console.Write($"What is the amount of bonus points for accomplishing the goal? ");
                            int goalBonusPoints = int.Parse(Console.ReadLine());
                            ChecklistGoal aChecklistGoalIfIMay = new ChecklistGoal(goalName, goalDescription, goalPointValue, goalBonusPoints, completionIterations, 0, false);
                            checklistGoals.Add(aChecklistGoalIfIMay);
                            break;
                    }
                    break;


                case 2:
                    // List Goals
                    int numberOfGoals = 0;
                    foreach (SimpleGoal sGoal in simpleGoals)
                    {
                        numberOfGoals++;
                        if (sGoal.GetCompletionStatus() == true)
                        {
                            Console.WriteLine($"{numberOfGoals}. [X] {sGoal.GetName()} ({sGoal.GetDescription()})");
                        }
                        else
                        {
                            Console.WriteLine($"{numberOfGoals}. [ ] {sGoal.GetName()} ({sGoal.GetDescription()})");
                        }
                    }

                    foreach (EternalGoal eGoal in eternalGoals)
                    {
                        numberOfGoals++;
                        Console.WriteLine($"{numberOfGoals}. [ ] {eGoal.GetName()} ({eGoal.GetDescription()})");
                    }

                    foreach (ChecklistGoal cGoal in checklistGoals)
                    {
                        numberOfGoals++;
                        if (cGoal._isCompleted == true)
                        {
                            Console.WriteLine($"{numberOfGoals}. [X] {cGoal.GetName()} ({cGoal.GetDescription()}) -- Currently Completed: {cGoal._currentIteration}/{cGoal._iteration}");
                        }
                        else
                        {
                            Console.WriteLine($"{numberOfGoals}. [ ] {cGoal.GetName()} ({cGoal.GetDescription()}) -- Currently Completed: {cGoal._currentIteration}/{cGoal._iteration}");
                        }
                    }

                    break;


                case 3:
                    // Save Goals
                    Console.Write("What is the file to save your goals to? ");
                    string fileName = Console.ReadLine();
                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        outputFile.WriteLine($"{points}");
                        foreach (SimpleGoal sGoal in simpleGoals)
                        {
                            outputFile.WriteLine($"SimpleGoal:{sGoal.GetName()},{sGoal.GetDescription()},{sGoal.GetPoints()},{sGoal.GetCompletionStatus()}");
                        }
                        foreach (EternalGoal eGoal in eternalGoals)
                        {
                            outputFile.WriteLine($"EternalGoal:{eGoal.GetName()},{eGoal.GetDescription()},{eGoal.GetPoints()}");
                        }
                        foreach (ChecklistGoal cGoal in checklistGoals)
                        {
                            outputFile.WriteLine($"ChecklistGoal:{cGoal.GetName()},{cGoal.GetDescription()},{cGoal.GetPoints()},{cGoal.GetBonusPoints()},{cGoal._currentIteration}/{cGoal._iteration}");
                        }
                    }
                    break;


                case 4:
                    // Load Goals
                    Console.Write("What is the filename for the goal file? ");
                    string readFile = Console.ReadLine();

                    try
                    {
                        string[] lines = File.ReadAllLines(readFile);

                        if (lines.Length > 0)
                        {
                            points = int.Parse(lines[0]);

                            simpleGoals.Clear();
                            eternalGoals.Clear();
                            checklistGoals.Clear();

                            for (int i = 1; i < lines.Length; i++)
                            {
                                string line = lines[i];

                                if (line.StartsWith("SimpleGoal:"))
                                {
                                    string goalData = line.Substring(11);
                                    string[] parts = goalData.Split(',');

                                    if (parts.Length >= 4)
                                    {
                                        string name = parts[0];
                                        string description = parts[1];
                                        int goalPoints = int.Parse(parts[2]);
                                        bool isComplete = bool.Parse(parts[3]);

                                        SimpleGoal loadedGoal = new SimpleGoal(name, description, goalPoints, isComplete);
                                        simpleGoals.Add(loadedGoal);
                                    }
                                }
                                else if (line.StartsWith("EternalGoal:"))
                                {
                                    string goalData = line.Substring(12);
                                    string[] parts = goalData.Split(',');

                                    if (parts.Length >= 3)
                                    {
                                        string name = parts[0];
                                        string description = parts[1];
                                        int goalPoints = int.Parse(parts[2]);

                                        EternalGoal loadedGoal = new EternalGoal(name, description, goalPoints);
                                        eternalGoals.Add(loadedGoal);
                                    }
                                }
                                else if (line.StartsWith("ChecklistGoal:"))
                                {
                                    string goalData = line.Substring(14);
                                    string[] parts = goalData.Split(',');
                                    if (parts.Length >= 5)
                                    {
                                        string name = parts[0];
                                        string description = parts[1];
                                        int goalPoints = int.Parse(parts[2]);
                                        int bonusPoints = int.Parse(parts[3]);
                                        string iterationPart = parts[4];
                                        string[] iterationParts = iterationPart.Split('/');
                                        if (iterationParts.Length == 2)
                                        {
                                            int currentIteration = int.Parse(iterationParts[0]);
                                            int totalIteration = int.Parse(iterationParts[1]);
                                            bool isCompleted = (currentIteration >= totalIteration);
                                            ChecklistGoal loadedGoal = new ChecklistGoal(name, description, goalPoints, bonusPoints, totalIteration, currentIteration, isCompleted);
                                            checklistGoals.Add(loadedGoal);
                                        }
                                    }
                                }
                            }

                            Console.WriteLine($"Goals loaded successfully! Total points: {points}");
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found. Please make sure the filename is correct.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading goals: {ex.Message}");
                    }
                    break;


                case 5:
                    // Record Event
                    Console.WriteLine($"The goals are:");
                    int goalNumber = 1;

                    foreach (SimpleGoal sGoal in simpleGoals)
                    {
                        if (sGoal.GetCompletionStatus() == true)
                        {
                            Console.WriteLine($"{goalNumber}. [X] {sGoal.GetName()} ({sGoal.GetDescription()})");
                        }
                        else
                        {
                            Console.WriteLine($"{goalNumber}. [ ] {sGoal.GetName()} ({sGoal.GetDescription()})");
                        }
                        goalNumber++;
                    }

                    foreach (EternalGoal eGoal in eternalGoals)
                    {
                        Console.WriteLine($"{goalNumber}. [ ] {eGoal.GetName()} ({eGoal.GetDescription()})");
                        goalNumber++;
                    }

                    foreach (ChecklistGoal cGoal in checklistGoals)
                    {
                        if (cGoal._isCompleted == true)
                        {
                            Console.WriteLine($"{goalNumber}. [X] {cGoal.GetName()} ({cGoal.GetDescription()}) -- Currently Completed: {cGoal._currentIteration}/{cGoal._iteration}");
                        }
                        else
                        {
                            Console.WriteLine($"{goalNumber}. [ ] {cGoal.GetName()} ({cGoal.GetDescription()}) -- Currently Completed: {cGoal._currentIteration}/{cGoal._iteration}");
                        }
                        goalNumber++;
                    }
                    Console.WriteLine();
                    Console.Write($"Which goal did you accomplish? ");
                    int selectedGoal = int.Parse(Console.ReadLine());

                    int currentGoalNumber = 1;
                    bool goalFound = false;

                    foreach (SimpleGoal sGoal in simpleGoals)
                    {
                        if (currentGoalNumber == selectedGoal)
                        {
                            goalFound = true;
                            if (sGoal.GetCompletionStatus() == true)
                            {
                                Console.WriteLine("This goal is already completed!");
                            }
                            else
                            {
                                sGoal.IsComplete();
                                points += sGoal.GetPoints();
                                Console.WriteLine($"Congratulations! You earned {sGoal.GetPoints()} points!");
                                Console.WriteLine($"You now have {points} points.");
                            }
                            break;
                        }
                        currentGoalNumber++;
                    }

                    if (!goalFound)
                    {
                        foreach (EternalGoal eGoal in eternalGoals)
                        {
                            if (currentGoalNumber == selectedGoal)
                            {
                                goalFound = true;
                                // Step 4: Handle EternalGoal
                                points += eGoal.GetPoints();
                                Console.WriteLine($"Congratulations! You earned {eGoal.GetPoints()} points!");
                                Console.WriteLine($"You now have {points} points.");
                                break;
                            }
                            currentGoalNumber++;
                        }
                    }

                    if (!goalFound)
                    {
                        foreach (ChecklistGoal cGoal in checklistGoals)
                        {
                            if (currentGoalNumber == selectedGoal)
                            {
                                goalFound = true;
                                if (cGoal._isCompleted == true)
                                {
                                    Console.WriteLine("This goal is already fully completed!");
                                }
                                else
                                {
                                    cGoal._currentIteration++;
                                    points += cGoal.GetPoints();

                                    Console.WriteLine($"Congratulations! You earned {cGoal.GetPoints()} points!");

                                    if (cGoal._currentIteration >= cGoal._iteration)
                                    {
                                        cGoal._isCompleted = true;
                                        points += cGoal.GetBonusPoints();
                                        Console.WriteLine($"Bonus! You completed the goal and earned {cGoal.GetBonusPoints()} bonus points!");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Progress: {cGoal._currentIteration}/{cGoal._iteration} completed.");
                                    }

                                    Console.WriteLine($"You now have {points} points.");
                                }
                                break;
                            }
                            currentGoalNumber++;
                        }
                    }
                    if (!goalFound)
                    {
                        Console.WriteLine("Invalid goal selection. Please try again.");
                    }

                    break;


                case 6:
                    // Quit
                    Console.WriteLine("Thank you!");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}