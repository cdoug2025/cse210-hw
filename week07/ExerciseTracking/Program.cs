using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new();

        Running running = new(30, 4.8);
        activities.Add(running);

        Cycling cycling = new(30, 9.6);
        activities.Add(cycling);

        Swimming swimming = new(30, 96);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}