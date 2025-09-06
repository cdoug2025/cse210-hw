using System;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //create list
        List<float> numbers = new List<float>();
        float inputNumber;
        do
        {
            Console.Write("Please type a number for the list: ");
            inputNumber = float.Parse(Console.ReadLine());
            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }
        } while (inputNumber != 0);

        //Handle empty list
        if (numbers.Count == 0)
        {
            numbers.Add(0);
        }

        //print list as typed
        Console.Write("\nYour number list is: [");
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i < numbers.Count - 1)
            {
                Console.Write($"{numbers[i]}, ");
            }
            else
            {
                Console.WriteLine($"{numbers[i]}]");
            }
        }

        //print sorted list
        numbers.Sort();
        Console.Write("Sorted from lowest to highest, it is: [");
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i < numbers.Count - 1)
            {
                Console.Write($"{numbers[i]}, ");
            }
            else
            {
                Console.WriteLine($"{numbers[i]}]");
            }
        }

        //sum
        float sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine($"The sum of your list is: {sum}");

        //average
        float average = sum / numbers.Count;
        Console.WriteLine($"The average of your list is: {average}");

        //smallest
        float smallest = numbers.Min();
        Console.WriteLine($"The smallest number on your list is: {smallest}");

        //largest
        float largest = numbers.Max();
        Console.WriteLine($"The largest number on your list is: {largest}");

        //if positive and negative numbers
        if (numbers.Min() < 0 && numbers.Max() > 0)
        {

            //smallest positive
            float smallestPositive = numbers.Where(n => n > 0).Min();
            Console.WriteLine($"The smallest positive number on your list is: {smallestPositive}");

            //largest negative
            float largestNegative = numbers.Where(n => n < 0).Max();
            Console.WriteLine($"The largest negative number on your list is: {largestNegative}");
        }
    }
}