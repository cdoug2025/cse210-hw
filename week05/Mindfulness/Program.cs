//I moved the prompt for activity time from inside the activity to an options menu
//You can set your own breathing time for the breathing activity in the options menu
//You can change how long a question is displayed for the reflection activity in the options menu
using System;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        //base values
        BreathingActivity breathingActivity = new("breathing");
        ReflectionActivity reflectionActivity = new("reflection");
        ListingActivity listingActivity = new("listing");
        bool quit = false;

        //main loop
        while (quit == false)
        {
            Console.Clear();

            //mindfulness menu
            Console.WriteLine("Welcome to the Mindfulness Program!\n");

            Console.WriteLine("Please select an option by typing its number below:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Options");
            Console.WriteLine("5. Quit");

            string mindfulnessInput = Console.ReadLine();

            //breathing Activity
            if (mindfulnessInput == "1")
            {
                breathingActivity.Run();
            }

            //reflection activity
            else if (mindfulnessInput == "2")
            {
                reflectionActivity.Run();
            }

            //listing activity
            else if (mindfulnessInput == "3")
            {
                listingActivity.Run();
            }

            //options
            else if (mindfulnessInput == "4")
            {
                OpenOptions(breathingActivity, reflectionActivity, listingActivity);
            }

            //quit
            else if (mindfulnessInput == "5" || mindfulnessInput == "")
            {
                quit = true;
            }
        }
    }

    /// <summary>
    /// Handles the options menu, letting length of activities and breathing time of breathing activities be changed
    /// </summary>
    /// <param name="breathingActivity">The breathing activity to be changed</param>
    /// <param name="reflectionActivity">The reflection activity to be changed</param>
    /// <param name="listingActivity">The listing activity to be changed</param>
    static void OpenOptions(BreathingActivity breathingActivity, ReflectionActivity reflectionActivity, ListingActivity listingActivity)
    {
        //options loop
        bool back = false;
        while (back == false)
        {
            Console.Clear();

            //options menu
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Change Activity Length");
            Console.WriteLine("2. Change Breathing Activity In/Out Length");
            Console.WriteLine("3. Change Reflection Activity Question Disply Length");
            Console.WriteLine("4. Back");
            string optionsInput = Console.ReadLine();

            //change activity length
            if (optionsInput == "1")
            {
                //get length
                Console.Clear();
                Console.WriteLine("How many seconds would you like an activity to last? (default: 30)");
                int activityLength = int.Parse(Console.ReadLine());

                //set length
                breathingActivity.SetTimeInSeconds(activityLength);
                reflectionActivity.SetTimeInSeconds(activityLength);
                listingActivity.SetTimeInSeconds(activityLength);
            }

            //change breathing activity in/out length
            else if (optionsInput == "2")
            {
                //get lengths
                Console.Clear();
                Console.WriteLine("How many seconds would you like to breathe in for? (default: 5)");
                int timeBreatheIn = int.Parse(Console.ReadLine());

                Console.WriteLine("How many seconds would you like to breathe out for? (default: 5)");
                int timeBreatheOut = int.Parse(Console.ReadLine());

                //set lengths
                breathingActivity.SetBreathingTimes(timeBreatheIn, timeBreatheOut);
            }

            //change reflection activity question display length
            else if (optionsInput == "3")
            {
                //get length
                Console.Clear();
                Console.WriteLine("How many seconds would you like a question to be displayed? (default: 8)");
                int timeQuestionDisplay = int.Parse(Console.ReadLine());

                //set lengths
                reflectionActivity.SetTimeQuestion(timeQuestionDisplay);
            }

            //back
            else if (optionsInput == "4" || optionsInput == "")
            {
                back = true;
            }
        }
    }
}