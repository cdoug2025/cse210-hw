public class ListingActivity : Activity
{
    List<string> _prompts = new([
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ]);

    public ListingActivity(string activityType) : base(activityType)
    {
        SetDescription("This activity will have you create a list of things that relate to a prompt");
    }

    private string GetRandomPrompt()
    {
        Random random = new();
        int randomIndex = random.Next(0, _prompts.Count);
        return _prompts[randomIndex];
    }

    public void Run()
    {
        //starting message
        Console.Clear();
        DisplayStartMessage();

        //begin exercise
        Console.Clear();
        Console.WriteLine($"{GetRandomPrompt()}\n");
        int itemCount = 0;
        DateTime endtime = DateTime.Now.AddSeconds(GetTimeInSeconds());
        while (DateTime.Now < endtime)
        {
            Console.ReadLine();
            itemCount += 1;
        }

        //finish exercise
        Console.WriteLine($"\nYou listed {itemCount} items!");
        Pause(3);
        DisplayEndMessage();
    }
}

   








// ListingActivity
// ----------
// * _prompts : List<string>
// ----------
// * ListingActivity()
// ----------
// * GetRandomPrompt() : string
// * DisplayListing() : void