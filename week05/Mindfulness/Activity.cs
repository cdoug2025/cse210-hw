public class Activity
{
    private string _activityType;

    private string _description;

    private int _timeInSeconds;

    public Activity(string activityType)
    {
        _activityType = activityType;
        _timeInSeconds = 30;
        _description = "Not given";
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"Beginning {_activityType} activity\n");

        Console.WriteLine(_description);

        Console.WriteLine("\nPress enter to start!");
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Get Ready...");
        Pause(3);
    }

    public void DisplayEndMessage()
    {
        Console.Clear();
        Console.WriteLine("Congratulations!");
        Pause(2);
        Console.WriteLine($"\nYou have completed {_timeInSeconds} seconds of the {_activityType} activity!");
        Pause(5);
    }

    /// <summary>
    /// pauses the program and displays a spinner for the specified amount of time
    /// </summary>
    /// <param name="secondsToPause">The length of time in seconds to pause</param>
    protected void Pause(int secondsToPause)
    {
        //set end time and spinner characters
        DateTime endTime = DateTime.Now.AddSeconds(secondsToPause);
        List<string> spinner = new(["/", "-", "\\", "|"]);

        //display spinner
        for (int spinnerIndex = 0; DateTime.Now < endTime; spinnerIndex++)
        {
            if (spinnerIndex >= spinner.Count)
            {
                spinnerIndex = 0;
            }

            Console.Write($"\b \b{spinner[spinnerIndex]}");
            Thread.Sleep(250);
        }

        //leave empty line
        Console.Write("\b \b");
    }

    public void SetTimeInSeconds(int numberOfSeconds)
    {
        _timeInSeconds = numberOfSeconds;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetTimeInSeconds()
    {
        return _timeInSeconds;
    }
}