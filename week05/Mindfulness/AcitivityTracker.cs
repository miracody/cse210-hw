public static class ActivityStats
{
    public static int TotalMinutes { get; private set; }
    public static int BreathingCount { get; private set; }
    public static int ReflectingCount { get; private set; }
    public static int ListingCount { get; private set; }

    public static void AddActivity(string type, int seconds)
    {
        TotalMinutes += seconds / 60; // convert to minutes
        if (type == "Breathing") BreathingCount++;
        if (type == "Reflecting") ReflectingCount++;
        if (type == "Listing") ListingCount++;
    }

    public static void ShowStats()
    {
        Console.WriteLine("\n--- Mindfulness Stats ---");
        Console.WriteLine($"Total Minutes: {TotalMinutes}");
        Console.WriteLine($"Breathing Sessions: {BreathingCount}");
        Console.WriteLine($"Reflecting Sessions: {ReflectingCount}");
        Console.WriteLine($"Listing Sessions: {ListingCount}");
    }
}
