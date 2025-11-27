using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you overcame fear."
    };

    private List<string> _usedPrompts = new List<string>();

    public ReflectingActivity() 
        : base("Reflecting Activity", "This activity will help you reflect on times in your life when you showed strength.") { }

    private string GetUniquePrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
            _usedPrompts.Clear();

        Random rand = new Random();
        string prompt;
        do
        {
            prompt = _prompts[rand.Next(_prompts.Count)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            string prompt = GetUniquePrompt();
            Console.WriteLine(prompt);
            ShowSpinner(5);
            elapsed += 5;
        }

        ActivityStats.AddActivity("Reflecting", duration);
        DisplayEndingMessage();
    }
}
