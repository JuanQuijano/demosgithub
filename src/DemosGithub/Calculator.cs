namespace DemosGithub;

/// <summary>
/// Provides basic arithmetic operations.
/// </summary>
public class Calculator
{
    /// <summary>Adds two numbers.</summary>
    public double Add(double a, double b) => a + b;

    /// <summary>Subtracts <paramref name="b"/> from <paramref name="a"/>.</summary>
    public double Subtract(double a, double b) => a - b;

    /// <summary>Multiplies two numbers.</summary>
    public double Multiply(double a, double b) => a * b;

    /// <summary>Divides <paramref name="a"/> by <paramref name="b"/>.</summary>
    /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    /// <summary>Returns the remainder of <paramref name="a"/> divided by <paramref name="b"/>.</summary>
    /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
    public double Modulo(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a % b;
    }

    /// <summary>Returns the absolute value of <paramref name="value"/>.</summary>
    public double Abs(double value) => Math.Abs(value);

    /// <summary>Returns the square root of <paramref name="value"/>.</summary>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is negative.</exception>
    public double Sqrt(double value)
    {
        if (value < 0)
            throw new ArgumentException("Cannot compute square root of a negative number.", nameof(value));
        return Math.Sqrt(value);
    }

    /// <summary>Returns <paramref name="base"/> raised to the power of <paramref name="exponent"/>.</summary>
    public double Power(double @base, double exponent) => Math.Pow(@base, exponent);
}
