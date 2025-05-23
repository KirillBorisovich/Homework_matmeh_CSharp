// <copyright file="OperationOnAList.cs" company="KirillBengya">
// Copyright (c) BengyaKirill under MIT License. All rights reserved.
// </copyright>

namespace NullElements;

/// <summary>
/// List Operations.
/// </summary>
public class OperationOnAList
{
    /// <summary>
    /// Count the null elements.
    /// </summary>
    /// <typeparam name="T">Parameter by which to count.</typeparam>
    /// <param name="list">List by which to count.</param>
    /// <param name="o">The object that compares.</param>
    /// <returns>Returns the number of zero elements.</returns>
    public static int CountNullElements<T>(MyList<T> list, INullChecker<T> o)
    {
        var counter = 0;
        foreach (var item in list)
        {
            if (o.IsNull(item))
            {
                counter++;
            }
        }

        return counter;
    }
}
