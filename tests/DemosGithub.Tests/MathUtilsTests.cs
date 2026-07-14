using DemosGithub;

namespace DemosGithub.Tests;

public class MathUtilsTests
{
    // IsPrime
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(17, true)]
    [InlineData(20, false)]
    [InlineData(97, true)]
    [InlineData(-5, false)]
    public void IsPrime_ReturnsCorrectResult(int n, bool expected)
    {
        var result = MathUtils.IsPrime(n);
        Assert.Equal(expected, result);
    }

    // Factorial
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(5, 120)]
    [InlineData(10, 3628800)]
    public void Factorial_ReturnsCorrectResult(int n, long expected)
    {
        var result = MathUtils.Factorial(n);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Factorial_NegativeN_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathUtils.Factorial(-1));
    }

    // Gcd
    [Theory]
    [InlineData(12, 8, 4)]
    [InlineData(0, 5, 5)]
    [InlineData(7, 0, 7)]
    [InlineData(0, 0, 0)]
    [InlineData(100, 75, 25)]
    public void Gcd_ReturnsCorrectResult(int a, int b, int expected)
    {
        var result = MathUtils.Gcd(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-1, 5)]
    [InlineData(5, -1)]
    public void Gcd_NegativeArguments_ThrowsArgumentOutOfRangeException(int a, int b)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathUtils.Gcd(a, b));
    }

    // Lcm
    [Theory]
    [InlineData(4, 6, 12)]
    [InlineData(0, 5, 0)]
    [InlineData(7, 0, 0)]
    [InlineData(12, 8, 24)]
    public void Lcm_ReturnsCorrectResult(int a, int b, int expected)
    {
        var result = MathUtils.Lcm(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-1, 5)]
    [InlineData(5, -1)]
    public void Lcm_NegativeArguments_ThrowsArgumentOutOfRangeException(int a, int b)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathUtils.Lcm(a, b));
    }

    // Fibonacci
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(5, 5)]
    [InlineData(10, 55)]
    [InlineData(15, 610)]
    public void Fibonacci_ReturnsCorrectNumber(int n, long expected)
    {
        var result = MathUtils.Fibonacci(n);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Fibonacci_NegativeN_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathUtils.Fibonacci(-1));
    }

    // Clamp
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-5, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    [InlineData(0, 0, 0, 0)]
    public void Clamp_ReturnsClampedValue(double value, double min, double max, double expected)
    {
        var result = MathUtils.Clamp(value, min, max);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Clamp_MinGreaterThanMax_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => MathUtils.Clamp(5, 10, 0));
    }
}
