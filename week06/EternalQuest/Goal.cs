public abstract class Goal
{
    private string _shortName;

    private string _difficulty;

    private string _description;

    private int _pointValue;

    public Goal(string shortName, string description, string difficulty)
    {
        _shortName = shortName;
        _difficulty = difficulty;
        _description = description;

        if (difficulty == "hard")
        {
            _pointValue = SetPointValueHard();
        }

        else if (difficulty == "medium")
        {
            _pointValue = SetPointValueMedium();
        }

        //if difficulty is easy or any invalid input to prevent errors
        else
        {
            _pointValue = SetPointValueEasy();
        }
    }

    public abstract int RecordEvent();

    public virtual bool IsCompleted()
    {
        return false;
    }

    public abstract int SetPointValueEasy();

    public abstract int SetPointValueMedium();

    public abstract int SetPointValueHard();

    public int GetPointValue()
    {
        return _pointValue;
    }

    public abstract string GetDescription();

    /// <summary>
    /// A function that helps inherited classes display a description of their goal,
    /// called by inherited classes to get the info in this base class
    /// </summary>
    /// <returns>string</returns>
    protected string GetDescriptionBase()
    {
        return $"{_shortName} | {_difficulty} | {_description}";
    }

    public abstract string GetStringRepresentation();

    /// <summary>
    /// A function that helps write information of goals to a csv file so it can be read into similar goal objects after exiting the program,
    /// called by inherited classes to get the info in this base class
    /// </summary>
    /// <returns>
    /// string where _shortName, _difficulty, and _description is seperated by a comma with perentheses around _shortName and
    /// _description so it can be written to a csv file (ex. "Read scriptures",easy,"I want to read my scriptures every day")
    /// </returns>
    protected string GetStringRepresentationBase()
    {
        return $"\"{_shortName}\",{_difficulty},\"{_description}\"";
    }
}