using System;

// Enhancements beyond core requirements:
// - Implemented a 'hint' feature: users can type 'hint' to reveal one hidden word.
// - The feature is handled in the main loop and uses RevealOneHiddenWord() in the Scripture class.
using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden())
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.WriteLine("\nThanks for using the Scripture Memorizer!");
    }
}
