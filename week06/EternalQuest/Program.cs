// i added player stats tracking including score, level, total goals completed, streaks, and badges
using System;

partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Eternal Quest ===");
        Console.WriteLine("Track your goals, earn points, and level up!\n");

        GoalManager manager = new GoalManager();
        manager.Start();

        Console.WriteLine("\nThanks for playing Eternal Quest! Keep striving for greatness 🚀");
    }
}
