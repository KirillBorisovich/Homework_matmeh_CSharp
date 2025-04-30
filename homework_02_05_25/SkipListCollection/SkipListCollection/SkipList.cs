// <copyright file="SkipList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipListCollection;

/// <summary>
/// Generic collection skip list.
/// </summary>
/// <typeparam name="T">The type of elements in the collection.
/// Must implement <see cref="IComparable{T}"/>.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private static readonly int MaxLevel = 16;
    private Random rand = new();
    private Node?[] head = new Node?[MaxLevel];
    private double probability = 0.5;

    /// <summary>
    /// Gets number of elements in the collection.
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// Add item to collection.
    /// </summary>
    /// <param name="value">Value to add.</param>
    public void Add(T value)
    {
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
    public bool Remove(T value)
    {
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
    public void Clear()
    {
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

    private Node? FindElement(Node[] update, T value)
    {
        Node? visitedNode = null;
        var next = this.head;

        for (var i = 0; i < MaxLevel; i++)
        {
            if (next[i] == null)
            {
                continue;
            }

            var compare = this.Compare(next[i].Value, value);
            while (compare < 0)
            {
                visitedNode = next[i];
                next = next[i].Next;

                if (next[i] == null)
                {
                    compare = 1;
                    break;
                }

                compare = this.Compare(next[i].Value, value);
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

    private int Compare(T a, T b) => a.CompareTo(b);

    private int GetNodeLevel()
    {
        int count = 1;
        while (count < MaxLevel)
        {
            if (this.rand.NextDouble() < this.probability)
            {
                break;
            }

            count++;
        }

        return count;
    }

    private class Node(int level, T value)
    {
        public T Value { get; set; } = value;

        public Node?[] Next { get; set; } = new Node?[level];
    }
}
