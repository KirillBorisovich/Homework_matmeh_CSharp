// <copyright file="SkipList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipListCollection;

using System.Collections;

/// <summary>
/// Generic collection skip list.
/// </summary>
/// <typeparam name="T">The type of elements in the collection.</typeparam>
public class SkipList<T>(IComparer<T>? inputComparer = null) : IList<T>
{
    private static readonly int MaxLevel = 32;
    private IComparer<T> comparer = inputComparer ?? Comparer<T>.Default;
    private Random rand = new();
    private Node?[] head = new Node?[MaxLevel];
    private double probability = 0.5;

    /// <summary>
    /// Gets number of elements in the collection.
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// Gets a value indicating whether is read-only.
    /// </summary>
    public bool IsReadOnly { get; } = false;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">Index to take element.</param>
    /// <returns>Elements should be documented.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Incorrect arguments exception.</exception>
    /// <exception cref="NotSupportedException">Exception on the
    /// prohibition of using the insert.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var enumerator = this.GetEnumerator();
            for (var i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }

            return enumerator.Current;
        }

        set => throw new NotSupportedException();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used
    /// to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return new SkipListEnumerator(this.head);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used
    /// to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Determines the index of a specific item in the SkipList.
    /// </summary>
    /// <param name="value">Searching value.</param>
    /// <returns>The index of item if
    /// found in the list; otherwise, -1.</returns>
    public int IndexOf(T value)
    {
        var enumerator = this.GetEnumerator();
        for (var i = 0; i < this.Count; i++)
        {
            enumerator.MoveNext();
            if (this.Compare(enumerator.Current, value) == 0)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Inserts an item to the SkipList at the specified index.
    /// </summary>
    /// <param name="index">Index to insert.</param>
    /// <param name="item">item to insert.</param>
    /// <exception cref="NotSupportedException">Exception on the
    /// prohibition of using the insert.</exception>
    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    public void RemoveAt(int index)
    {
        if (this.IsReadOnly)
        {
            throw new NotSupportedException("Collection is read-only.");
        }

        if (index > this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var value = this[index];
        this.Remove(value);
    }

    /// <summary>
    /// Add item to collection.
    /// </summary>
    /// <param name="value">Value to add.</param>
    /// <exception cref="NotSupportedException">
    /// Collection is read-only exception.</exception>
    public void Add(T value)
    {
        if (this.IsReadOnly)
        {
            throw new NotSupportedException();
        }

        var nodeLevel = this.GetNodeLevel();
        Node node = new(nodeLevel, value);
        var update = new Node[MaxLevel];

        this.Count++;

        if (this.FindElement(update, node.Value) != null)
        {
            return;
        }

        for (var i = MaxLevel - nodeLevel; i < MaxLevel; i++)
        {
            if (update[i] == null)
            {
                continue;
            }

            node.Next[i] = update[i].Next[i];
            update[i].Next[i] = node;
        }
    }

    /// <summary>
    /// Remove value from collection.
    /// </summary>
    /// <param name="value">The value to be removed.</param>
    /// <returns>Returns true if such an element was in the collection,
    /// otherwise false.</returns>
    /// <exception cref="NotSupportedException">
    /// Collection is read-only exception.</exception>
    public bool Remove(T value)
    {
        if (this.IsReadOnly)
        {
            throw new NotSupportedException();
        }

        var update = new Node[MaxLevel];
        var node = this.FindElement(update, value);

        if (node == null)
        {
            return false;
        }

        for (var i = MaxLevel - node.Next.Length; i < MaxLevel; i++)
        {
            if (update[i] != null)
            {
                update[i].Next[i] = node.Next[i];
            }
        }

        for (var i = 0; i < node.Next.Length; i++)
        {
            node.Next[i] = null;
        }

        this.Count--;

        return true;
    }

    /// <summary>
    /// Clear list.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Collection is read-only exception.</exception>
    public void Clear()
    {
        if (this.IsReadOnly)
        {
            throw new NotSupportedException();
        }

        for (var i = 0; i < this.head.Length; i++)
        {
            this.head[i] = null;
        }
    }

    /// <summary>
    /// Presence of an element in a collection.
    /// </summary>
    /// <param name="value">Search value.</param>
    /// <returns>Returns true if such an element was in the collection,
    /// otherwise false.</returns>
    public bool Contains(T value)
    {
        var update = new Node[MaxLevel];
        return this.FindElement(update, value) != null;
    }

    /// <summary>
    /// Copy list elements to specified array.
    /// </summary>
    /// <param name="array">Array to copy.</param>
    /// <param name="index">The index from which to
    /// start inserting into the array.</param>
    /// <exception cref="ArgumentNullException">
    /// Null Reference Exception.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Incorrect arguments exception.</exception>
    /// <exception cref="ArgumentException">
    /// Not enough space to copy exception.</exception>
    public void CopyTo(T[] array, int index)
    {
        if (array == null)
        {
            throw new ArgumentNullException();
        }

        if (index < 0 || array.Length < index)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (array.Length - index < this.Count)
        {
            throw new ArgumentException();
        }

        var next = this.head;
        for (var i = 0; i < this.Count; i++)
        {
            array[i] = next[^1]!.Value;
            next = next[^1]!.Next;
        }
    }

    private Node? FindElement(Node[] update, T value)
    {
        Node? visitedNode = null;
        var next = this.head;

        for (var i = 0; i < MaxLevel; i++)
        {
            var nextNode = next[i];
            if (nextNode == null)
            {
                continue;
            }

            var compare = this.Compare(nextNode.Value, value);
            while (compare < 0)
            {
                visitedNode = next[i];
                next = nextNode.Next;

                if (next[i] == null)
                {
                    compare = 1;
                    break;
                }

                compare = this.Compare(nextNode.Value, value);
            }

            switch (compare)
            {
                case 0:
                    return next[i];
                case 1:
                    if (visitedNode != null)
                    {
                        update[i] = visitedNode;
                    }

                    continue;
            }
        }

        return null;
    }

    private int Compare(T a, T b)
        => this.comparer.Compare(a, b);

    private int GetNodeLevel()
    {
        int count = 1;
        while (count < MaxLevel)
        {
            if (this.rand.NextDouble() > this.probability)
            {
                break;
            }

            count++;
        }

        return count;
    }

    private class SkipListEnumerator(Node?[] inputArray) : IEnumerator<T>
    {
        private Node?[] head = inputArray;
        private Node? currentNode = null;
        private bool disposed;

        public T Current
        {
            get
            {
                if (this.disposed)
                {
                    throw new
                        ObjectDisposedException(nameof(SkipListEnumerator));
                }

                if (this.currentNode == null)
                {
                    throw new InvalidOperationException();
                }

                return this.currentNode.Value;
            }
        }

        object System.Collections.IEnumerator.Current => this.Current!;

        public bool MoveNext()
        {
            if (this.disposed)
            {
                return false;
            }

            if (this.currentNode == null)
            {
                this.currentNode = this.head[^1];
            }
            else
            {
                this.currentNode = this.currentNode.Next[^1];
            }

            return this.currentNode != null;
        }

        public void Reset()
        {
            if (this.disposed)
            {
                throw new
                    ObjectDisposedException(nameof(SkipListEnumerator));
            }

            this.currentNode = null;
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                this.currentNode = null;
                this.disposed = true;
                GC.SuppressFinalize(this);
            }

            GC.SuppressFinalize(this);
        }
    }

    private class Node(int level, T value)
    {
        public T Value { get; set; } = value;

        public Node?[] Next { get; } = new Node?[level];
    }
}
