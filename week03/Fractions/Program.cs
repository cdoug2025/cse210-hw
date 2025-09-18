using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new();
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());

        fraction.SetTop(5);
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());

        Fraction fraction2 = new(3, 4);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new(1, 3);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}