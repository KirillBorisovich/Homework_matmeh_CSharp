﻿namespace MapFilterFold;

/// <summary>
/// Transformations over list.
/// </summary>
public class Transformations
{
    /// <summary>
    /// Transform each element of a list.
    /// </summary>
    /// <param name="list">Transformable list.</param>
    /// <param name="function">The function by which the list is transformed.</param>
    /// <returns>Transformed list.</returns>
    public static List<int> Map(List<int> list, Func<int, int> function)
    {
        for (var i = 0; i < list.Count; i++)
        {
            list[i] = function(list[i]);
        }

        return list;
    }

    /// <summary>
    /// Filter the list.
    /// </summary>
    /// <param name="list">Transformable list.</param>
    /// <param name="function">The function by which the list is transformed.</param>
    /// <returns>Filtered array.</returns>
    public static List<int> Filter(List<int> list, Func<int, bool> function)
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (!function(list[i]))
            {
                list.Remove(list[i]);
            }
        }

        return list;
    }

    /// <summary>
    /// Get the accumulated value obtained after the entire list traversal.
    /// </summary>
    /// <param name="list">Transformable list.</param>
    /// <param name="initialValue">Initial value.</param>
    /// <param name="function">The function by which the list is transformed.</param>
    /// <returns>Accumulated value.</returns>
    public static int Fold(
        List<int> list,
        int initialValue,
        Func<int, int, int> function)
    {
        int result = initialValue;

        for (var i = 0; i < list.Count; i++)
        {
            result = function(result, list[i]);
        }

        return result;
    }
}
