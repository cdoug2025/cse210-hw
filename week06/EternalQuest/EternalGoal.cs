public class EternalGoal : Goal
{
    private int _timesCompleted;

    //for creating a new goal
    public EternalGoal(string shortName, string description, string difficulty) : base(shortName, description, difficulty)
    {
        _timesCompleted = 0;
    }

    //for loading from a file
    public EternalGoal(string shortName, string description, string difficulty, int timesCompleted) : base(shortName, description, difficulty)
    {
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        _timesCompleted += 1;
        return GetPointValue();
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

    public override string GetDescription()
    {
        return $"[{_timesCompleted}] {GetDescriptionBase()}";
    }

    public override string GetStringRepresentation()
    {
        return $"eternal,{GetStringRepresentationBase()},{_timesCompleted}";
    }
}