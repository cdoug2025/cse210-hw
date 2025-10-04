public class ReflectionActivity : Activity
{
    private int _timeQuestionDisplay;

    List<string> _prompts = new([
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ]);

    List<string> _questions = new([
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ]);

    public ReflectionActivity(string activityType) : base(activityType)
    {
        _timeQuestionDisplay = 8; //seconds
        SetDescription("This activity will help you reflect on your life by giving you a random prompt. This will help you realize how you can use your strengths in other aspects of your life as well.");
    }

    private string GetRandomItem(List<string> itemList)
    {
        Random random = new();
        int randomIndex = random.Next(0, itemList.Count);
        return itemList[randomIndex];
    }

    public void SetTimeQuestion(int timeQuestionDisplay)
    {
        _timeQuestionDisplay = timeQuestionDisplay;
    }

    public void Run()
    {
        //starting message
        Console.Clear();
        DisplayStartMessage();

        //begin exercise
        string prompt = GetRandomItem(_prompts);
        DateTime endtime = DateTime.Now.AddSeconds(GetTimeInSeconds());
        while (DateTime.Now < endtime)
        {
            //write prompt
            Console.Clear();
            Console.WriteLine(prompt);

            //display random question and pause
            Console.WriteLine($"\n{GetRandomItem(_questions)}");
            Pause(_timeQuestionDisplay);
        }

        //finish exercise
        DisplayEndMessage();
    }
}









// ReflectionActivity
// ----------
// * _prompts : List<string>
// * _questions : List<string>
// ----------
// * ReflectionActivity()
// ----------
// * GetRandomItem(itemList List<string>) : string
// * DisplayReflection() : void