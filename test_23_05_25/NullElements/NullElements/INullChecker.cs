// <copyright file="INullChecker.cs" company="KirillBengya">
// Copyright (c) BengyaKirill under MIT License. All rights reserved.
// </copyright>

namespace NullElements;

/// <summary>
/// Class for checking for null.
/// </summary>
/// <typeparam name="T">Parameter to check.</typeparam>
public class INullChecker<T>
{
    /// <summary>
    /// Checks if an element is null according to the given criteria.
    /// </summary>
    /// <param name="item">Element for comparison.</param>
    /// <returns>Returns true if the element is null.</returns>
    public bool IsNull(T item)
    {
        return EqualityComparer<T>.Default.Equals(item, default(T));
    }
}
