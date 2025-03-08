namespace LZW;

/// <summary>
/// Burroughs Wheeler Transformation Classroom.
/// </summary>
public class BWT
{
    /// <summary>
    /// Direct transformation Burroughs Wheeler.
    /// </summary>
    /// <param name="str">The string to be transformed.</param>
    /// <returns>Transformed string.</returns>
    public static (string? ResultString, int IndexLastElement) DirectTransformation(string? str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return (null, 0);
        }

        var len = str.Length;
        var shiftIndices = new int[len];
        var result = new char[len];

        for (var i = 0; i < len; i++)
        {
            shiftIndices[i] = i;
        }

        Array.Sort(shiftIndices, (a, b) =>
        {
            for (var i = 0; i < len; i++)
            {
                var charA = str[(a + i) % len];
                var charB = str[(b + i) % len];

                if (charA != charB)
                {
                    return charA.CompareTo(charB);
                }
            }

            return 0;
        });

        var lastIndex = -1;
        for (var i = 0; i < len; i++)
        {
            result[i] = str[(shiftIndices[i] - 1 + len) % len];
            if (shiftIndices[i] == 0)
            {
                lastIndex = i;
            }
        }

        return (new string(result), lastIndex);
    }

    /// <summary>
    /// Inverse transformation Burroughs Wheeler.
    /// </summary>
    /// <param name="str"> The string to be transformed. </param>
    /// <param name="lastIndex"> Position of the original row in the cyclic shift table. </param>
    /// <returns> Original line. </returns>
    public static string? InverseTransformation(string? str, int lastIndex)
    {
        if (string.IsNullOrEmpty(str) || lastIndex < 0)
        {
            return null;
        }

        var len = str.Length;
        var counter = new Dictionary<char, int>();
        var inverseTransformVector = new int[len];

        for (var i = 0; i < len; i++)
        {
            if (!counter.ContainsKey(str[i]))
            {
                counter[str[i]] = 0;
            }

            counter[str[i]]++;
        }

        var positions = new Dictionary<char, int>();
        int sum = 0;
        foreach (var kvp in counter.OrderBy(kvp => kvp.Key))
        {
            positions[kvp.Key] = sum;
            sum += kvp.Value;
        }

        for (var i = 0; i < len; i++)
        {
            inverseTransformVector[positions[str[i]]] = i;
            positions[str[i]]++;
        }

        var result = new char[len];
        var j = inverseTransformVector[lastIndex];
        for (var i = 0; i < len; i++)
        {
            result[i] = str[j];
            j = inverseTransformVector[j];
        }

        return new string(result);
    }
}
