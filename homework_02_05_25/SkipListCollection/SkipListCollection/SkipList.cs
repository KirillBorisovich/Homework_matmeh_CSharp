// <copyright file="SkipList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipListCollection;

using System.Collections;
using System.Net.Http.Headers;

/// <summary>
/// Generic collection skip list.
/// </summary>
/// <typeparam name="T">The type of elements in the collection.</typeparam>
public class SkipList<T>(IComparer<T>? inputComparer = null) : IList<T>
{
    private static readonly int MaxLevel = 4;
    private readonly SkipListState state = new();
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
            enumerator.MoveNext();
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
        return new SkipListEnumerator(this.state, this.head);
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
        this.IncrementVersion();
        var enumerator = this.GetEnumerator();
        enumerator.MoveNext();
        for (var i = 0; i < this.Count; i++)
        {
            if (this.Compare(enumerator.Current, value) == 0)
            {
                return i;
            }

            enumerator.MoveNext();
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

    /// <summary>
    /// Removes the SkipList item at the specified index.
    /// </summary>
    /// <param name="index">Index of the element to be removed.</param>
    /// <exception cref="NotSupportedException">
    /// Collection is read-only exception.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Incorrect arguments exception.</exception>
    public void RemoveAt(int index)
    {
        if (this.IsReadOnly)
        {
            throw new NotSupportedException();
        }

        if (index > this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var value = this[index];
        if (this.Remove(value))
        {
            this.IncrementVersion();
        }
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

        if (this.FindElement(update, node.Value) != null)
        {
            return;
        }

        this.IncrementVersion();

        this.Count++;

        for (var i = nodeLevel - 1; i >= 0; i--)
        {
            if (update[i] == null)
            {
                node.Next[i] = this.head[i];
                this.head[i] = node;
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

        for (var i = node.Next.Length - 1; i >= 0; i--)
        {
            if (this.head[i] == node)
            {
                this.head[i] = node.Next[i];
                continue;
            }

            update[i].Next[i] = node.Next[i];
            node.Next[i] = null;
        }

        this.Count--;
        this.IncrementVersion();
        return true;
    }

    /// <summary>
    /// Clear list.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Collection is read-only exception.</exception>
    public void Clear()
    {
        this.IncrementVersion();
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
            array[i] = next[0]!.Value;
            next = next[0]!.Next;
        }
    }

    private Node? FindElement(Node?[] update, T value)
    {
        Node? result = null;
        var updateCounter = MaxLevel - 1;
        Node? visited = null;
        var next = this.head;
        for (var i = next.Length - 1; i >= 0; i--)
        {
            var nextNode = next[i];
            if (nextNode == null)
            {
                update[updateCounter] = visited;
                updateCounter--;
                continue;
            }

            var compare = this.Compare(value, nextNode.Value);
            while (compare > 0)
            {
                visited = nextNode;
                next = nextNode.Next;
                nextNode = nextNode.Next[i];
                if (nextNode == null)
                {
                    compare = -1;
                    break;
                }

                compare = this.Compare(value, nextNode.Value);
            }

            update[updateCounter] = visited;
            updateCounter--;

            if (compare == 0)
            {
                result = nextNode;
            }
        }

        return result;
    }

    private int Compare(T a, T b)
        => this.comparer.Compare(a, b);

    private void IncrementVersion() => this.state.CurrentVersion++;

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

    private class SkipListEnumerator(SkipListState state, Node?[] inputArray)
        : IEnumerator<T>
    {
        private readonly int initialNumberOfChanges = state.CurrentVersion;
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
            if (this.initialNumberOfChanges != state.CurrentVersion)
            {
                throw new NotSupportedException();
            }

            if (this.disposed)
            {
                return false;
            }

            if (this.currentNode == null)
            {
                this.currentNode = this.head[0];
            }
            else
            {
                this.currentNode = this.currentNode.Next[0];
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

    private class SkipListState
    {
        public int CurrentVersion { get; set; } = int.MinValue;
    }
}
