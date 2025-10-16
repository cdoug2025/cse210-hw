public abstract class Activity
{
    private string _activity;
    private string _date;

    protected double _minutes; //length of activity

    public Activity(string activity, double minutes)
    {
        _activity = activity;
        _date = $"{DateTime.Now.Day} {DateTime.Now:MMM} {DateTime.Now.Year}";
        _minutes = minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date} {_activity} ({_minutes} min): Distance {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}