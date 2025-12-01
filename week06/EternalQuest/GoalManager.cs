using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _totalGoalsCompleted;
    private int _streak;
    private List<string> _badges;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _totalGoalsCompleted = 0;
        _streak = 0;
        _badges = new List<string>();
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Quit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": DisplayPlayerInfo(); break;
                case "2": ListGoalNames(); break;
                case "3": ListGoalDetails(); break;
                case "4": CreateGoal(); break;
                case "5": RecordEvent(); break;
                case "6": SaveGoals(); break;
                case "7": LoadGoals(); break;
                case "8": running = false; break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score} | Level: {_level}");
        Console.WriteLine($"Total Goals Completed: {_totalGoalsCompleted}");
        Console.WriteLine($"Current Streak: {_streak}");
        Console.WriteLine("Badges: " + ( _badges.Count > 0 ? string.Join(", ", _badges) : "None yet"));
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1=Simple, 2=Eternal, 3=Checklist");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == "2")
            _goals.Add(new EternalGoal(name, desc, points));
        else if (type == "3")
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            int pointsEarned = _goals[choice].RecordEvent();
            _score += pointsEarned;
            _streak++;
            if (_goals[choice].IsComplete()) _totalGoalsCompleted++;

            Console.WriteLine($"You earned {pointsEarned} points!");

            CheckLevelUp();
            CheckBadges();
        }
    }

    private void CheckLevelUp()
    {
        if (_score >= _level * 100)
        {
            _level++;
            Console.WriteLine($"🎉 Congratulations! You reached Level {_level}!");
        }
    }

    private void CheckBadges()
    {
        int eternalCount = 0;
        int checklistCompleted = 0;

        foreach (Goal goal in _goals)
        {
            if (goal is EternalGoal) eternalCount++;
            if (goal is ChecklistGoal && goal.IsComplete()) checklistCompleted++;
        }

        if (eternalCount >= 5 && !_badges.Contains("Consistency Star"))
        {
            _badges.Add("Consistency Star");
            Console.WriteLine("🏅 Badge Earned: Consistency Star!");
        }

        if (checklistCompleted >= 3 && !_badges.Contains("Checklist Master"))
        {
            _badges.Add("Checklist Master");
            Console.WriteLine("🏅 Badge Earned: Checklist Master!");
        }

        if (_totalGoalsCompleted >= 10 && !_badges.Contains("Goal Getter"))
        {
            _badges.Add("Goal Getter");
            Console.WriteLine("🏅 Badge Earned: Goal Getter!");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            string type = parts[0];
            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6])));
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}
