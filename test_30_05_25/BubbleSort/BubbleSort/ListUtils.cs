// <copyright file="ListUtils.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace BubbleSort;

/// <summary>
/// List of utilities.
/// </summary>
public static class ListUtils
{
    /// <summary>
    /// Sorts the items in a list
    /// using the bubble sort algorithm.
    /// </summary>
    /// <typeparam name="T">List item type.</typeparam>
    /// <param name="list">Sorting list.</param>
    /// <param name="comparer">
    /// Comparator for comparing elements.</param>
    public static void Sort<T>(this MyList<T> list, IComparer<T>? comparer = null)
    {
        if (list == null)
        {
            throw new ArgumentNullException();
        }

        comparer ??= Comparer<T>.Default;

        bool swapped;
        for (int i = 0; i < list.Count - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }
    }
}
