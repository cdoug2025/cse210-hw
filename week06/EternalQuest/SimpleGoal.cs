public class SimpleGoal : Goal
{
    private bool _isCompleted;

    //for creating a new goal
    public SimpleGoal(string shortName, string description, string difficulty) : base(shortName, description, difficulty)
    {
        _isCompleted = false;
    }

    //for loading from a file
    public SimpleGoal(string shortName, string description, string difficulty, bool isCompleted) : base(shortName, description, difficulty)
    {
        _isCompleted = isCompleted;
    }

    public override int RecordEvent()
    {
        _isCompleted = true;
        return GetPointValue();
    }

    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    public override int SetPointValueEasy()
    {
        return 100;
    }

    public override int SetPointValueMedium()
    {
        return 500;
    }

    public override int SetPointValueHard()
    {
        return 1000;
    }

    public override string GetDescription()
    {
        string returnString = "";
        if (_isCompleted)
        {
            returnString += "[x] ";
        }

        else
        {
            returnString += "[ ] ";
        }

        return returnString += GetDescriptionBase();
    }

    public override string GetStringRepresentation()
    {
        return $"simple,{GetStringRepresentationBase()},{_isCompleted}";
    }
}