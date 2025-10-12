public class ChecklistGoal : Goal
{
    private int _timesCompleted;

    //points for completing the bonus
    private int _pointBonus;

    //times goal must br completed for bonus
    private int _timesCompletedBonus;

    //difficulty of the bonus
    private string _difficultyBonus;

    //for creating a new goal
    public ChecklistGoal(string shortName, string description, string difficulty, int timesCompletedBonus, string difficultyBonus) : base(shortName, description, difficulty)
    {
        _timesCompletedBonus = timesCompletedBonus;
        _timesCompleted = 0;
        _difficultyBonus = difficultyBonus;

        if (difficultyBonus == "hard")
        {
            _pointBonus = 1000;
        }

        else if (difficultyBonus == "medium")
        {
            _pointBonus = 500;
        }

        //if difficultyBonus is easy or any invalid input to prevent errors
        else
        {
            _pointBonus = 100;
        }
    }

    //for loading from a file
    public ChecklistGoal(string shortName, string description, string difficulty, int timesCompletedBonus, string difficultyBonus, int timesCompleted) : base(shortName, description, difficulty)
    {
        _timesCompletedBonus = timesCompletedBonus;
        _timesCompleted = timesCompleted;
        _difficultyBonus = difficultyBonus;

        if (difficultyBonus == "hard")
        {
            _pointBonus = 1000;
        }

        else if (difficultyBonus == "medium")
        {
            _pointBonus = 500;
        }

        //if difficultyBonus is easy or any invalid input to prevent errors
        else
        {
            _pointBonus = 100;
        }
    }

    public override int RecordEvent()
    {
        _timesCompleted += 1;
        int pointValue = GetPointValue();

        //award _timesCompletedBonus if the goal has been completed _timesCompletedBonus times
        if (_timesCompleted == _timesCompletedBonus)
        {
            pointValue += _pointBonus;
        }

        return pointValue;
    }

    public override int SetPointValueEasy()
    {
        return 10;
    }

    public override int SetPointValueMedium()
    {
        return 50;
    }

    public override int SetPointValueHard()
    {
        return 100;
    }

    public override bool IsCompleted()
    {
        if (_timesCompleted >= _timesCompletedBonus)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public override string GetDescription()
    {
        return $"[{_timesCompleted}/{_timesCompletedBonus}] {GetDescriptionBase()} | Full completion difficulty: {_difficultyBonus}";
    }

    public override string GetStringRepresentation()
    {
        return $"checklist,{GetStringRepresentationBase()},{_timesCompletedBonus},{_difficultyBonus},{_timesCompleted}";
    }
}