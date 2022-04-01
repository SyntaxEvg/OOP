internal class ComplexNumb
{
    private double XReal;
    private double yi;

    public ComplexNumb(double v1, double v2)
    {
        this.XReal = v1;
        this.yi = v2;
    }
    public static ComplexNumb operator +(ComplexNumb x, ComplexNumb y)
    { 
        return new(x.XReal + y.XReal, x.yi + y.yi);
    }

    public static ComplexNumb operator -(ComplexNumb x, ComplexNumb y)
    {
        return new(x.XReal - y.XReal, x.yi - y.yi);
    }
    public static ComplexNumb operator *(ComplexNumb x, ComplexNumb y)
    { 
        return new(x.XReal * y.XReal - x.yi * y.yi, x.XReal * y.XReal + x.XReal * y.yi);
    }

    public static bool operator ==(ComplexNumb x, ComplexNumb y)
    {
        if (x is not null || y is not null)
        {
            return Math.Abs(x.XReal - y.XReal) <= Math.Abs(x.XReal) &&
               Math.Abs(x.yi - y.yi) <= Math.Abs(x.yi);
        }
        return false;
        
    }
    public static bool operator !=(ComplexNumb x, ComplexNumb y)
    {
        if (x is null || y is null)
            return true;

        var differenceReal = Math.Abs(x.XReal);
        var differenceImaginary = Math.Abs(x.yi);

        return Math.Abs(x.XReal - y.XReal) > differenceReal ||
               Math.Abs(x.yi - y.yi) > differenceImaginary;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj is ComplexNumb);
    }

    public bool Equals(ComplexNumb other)
    {
        return other is not null &&
               Math.Abs(this.XReal - other.XReal) <= Math.Abs(this.XReal) &&
               Math.Abs(this.yi - other.yi) <= Math.Abs(this.yi);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(XReal, yi);
    }
    public override string ToString() => $"{XReal}{(yi > 0 ? $" + {yi}i" : yi < 0 ? $" - {yi}i" : "")}";

}