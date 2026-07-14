using DemosGithub;

namespace DemosGithub.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    // Add
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(1.5, 2.5, 4.0)]
    public void Add_ReturnsCorrectSum(double a, double b, double expected)
    {
        var result = _calculator.Add(a, b);
        Assert.Equal(expected, result);
    }

    // Subtract
    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 5, -5)]
    [InlineData(-2, -3, 1)]
    public void Subtract_ReturnsCorrectDifference(double a, double b, double expected)
    {
        var result = _calculator.Subtract(a, b);
        Assert.Equal(expected, result);
    }

    // Multiply
    [Theory]
    [InlineData(3, 4, 12)]
    [InlineData(-2, 5, -10)]
    [InlineData(0, 99, 0)]
    public void Multiply_ReturnsCorrectProduct(double a, double b, double expected)
    {
        var result = _calculator.Multiply(a, b);
        Assert.Equal(expected, result);
    }

    // Divide – normal case
    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(7, 2, 3.5)]
    [InlineData(-9, 3, -3)]
    public void Divide_ReturnsCorrectQuotient(double a, double b, double expected)
    {
        var result = _calculator.Divide(a, b);
        Assert.Equal(expected, result);
    }

    // Divide – by zero
    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }

    // Modulo – normal case
    [Theory]
    [InlineData(10, 3, 1)]
    [InlineData(15, 5, 0)]
    public void Modulo_ReturnsCorrectRemainder(double a, double b, double expected)
    {
        var result = _calculator.Modulo(a, b);
        Assert.Equal(expected, result);
    }

    // Modulo – by zero
    [Fact]
    public void Modulo_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Modulo(5, 0));
    }

    // Abs
    [Theory]
    [InlineData(-5, 5)]
    [InlineData(3, 3)]
    [InlineData(0, 0)]
    public void Abs_ReturnsAbsoluteValue(double value, double expected)
    {
        var result = _calculator.Abs(value);
        Assert.Equal(expected, result);
    }

    // Sqrt – normal case
    [Theory]
    [InlineData(9, 3)]
    [InlineData(0, 0)]
    [InlineData(2, 1.4142135623730951)]
    public void Sqrt_ReturnsCorrectRoot(double value, double expected)
    {
        var result = _calculator.Sqrt(value);
        Assert.Equal(expected, result, 10);
    }

    // Sqrt – negative
    [Fact]
    public void Sqrt_NegativeValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.Sqrt(-1));
    }

    // Power
    [Theory]
    [InlineData(2, 10, 1024)]
    [InlineData(3, 0, 1)]
    [InlineData(5, 1, 5)]
    [InlineData(-2, 3, -8)]
    public void Power_ReturnsCorrectResult(double @base, double exponent, double expected)
    {
        var result = _calculator.Power(@base, exponent);
        Assert.Equal(expected, result);
    }
}
