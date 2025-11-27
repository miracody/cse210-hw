using System;

class Program
{
    static void Main(string[] args)
    {
        // Test base class
        Assignment simple = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(simple.GetSummary());
        // Output: Samuel Bennett - Multiplication

        // Test MathAssignment
        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        // Output:
        // Roberto Rodriguez - Fractions
        // Section 7.3 Problems 8-19

        // Test WritingAssignment
        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
        // Output:
        // Mary Waters - European History
        // The Causes of World War II by Mary Waters
    }
}
