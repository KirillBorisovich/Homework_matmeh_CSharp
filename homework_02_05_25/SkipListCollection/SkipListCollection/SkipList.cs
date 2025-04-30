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
    private Node[] head = new Node[MaxLevel];
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
        var next = this.head;
        Node? visitedNode = null;

        this.Count++;

        for (var i = 0; i < MaxLevel; i++)
        {
            if (next[i] == null)
            {
                continue;
            }

            var compare = this.Compare(next[i].Value, node.Value);
            while (compare < 0)
            {
                visitedNode = next[i];
                next = next[i].Next;

                if (next[i] == null)
                {
                    compare = 1;
                    break;
                }

                compare = this.Compare(next[i].Value, node.Value);
            }

            switch (compare)
            {
                case 0:
                    return;
                case 1:
                    if (visitedNode != null)
                    {
                        update[i] = visitedNode;
                    }

                    continue;
            }
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

        public Node[] Next { get; set; } = new Node[level];
    }
}
