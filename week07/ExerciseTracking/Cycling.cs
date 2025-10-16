public class Cycling : Activity
{
    private double _speed; //kph

    public Cycling(double minutes, double speed) : base("Cycling", minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed / 60 * _minutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }
}