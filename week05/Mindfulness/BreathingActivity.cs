public class BreathingActivity : Activity
{
    private int _timeBreatheIn; //seconds

    private int _timeBreatheOut; //seconds

    public BreathingActivity(string activityType) : base(activityType)
    {
        _timeBreatheIn = 5;
        _timeBreatheOut = 5;
        SetDescription("This activity will help you relax by focusing on your breathing. Take deep breaths in time with the program.");
    }

    public void SetBreathingTimes(int timeBreatheIn, int timeBreatheOut)
    {
        _timeBreatheIn = timeBreatheIn;
        _timeBreatheOut = timeBreatheOut;
    }

    public void Run()
    {
        //starting message
        Console.Clear();
        DisplayStartMessage();

        //begin exercise
        DateTime endtime = DateTime.Now.AddSeconds(GetTimeInSeconds());
        while (DateTime.Now < endtime)
        {
            //breathe in
            Console.Clear();
            Console.WriteLine("Breathe In...");
            for (int secondsLeft = _timeBreatheIn; secondsLeft > 0; secondsLeft--)
            {
                Console.Write($"\b \b{secondsLeft}");
                Thread.Sleep(1000);
            }

            //breathe out
            Console.Clear();
            Console.WriteLine("Breathe Out...");
            for (int secondsLeft = _timeBreatheOut; secondsLeft > 0; secondsLeft--)
            {
                Console.Write($"\b \b{secondsLeft}");
                Thread.Sleep(1000);
            }
        }

        //finish exercise
        DisplayEndMessage();
    }
}









// BreathingActivity
// ----------
// * _timeBreatheIn : int
// * _timeBreatheOut : int
// ----------
// * BreathingActivity()
// ----------
// * SetBreatheIn() : void
// * SetBreatheOut() : void
// * DisplayBreathing() : void