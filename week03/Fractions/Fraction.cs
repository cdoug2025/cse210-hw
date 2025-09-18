public class Fraction
{
    private int _topNum;
    private int _bottomNum;

    public Fraction()
    {
        _topNum = 1;
        _bottomNum = 1;
    }

    public Fraction(int topNum)
    {
        _topNum = topNum;
        _bottomNum = 1;
    }

    public Fraction(int topNum, int bottomNum)
    {
        _topNum = topNum;
        _bottomNum = bottomNum;
    }

    public int GetTop()
    {
        return _topNum;
    }

    public void SetTop(int topNum)
    {
        _topNum = topNum;
    }

    public int GetBottom()
    {
        return _bottomNum;
    }

    public void SetBottom(int bottomNum)
    {
        _bottomNum = bottomNum;
    }

    public string GetFractionString()
    {
        return $"{_topNum}/{_bottomNum}";
    }

    public double GetDecimalValue()
    {
        return (double)_topNum / _bottomNum;
    }
}