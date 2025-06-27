using System.Formats.Asn1;

class Shape
{
    protected string _color;

    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }

    public virtual double GetArea()
    {
        double area = 2;
        return area;
    }
    public Shape(string color)
    {
        _color = color;
    }
}