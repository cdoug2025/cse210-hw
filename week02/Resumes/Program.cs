using System;

class Program
{
    static void Main(string[] args)
    {
        //add resume
        Resume myResume = new Resume();

        //name
        Console.Write("Please enter your name: ");
        myResume._name = Console.ReadLine();

        //add job
        string addJob;
        do
        {
            Job job = new Job();

            //company
            Console.Write("Please enter the company you worked for: ");
            job._company = Console.ReadLine();

            //position
            Console.Write("Please enter the position you worked: ");
            job._jobTitle = Console.ReadLine();

            //start year
            Console.Write("Please enter the year you started working this job: ");
            job._startYear = int.Parse(Console.ReadLine());
            
            //end year
            Console.Write("Please enter the year you finished working this job: ");
            job._endYear = int.Parse(Console.ReadLine());

            //add to list
            myResume._jobs.Add(job);

            //continue loop if user types yes or y
            Console.Write("Would you like to add another job? (y/n): ");
            addJob = Console.ReadLine();
            if (addJob == "yes")
            {
                addJob = "y";
            }
        } while (addJob == "y");

        //display resume
        Console.WriteLine();
        myResume.Display();
    }
}