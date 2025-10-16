public class Swimming : Activity
{
    private int _laps; //laps in pool

    public Swimming(double minutes, int laps) : base("Swimming", minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000;
    }

    public override double GetSpeed()
    {
        return GetDistance() / _minutes * 60;
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }
}