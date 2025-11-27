using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") { }

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Breathe in...");
            Console.ResetColor();
            ShowCountdown(3);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Breathe out...");
            Console.ResetColor();
            ShowCountdown(3);

            elapsed += 6;
        }

        ActivityStats.AddActivity("Breathing", duration);
        DisplayEndingMessage();
    }
}
