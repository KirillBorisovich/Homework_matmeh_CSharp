// <copyright file="MyList.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace BubbleSort;

/// <summary>
/// Gynerik list.
/// </summary>
/// <typeparam name="T">Parameter type for value.</typeparam>
public class MyList<T>
{
    private ListNode? head;
    private ListNode? tail;

    /// <summary>
    /// Gets number of elements in the list.
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when index is out of range.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var current = this.head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }

            return current.Value;
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var current = this.head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }

            current.Value = value;
        }
    }

    /// <summary>
    /// Add item to list.
    /// </summary>
    /// <param name="value">Values ​​to add.</param>
    public void Add(T value)
    {
        var newNode = new ListNode(value);

        if (this.tail == null)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            this.tail = newNode;
        }

        this.Count++;
    }

    private class ListNode(T value)
    {
        public T Value { get; set; } = value;

        public ListNode? Next { get; set; }
    }
}
