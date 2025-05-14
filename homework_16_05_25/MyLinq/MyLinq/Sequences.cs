// <copyright file="Sequences.cs" company="BengyaKirill">
// Copyright (c) BengyaKirill under MIT License. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// Class for slave with sequences.
/// </summary>
public static class Sequences
{
    /// <summary>
    /// Get a sequence of prime numbers.
    /// </summary>
    /// <returns>Sequence of prime numbers.</returns>
    public static IEnumerable<int> GetPrimes()
    {
        int number = 2;
        while (true)
        {
            if (IsPrime(number))
            {
                yield return number;
            }

            number++;
        }

        static bool IsPrime(int number)
        {
            int counter = 0;
            for (var divider = 1; divider <= Math.Sqrt(number); divider++)
            {
                if (number % divider == 0)
                {
                    counter++;
                    if (divider != number / divider)
                    {
                        counter++;
                    }
                }

                if (counter >= 3)
                {
                    return false;
                }
            }

            return counter == 2;
        }
    }

    /// <summary>
    /// Take a sequence of the first n elements of a sequence.
    /// </summary>
    /// <typeparam name="T">Parameter type of sequence elements.</typeparam>
    /// <param name="seq">A sequence from which a
    /// subsequence must be returned.</param>
    /// <param name="n">The number of the element
    /// to which you need to return.</param>
    /// <returns>Subsequences of a sequence.</returns>
    /// <exception cref="NullReferenceException">Zero sequence
    /// transmitted.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Invalid parameter passed.</exception>
    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
    {
        if (seq == null)
        {
            throw new NullReferenceException();
        }

        if (n < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        using var enumerator = seq.GetEnumerator();
        for (var i = 0; i < n && enumerator.MoveNext(); i++)
        {
            yield return enumerator.Current;
        }
    }

    /// <summary>
    /// Get sequence without first n elements.
    /// </summary>
    /// <typeparam name="T">Parameter type of sequence elements.</typeparam>
    /// <param name="seq">A sequence from which a
    /// subsequence must be returned.</param>
    /// <param name="n">The number of the element to skip to</param>
    /// <returns>Subsequences of a sequence.</returns>
    /// <exception cref="NullReferenceException">Zero sequence
    /// transmitted.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Invalid parameter passed.</exception>
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
    {
        if (seq == null)
        {
            throw new NullReferenceException();
        }

        if (n < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var counter = 0;
        using var enumerator = seq.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (counter < n)
            {
                counter++;
                continue;
            }

            yield return enumerator.Current;
        }
    }
}
