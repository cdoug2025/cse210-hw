//added the ability to delete an entry
using System;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string quit = "n";
        do
        {
            Console.WriteLine("Here are your available journal actions:");
            Console.WriteLine("1: Create a new entry");
            Console.WriteLine("2: Display all entries");
            Console.WriteLine("3: Delete an entry");
            Console.WriteLine("4: Save to a file");
            Console.WriteLine("5: Load from a file");
            Console.WriteLine("6: Quit");
            Console.Write("Please type the number of the action you would like to perform: ");
            string action = Console.ReadLine();
            Console.WriteLine();

            if (action == "1")
            {
                journal.AddEntry();
                Console.WriteLine("\nEntry recorded");
            }

            else if (action == "2")
            {
                journal.DisplayAll();
            }

            else if (action == "3")
            {
                journal.DeleteEntry();
            }

            else if (action == "4")
            {
                journal.SaveToFile();
                Console.WriteLine("\nFile saved");
            }

            else if (action == "5")
            {
                journal.LoadFromFile();
                Console.WriteLine("\nFile loaded");
            }

            else if (action == "6")
            {
                quit = "y";
            }

            else
            {
                Console.WriteLine("Invalid action. Please make sure you typed the correct number");
            }

            if (quit != "y")
            {
                Console.ReadLine();
            }
        } while (quit != "y");
    }
}