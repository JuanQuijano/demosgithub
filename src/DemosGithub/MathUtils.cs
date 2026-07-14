namespace DemosGithub;

/// <summary>
/// Provides number-theory and numeric utility methods.
/// </summary>
public static class MathUtils
{
    /// <summary>Returns true if <paramref name="n"/> is prime.</summary>
    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    /// <summary>Returns the factorial of a non-negative integer.</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="n"/> is negative.</exception>
    public static long Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "n must be non-negative.");
        if (n == 0) return 1;
        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    /// <summary>Returns the greatest common divisor of two non-negative integers.</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when either argument is negative.</exception>
    public static int Gcd(int a, int b)
    {
        if (a < 0) throw new ArgumentOutOfRangeException(nameof(a), "Value must be non-negative.");
        if (b < 0) throw new ArgumentOutOfRangeException(nameof(b), "Value must be non-negative.");
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    /// <summary>Returns the least common multiple of two non-negative integers.</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when either argument is negative.</exception>
    public static int Lcm(int a, int b)
    {
        if (a < 0) throw new ArgumentOutOfRangeException(nameof(a), "Value must be non-negative.");
        if (b < 0) throw new ArgumentOutOfRangeException(nameof(b), "Value must be non-negative.");
        if (a == 0 || b == 0) return 0;
        return a / Gcd(a, b) * b;
    }

    /// <summary>Returns the Fibonacci number at position <paramref name="n"/> (0-indexed).</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="n"/> is negative.</exception>
    public static long Fibonacci(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "n must be non-negative.");
        if (n == 0) return 0;
        if (n == 1) return 1;
        long a = 0, b = 1;
        for (int i = 2; i <= n; i++)
        {
            long temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }

    /// <summary>Clamps <paramref name="value"/> to the range [<paramref name="min"/>, <paramref name="max"/>].</summary>
    /// <exception cref="ArgumentException">Thrown when <paramref name="min"/> is greater than <paramref name="max"/>.</exception>
    public static double Clamp(double value, double min, double max)
    {
        if (min > max)
            throw new ArgumentException("min must be less than or equal to max.");
        return Math.Max(min, Math.Min(max, value));
    }
}
