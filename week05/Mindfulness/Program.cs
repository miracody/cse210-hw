//  I added the option for the user to continue to loop through muiltiple sessions until they type quit
// i added File saving for ListingActivity responses 
// I added a stats tracking feature to keep track of total minutes and number of sessions per activity type
using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflecting");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Show Stats");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectingActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    ActivityStats.ShowStats();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye! Stay mindful.");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}
