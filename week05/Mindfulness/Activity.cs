using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration) => _duration = duration;
    public int GetDuration() => _duration;

    public void DisplayStartingMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.ResetColor();

        Console.WriteLine(_description);
        Console.WriteLine("How long, in seconds, would you like this session?");
        int seconds = int.Parse(Console.ReadLine());
        SetDuration(seconds);

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Well done!");
        Console.ResetColor();

        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    // 🔄 Spinner animation
    protected void ShowSpinner(int seconds)
    {
        char[] sequence = { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int counter = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(sequence[counter % sequence.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            counter++;
        }
    }

    // ⏳ Countdown animation
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
