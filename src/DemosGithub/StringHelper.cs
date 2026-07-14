namespace DemosGithub;

/// <summary>
/// Provides common string helper operations.
/// </summary>
public static class StringHelper
{
    /// <summary>Reverses the characters in a string.</summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string Reverse(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    /// <summary>Returns whether the string is a palindrome (case-insensitive).</summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static bool IsPalindrome(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        var normalized = input.ToLowerInvariant();
        return normalized == Reverse(normalized);
    }

    /// <summary>Counts the occurrences of <paramref name="character"/> in <paramref name="input"/>.</summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static int CountOccurrences(string input, char character)
    {
        ArgumentNullException.ThrowIfNull(input);
        int count = 0;
        foreach (var c in input)
        {
            if (c == character)
                count++;
        }
        return count;
    }

    /// <summary>Truncates a string to the given maximum length, appending "..." if truncated.</summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="maxLength"/> is negative.</exception>
    public static string Truncate(string input, int maxLength)
    {
        ArgumentNullException.ThrowIfNull(input);
        if (maxLength < 0)
            throw new ArgumentOutOfRangeException(nameof(maxLength), "Max length must be non-negative.");
        if (input.Length <= maxLength)
            return input;
        return string.Concat(input.AsSpan(0, maxLength), "...");
    }

    /// <summary>
    /// Converts a string to title case (first letter of each word uppercased).
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string ToTitleCase(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        if (input.Length == 0)
            return input;

        var words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
                words[i] = char.ToUpperInvariant(words[i][0]) + words[i][1..].ToLowerInvariant();
        }
        return string.Join(' ', words);
    }
}
