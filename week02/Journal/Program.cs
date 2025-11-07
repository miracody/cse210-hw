// I added a mood selection feature to the journal entries.// The user can now select their mood from a list of emojis when creating a new journal entry.
using System;

class Program
{
    static void Main(string[] args)
    {
       Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Your choice: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Random rand = new Random();
                string prompt = prompts[rand.Next(prompts.Count)];
                Console.WriteLine(prompt);
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Console.WriteLine("How are you feeling today?");
                Console.WriteLine("1. 😊 Happy  2. 😐 Neutral  3. 😢 Sad  4. 😠 Angry  5. 😴 Tired");
                Console.Write("Choose a number: ");
                string moodChoice = Console.ReadLine();

                string moodEmoji = moodChoice switch
                {
                    "1" => "😊",
                    "2" => "😐",
                    "3" => "😢",
                    "4" => "😠",
                    "5" => "😴",
                    _ => "🤔"
                };

                string date = DateTime.Now.ToShortDateString();
                Entry entry = new Entry(date, prompt, response, moodEmoji);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
        }
    }
}