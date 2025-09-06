using System;

class Program
{
    static void Main(string[] args)
    {
        //get input from user
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());

        string gradeLetter;

        //determine letter
        if (gradePercentage >= 90)
        {
            gradeLetter = "n A";
        }
        else if (gradePercentage >= 80)
        {
            gradeLetter = " B";
        }
        else if (gradePercentage >= 70)
        {
            gradeLetter = " C";
        }
        else if (gradePercentage >= 60)
        {
            gradeLetter = " D";
        }
        else
        {
            gradeLetter = "n F";
        }

        //determine sign
        string gradeSign = "";

        if (!(gradeLetter == "n F"))
        {
            if ((gradePercentage % 10) >= 7 && !(gradeLetter == "n A"))
            {
                gradeSign = "+";
            }
            else if ((gradePercentage % 10) < 3)
            {
                gradeSign = "-";
            }
        }

        //print
            Console.WriteLine($"\nA grade percentage of {gradePercentage}% would give a{gradeLetter}{gradeSign}");
    }
}