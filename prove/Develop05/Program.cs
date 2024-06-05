using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

abstract class Goal
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Points { get; set; }

    public Goal(string title, string description, double points)
    {
        Title = title;
        Description = description;
        Points = points;
    }

    public abstract void ListGoal();
    public abstract string SerializeSelf();
    public abstract double RecordEvent();
}

class Simple : Goal
{
    public Simple() : base("Default Simple Goal", "Default Description", 100) { }

    public Simple(string title, string description, double points) : base(title, description, points) { }

    public override void ListGoal()
    {
        Console.WriteLine($"Simple Goal: {Title} - {Description} - {Points} points");
    }

    public override string SerializeSelf()
    {
        return $"simple:{Title}:{Description}:{Points}";
    }

    public override double RecordEvent()
    {
        Console.WriteLine($"Recording event for Simple Goal: {Title}");
        return Points;
    }
}

class Eternal : Goal
{
    public Eternal() : base("Default Eternal Goal", "Default Description", 50) { }

    public Eternal(string title, string description, double points) : base(title, description, points) { }

    public override void ListGoal()
    {
        Console.WriteLine($"Eternal Goal: {Title} - {Description} - {Points} points");
    }

    public override string SerializeSelf()
    {
        return $"eternal:{Title}:{Description}:{Points}";
    }

    public override double RecordEvent()
    {
        Console.WriteLine($"Recording event for Eternal Goal: {Title}");
        return Points;
    }
}

class Checklist : Goal
{
    public int StepsRequired { get; set; }
    public int StepsCompleted { get; set; }

    public Checklist() : base("Default Checklist Goal", "Default Description", 200)
    {
        StepsRequired = 5;
        StepsCompleted = 0;
    }

    public Checklist(string title, string description, double points, int stepsRequired, int stepsCompleted)
        : base(title, description, points)
    {
        StepsRequired = stepsRequired;
        StepsCompleted = stepsCompleted;
    }

    public override void ListGoal()
    {
        Console.WriteLine($"Checklist Goal: {Title} - {Description} - {Points} points - {StepsCompleted}/{StepsRequired} steps");
    }

    public override string SerializeSelf()
    {
        return $"checklist:{Title}:{Description}:{Points}:{StepsRequired}:{StepsCompleted}";
    }

    public override double RecordEvent()
    {
        if (StepsCompleted < StepsRequired)
        {
            StepsCompleted++;
            Console.WriteLine($"Recording event for Checklist Goal: {Title} - Step {StepsCompleted}/{StepsRequired}");
            if (StepsCompleted == StepsRequired)
            {
                return Points;
            }
        }
        return 0;
    }
}

class Program
{
    public static void ListGoals(List<Goal> Goals)
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.Write($"{i + 1}.");
            Goals[i].ListGoal();
        }
    }

    static void WriteString(string value, bool newLine = false, int speed = 10)
    {
        foreach (char character in value)
        {
            Console.Write(character);
            Thread.Sleep(speed);
        }
        if (newLine == true) { Console.Write("\n"); }
    }

    public static int LevelUp(int level, double points)
    {
        int newLevel = level;
        switch (level)
        {
            case 1:
                if (points >= 100) { newLevel = 2; }
                break;
            case 2:
                if (points >= 300) { newLevel = 3; }
                break;
            case 3:
                if (points >= 500) { newLevel = 4; }
                break;
            case 4:
                if (points >= 1000) { newLevel = 5; }
                break;
            case 5:
                if (points >= 1500) { newLevel = 6; }
                break;
            case 6:
                if (points >= 2250) { newLevel = 7; }
                break;
            case 7:
                if (points >= 3000) { newLevel = 8; }
                break;
            case 8:
                if (points >= 4000) { newLevel = 9; }
                break;
            case 9:
                if (points >= 5000) { newLevel = 10; }
                break;
        }
        if (level != newLevel)
        {
            WriteString($"Congratulations! You are Level {newLevel}!\n", true);
        }
        return newLevel;
    }

    static void Main(string[] args)
    {
        int input;
        List<Goal> Goals = new List<Goal>();
        double points = 0;
        int level = 1;
        string name = "";

        while (true)
        {
            level = LevelUp(level, points);
            Console.WriteLine("Menu Items:\n"
                            + "\t1. Create New Goal\n"
                            + "\t2. List Goals\n"
                            + "\t3. Save Goals\n"
                            + "\t4. Load Goals\n"
                            + "\t5. Record Event\n"
                            + "\t6. Quit");
            Console.Write("Select a choice from the menu:");
            input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("The types of Goals are:\n"
                            + "\t1. Simple Goal\n"
                            + "\t2. Eternal Goal\n"
                            + "\t3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create?");
                    input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Goals.Add(new Simple());
                            break;
                        case 2:
                            Goals.Add(new Eternal());
                            break;
                        case 3:
                            Goals.Add(new Checklist());
                            break;
                    }
                    break;
                case 2:
                    ListGoals(Goals);
                    break;
                case 3:
                    Console.Write("What would you like to name the file?");
                    name = Console.ReadLine() + ".txt";
                    using (StreamWriter file = new StreamWriter(name))
                    {
                        file.WriteLine(points + ":" + level);
                        for (int i = 0; i < Goals.Count; i++)
                        {
                            file.WriteLine(Goals[i].SerializeSelf());
                        }
                    }
                    break;
                case 4:
                    if (name == "")
                    {
                        Console.WriteLine("Please enter the filename(leave out the extension. Ex.: .txt): ");
                        name = Console.ReadLine() + ".txt";
                    }
                    string[] lines = System.IO.File.ReadAllLines(name);
                    points = double.Parse(lines[0].Split(":")[0]);
                    level = int.Parse(lines[0].Split(":")[1]);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(":");
                        switch (values[0])
                        {
                            case "simple":
                                Goals.Add(new Simple(values[1], values[2], double.Parse(values[3])));
                                break;
                            case "eternal":
                                Goals.Add(new Eternal(values[1], values[2], double.Parse(values[3])));
                                break;
                            case "checklist":
                                Goals.Add(new Checklist(values[1], values[2], double.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5])));
                                break;
                        }
                    }
                    break;
                case 5:
                    ListGoals(Goals);
                    Console.Write("\nWhich goal did you accomplish? ");
                    input = int.Parse(Console.ReadLine());
                    points += Goals[input - 1].RecordEvent();
                    break;
                case 6:
                    return;
            }
            WriteString($"\nYou have {points} points.\n", true);
        }
    }
}