using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Shapes Polymorphism Demo ===");

        // Create shapes
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        // Put them in a list of Shape
        List<Shape> shapes = new List<Shape> { square, rectangle, circle };

        // Iterate and display color + area
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}
