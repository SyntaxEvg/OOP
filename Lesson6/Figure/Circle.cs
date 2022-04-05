using System.Drawing;

internal sealed class Circle : Point
{
    private double _radius;
    private const int Precision = 4;

    public double Radius => _radius;

    public Circle(Color color, bool isVisible, System.Drawing.Point center, double radius)
        : base(color, isVisible, center)
    {
        _radius = radius;
    }

    public void ChangeRadius(double changeTo)
    {
        _radius = changeTo;
    }
    /// <summary>
    /// площади прямоугольника
    /// </summary>
    /// <returns></returns>
    public double GetSquare()
    {
        return Math.Round(Math.PI * Math.Pow(Radius, 2), Precision);
    }

    public override string ToString()
    {
        return base.ToString() + $" Radius: {Radius}, площади прямоугольника: {GetSquare()}";
    }
}