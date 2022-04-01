internal class RN
{
    private int _wholeNumbers;
    private int _integers;
    public int WholeNumbers { get { return _wholeNumbers; } private set { value = _wholeNumbers; } } //Целые числа 
    public int Integers { get { return _integers; } private  set { value = _integers; } } //натуральные числа 


    public RN(int wholeNumbers, int integers)
    {
        if (Integers == 0)
        {
            throw new ArgumentException("The denominator cannot be equal to 0");
        }
        else
        {
            this.Integers = integers;
        }
        if (wholeNumbers !=0)
        {
            this.WholeNumbers = wholeNumbers > 0 ? wholeNumbers : -wholeNumbers;
            this.Integers = integers > 0 ? integers : -integers;         
        }
    }

    public static bool operator == (RN r1, RN r2)
    {
        return !(r1 is null) && !(r2 is null) && r1.WholeNumbers == r2.WholeNumbers && r1.Integers == r2.Integers;
    }

    public static bool operator !=(RN r1, RN r2)
    {
        return !(r1 == r2);
    }

    public static bool operator >(RN r1, RN r2)
    {
        return r1.WholeNumbers * r2.Integers > r1.Integers * r2.WholeNumbers;
    }

    public static bool operator <(RN r1, RN r2)
    {
        return r1.WholeNumbers * r2.Integers < r1.Integers * r2.WholeNumbers;
    }

    public static bool operator >=(RN r1, RN r2)
    {
        return !(r1 < r2);
    }

    public static bool operator <=(RN r1, RN r2)
    {
        return !(r1 > r2);
    }

    public static RN operator +(RN r1, RN r2)
    {
        return new RN(r1.WholeNumbers * r2.Integers + r2.WholeNumbers * r1.Integers, r1.Integers * r2.Integers);
    }

    public static RN operator -(RN r1, RN r2)
    {
        return new RN(r1.WholeNumbers * r2.Integers - r2.WholeNumbers * r1.Integers, r1.Integers * r2.Integers);
    }

    public static RN operator -(RN r)
    {
        return new RN(-r.WholeNumbers, r.Integers);
    }

    public static RN operator ++(RN r)
    {
        return new RN(r.WholeNumbers + r.Integers, r.Integers);
    }

    public static RN operator --(RN r)
    {
        return new RN(r.WholeNumbers - r.Integers, r.Integers);
    }

    public static RN operator *(RN r1, RN r2)
    {
        return new RN(r1.WholeNumbers * r2.WholeNumbers, r1.Integers * r2.Integers);
    }

    public static RN operator /(RN r1, RN r2)
    {
        return new RN(r1.WholeNumbers * r2.Integers, r1.Integers * r2.WholeNumbers);
    }

    public static RN operator %(RN r1, RN r2)
    {
        return new RN((r1.WholeNumbers * r2.Integers) % (r1.Integers * r2.WholeNumbers), r1.Integers * r2.Integers);
    }

    public static implicit operator float(RN r)
    {
        return (float)r.WholeNumbers / r.Integers;
    }

    public static implicit operator int(RN r)
    {
        return r.WholeNumbers / r.Integers;
    }

    public static explicit operator RN(int numerator)
    {
        return new RN(numerator, 1);
    }

    public override bool Equals(object? obj)
    {
        return obj is RN Rn && Rn.WholeNumbers == WholeNumbers && Rn.Integers == Integers;
    }

    protected bool Equals(RN other)
    {
        return WholeNumbers == other.WholeNumbers && Integers == other.Integers;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(WholeNumbers, Integers);
    }

    public override string ToString()
    {
        return $"Q= {WholeNumbers}/{Integers}";
    }
}



