using System;
using System.Collections.Generic;
using System.IO;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped this week?",
        "What are things that make you happy?"
    };

    public ListingActivity() 
        : base("Listing Activity", "This activity will help you reflect on the good things in your life.") { }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);

        int duration = GetDuration();
        int elapsed = 0;
        List<string> responses = new List<string>();

        while (elapsed < duration)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            responses.Add(response);

            ShowSpinner(2);
            elapsed += 5;
        }

        Console.WriteLine($"You listed {responses.Count} items!");

        // Save responses to file
        File.WriteAllLines("listing_responses.txt", responses);
        Console.WriteLine("Your responses have been saved to listing_responses.txt");

        ActivityStats.AddActivity("Listing", duration);
        DisplayEndingMessage();
    }
}
