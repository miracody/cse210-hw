// i added player stats tracking including score, level, total goals completed, streaks, and badges
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
