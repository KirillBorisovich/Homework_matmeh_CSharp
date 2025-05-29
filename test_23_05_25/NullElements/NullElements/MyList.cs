// <copyright file="MyList.cs" company="KirillBengya">
// Copyright (c) BengyaKirill under MIT License. All rights reserved.
// </copyright>

namespace NullElements;

using System.Collections;

/// <summary>
/// Gynerik list.
/// </summary>
/// <typeparam name="T">Parameter type for value.</typeparam>
public class MyList<T> : IEnumerable<T>
{
    private readonly ListState state = new();
    private ListNode? head;
    private ListNode? tail;

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used
    /// to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this.state, this.head);
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
    }

    private class Enumerator(ListState state, ListNode? headList) : IEnumerator<T>
    {
        private readonly int initialNumberOfChanges = state.CurrentVersion;
        private ListNode? head = headList;
        private ListNode? currentNode = headList;
        private bool disposed;

        public T Current
        {
            get
            {
                if (this.disposed)
                {
                    throw new
                        ObjectDisposedException(nameof(Enumerator));
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
                return false;
            }

            if (this.currentNode.Next != null)
            {
                this.currentNode = this.currentNode.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            if (this.disposed)
            {
                throw new
                    ObjectDisposedException(nameof(Enumerator));
            }

            this.currentNode = this.head;
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                this.disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }

    private class ListNode(T value)
    {
        public T Value { get; set; } = value;

        public ListNode? Next { get; set; }
    }

    private class ListState
    {
        public int CurrentVersion { get; set; } = int.MinValue;
    }
}
