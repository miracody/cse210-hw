using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _moodEmoji;

    public Entry(string date, string prompt, string response, string moodEmoji)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _moodEmoji = moodEmoji;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} {_moodEmoji}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }
}
