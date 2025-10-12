public class GoalManager
{
    private int _playerScore = 0;

    private List<Goal> _goals = new();

    public void Start()
    {
        bool quit = false;
        while (quit == false)
        {
            Console.Clear();
            Console.WriteLine("Welcom to the GoalQuest Program,");
            Console.WriteLine("A program that turns keeping goals into a game!");

            Console.WriteLine($"\nYou currently have {_playerScore} points");
            DisplayTitle();

            Console.WriteLine("\nSelect an option by typing its number:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. List Goals");
            Console.WriteLine("4. Delete a goal");
            Console.WriteLine("5. Options");
            Console.WriteLine("6. Quit");
            string goalQuestInput = Console.ReadLine();

            if (goalQuestInput == "1")
            {
                Console.Clear();
                CreateGoal();
            }

            else if (goalQuestInput == "2")
            {
                Console.Clear();
                RecordEvent();
            }

            else if (goalQuestInput == "3")
            {
                Console.Clear();
                ListGoals();
                Console.WriteLine("\nPress enter to return to root menu");
                Console.ReadLine();
            }

            else if (goalQuestInput == "4")
            {
                Console.Clear();
                DeleteGoal();
            }

            else if (goalQuestInput == "5")
            {
                Options();
            }

            else if (goalQuestInput == "6")
            {
                quit = true;
            }
        }
    }

    public void DisplayTitle()
    {
        if (_playerScore >= 100000)
        {
            Console.WriteLine("Goal Master");
        }

        else if (_playerScore >= 50000)
        {
            Console.WriteLine("Soccer Player");
        }

        else if (_playerScore >= 10000)
        {
            Console.WriteLine("Magical Goal Finisher");
        }

        else if (_playerScore >= 8000)
        {
            Console.WriteLine("Legendary Goal Finisher");
        }

        else if (_playerScore >= 6000)
        {
            Console.WriteLine("Goal Expert");
        }

        else if (_playerScore >= 4000)
        {
            Console.WriteLine("Goal Destroyer");
        }

        else if (_playerScore >= 2000)
        {
            Console.WriteLine("Ninja Goal");
        }

        else if (_playerScore >= 1000)
        {
            Console.WriteLine("Goal Beginner");
        }
        
        else if (_playerScore >= 0)
        {
            Console.WriteLine("No Title");
        }
    }

    //Create new Goal
    public void CreateGoal()
    {
        //get goal type
        Console.WriteLine("Type the number of the goal you would like to create:");
        Console.WriteLine("1. Simple goal: recording an event marks this as completed");
        Console.WriteLine("2. Eternal goal: repeatable, awards points when an event is recorded");
        Console.WriteLine("3. Checklist goal: hybrid of simple and eternal, repeatable up to a given amount of times");
        string goalType = Console.ReadLine();

        //get short name
        Console.WriteLine("\nEnter a short name for this goal:");
        string shortName = Console.ReadLine();

        //get desription
        Console.WriteLine("\nEnter a description for this goal:");
        string description = Console.ReadLine();

        //get difficulty
        Console.WriteLine("\nType the number of the difficulty of the goal (If input is invalid, defaults to easy):");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        string difficulty = Console.ReadLine();

        if (difficulty == "3")
        {
            difficulty = "hard";
        }

        else if (difficulty == "2")
        {
            difficulty = "medium";
        }

        //if difficulty == 1 or invalid input to prevent errors
        else
        {
            difficulty = "easy";
        }

        //create simple goal
        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(shortName, description, difficulty));
        }

        //create eternal goal
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(shortName, description, difficulty));
        }

        //create checklist goal
        else if (goalType == "3")
        {
            //get timesCompletedBonus
            Console.WriteLine("\nHow many times would you like to complete this before you get a bonus?");
            int timesCompletedBonus = int.Parse(Console.ReadLine());

            //get difficultyBonus
            Console.WriteLine($"\nType the number of the difficulty of getting the bonus for this goal (If input is invalid, defaults to easy):");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            string difficultyBonus = Console.ReadLine();

            if (difficultyBonus == "3")
            {
                difficultyBonus = "hard";
            }

            else if (difficultyBonus == "2")
            {
                difficultyBonus = "medium";
            }

            //if difficultyBonus == 1 or invalid input to prevent errors
            else
            {
                difficultyBonus = "easy";
            }
            
            //create goal
            _goals.Add(new ChecklistGoal(shortName, description, difficulty, timesCompletedBonus, difficultyBonus));
        }

        //invalid input
        else
        {
            Console.WriteLine("\nInvalid Input");
            Console.WriteLine($"No goal option exists for {goalType}");
            Console.WriteLine("Press enter to return to root menu");
            Console.ReadLine();
        }
    }

    public void RecordEvent()
    {
        bool listShown = ListGoals(true);
        if (listShown)
        {
            Console.WriteLine("\nType the number of the goal you would like to record an event in: ");
            string goalSelection = Console.ReadLine();
            //validator to prevent errors can go here
            int goalIndex = int.Parse(goalSelection) - 1;

            _playerScore += _goals[goalIndex].RecordEvent();
        }

        else
        {
            Console.WriteLine("No goals still in progress found. Try creating a new one!");
            Console.WriteLine("Press enter to return to root menu");
            Console.ReadLine();
        }
    }

    public void DeleteGoal()
    {
        bool listShown = ListGoals();
        if (listShown)
        {
            Console.WriteLine("\nType the number of the goal you would like to delete: ");
            string goalSelection = Console.ReadLine();
            int goalIndex = int.Parse(goalSelection) - 1;

            _goals.RemoveAt(goalIndex);
        }

        else
        {
            Console.WriteLine("No goals found. Try creating one!");
            Console.WriteLine("Press enter to return to root menu");
            Console.ReadLine();
        }
    }

    public bool ListGoals(bool hideCompleted = false)
    {
        //key
        Console.WriteLine("key: [Completion] Name | Difficulty | Description\n");

        //write each goal to the console
        int goalListIndex = 0;
        bool listShown = false;
        foreach (Goal goal in _goals)
        {
            if (hideCompleted == true)
            {
                if (goal.IsCompleted() == false)
                {
                    Console.WriteLine($"{goalListIndex + 1}. {goal.GetDescription()}");
                    goalListIndex++;
                    listShown = true;
                }
            }

            else
            {
                Console.WriteLine($"{goalListIndex + 1}. {goal.GetDescription()}");
                goalListIndex++;
                listShown = true;
            }
        }

        return listShown;
    }

    //Options
    public void Options()
    {
        bool quit = false;
        while (quit == false)
        {
            Console.Clear();
            Console.WriteLine("Options Menu");

            Console.WriteLine("\nSelect an option by typing its number:");
            Console.WriteLine("1. Save goals");
            Console.WriteLine("2. Load goals");
            Console.WriteLine("3. Back");
            string optionsInput = Console.ReadLine();

            if (optionsInput == "1")
            {
                SaveToFile();
            }

            else if (optionsInput == "2")
            {
                LoadFromFile();
            }

            else if (optionsInput == "3")
            {
                quit = true;
            }
        }
    }

    public void SaveToFile()
    {
        Console.WriteLine("\nEnter the name of the file you would like to save to (ex. goals.csv)");
        using (StreamWriter outputFile = new StreamWriter(Console.ReadLine()))
        {
            outputFile.WriteLine(_playerScore);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    
    public void LoadFromFile()
    {
        Console.WriteLine("\nEnter the name of the file you would like to read from (ex. goals.csv)");
        string[] lines = System.IO.File.ReadAllLines(Console.ReadLine());

        bool firstLine = true;
        foreach (string line in lines)
        {
            //set player score
            if (firstLine == true)
            {
                _playerScore = int.Parse(line);
                firstLine = false;
            }

            //Create goal objects
            else
            {
                //set line part values
                List<string> lineParts = line.Split(",").ToList();
                string goalType = lineParts[0];

                //fix names with commas
                while (lineParts[1][lineParts[1].Length - 1] != '"')
                {
                    lineParts[1] += lineParts[2];
                    lineParts.RemoveAt(2);
                }

                //get rid of qoutation marks
                lineParts[1] = lineParts[1][1..^1];

                string shortName = lineParts[1];
                string difficulty = lineParts[2];

                //fix descriptions with commas
                while (lineParts[3][lineParts[3].Length - 1] != '"')
                {
                    lineParts[3] += lineParts[4];
                    lineParts.RemoveAt(4);
                }

                //get rid of qoutation marks
                lineParts[3] = lineParts[3][1..^1];

                string description = lineParts[3];

                //load simple goal
                if (goalType == "simple")
                {
                    //values for simple goal
                    bool isCompleted = bool.Parse(lineParts[4]);

                    //create simple goal
                    _goals.Add(new SimpleGoal(shortName, description, difficulty, isCompleted));
                }

                //load eternal goal
                else if (goalType == "eternal")
                {
                    //values for eternal goal
                    int timesCompleted = int.Parse(lineParts[4]);

                    //create eternal goal
                    _goals.Add(new EternalGoal(shortName, description, difficulty, timesCompleted));
                }
                
                else if (goalType == "checklist")
                {
                    //values for checklist goal
                    int timesCompletedBonus = int.Parse(lineParts[4]);
                    string difficultyBonus = lineParts[5];
                    int timesCompleted = int.Parse(lineParts[6]);


                    //create checklist goal
                    _goals.Add(new ChecklistGoal(shortName, description, difficulty, timesCompletedBonus, difficultyBonus, timesCompleted));
                }
            }
        }
    }
}