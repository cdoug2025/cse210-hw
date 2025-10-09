using System;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new([
            new Square("red", 4),
            new Square("yellow", 1.05),
            new Rectangle("pink", 7, 3),
            new Rectangle("green", 8.45, 0.36),
            new Circle("blue", 2),
            new Circle("red", 6.08),
        ]);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The color of this {shape} is {shape.GetColor()} and the area is {shape.GetArea()}");
        }
    }
}