
using System.Dynamic;

/// <summary>
/// Represents a fraction including a numerator and a denominator
/// This is more accurate than storing numbers in a double. 
/// </summary>
public class Fraction
{
    private int _numer;
    private int _denom;

    public Fraction()
    {
        _numer = 1;
        _denom = 1;
    }
    public Fraction(int whole)
    {
        _numer = whole;
        _denom = 1;
    }
    public Fraction(int numer, int denom)
    {
        _numer = numer;
        _denom = denom;
    }
    public int GetTop()
    {
        return _numer;
    }
    public void SetTop(int top)
    {
        _numer = top;
    }
    public int GetBottom()
    {
        return _denom;
    }
    public void SetBottom(int bottom)
    {
        _denom = bottom;
    }
    public string GetFractionString()
    {
        string fractionAsString = $"{_numer} / {_denom}";
        return fractionAsString;
    }
    public double GetDecimalValue()
    {
        double value = (double)_numer / (double)_denom;
        return value;
    }
}