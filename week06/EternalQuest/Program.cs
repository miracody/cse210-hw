// I added player stats tracking including score, level, total goals completed, streaks, and badges
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Eternal Quest ===");
        Console.WriteLine("Track your goals, earn points, and level up!\n");

        // Create the manager and start the interactive loop
        GoalManager manager = new GoalManager();
        manager.Start();

        Console.WriteLine("\nThanks for playing Eternal Quest! Keep striving for greatness 🚀");
    }
}
