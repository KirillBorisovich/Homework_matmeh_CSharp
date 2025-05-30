// <copyright file="MySparceVector.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace SparseVector;

/// <summary>
/// Sparce Vector.
/// </summary>
public class MySparceVector
{
    private readonly Dictionary<int, double> elements;

    /// <summary>
    /// Initializes a new instance of the <see cref="MySparceVector"/> class.
    /// </summary>
    /// <param name="dimension">Vector dimension.</param>
    /// <exception cref="ArgumentException">
    /// Invalid argument exception.</exception>
    public MySparceVector(int dimension)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException();
        }

        this.Dimension = dimension;
        this.elements = new Dictionary<int, double>();
    }

    /// <summary>
    /// Gets vector dimension.
    /// </summary>
    public int Dimension { get; }

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">
    /// The zero-based index of the element to get or set.</param>
    /// <returns>Element corresponding to index.</returns>
    /// <exception cref="IndexOutOfRangeException">
    /// Thrown when index is out of range.</exception>
    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Dimension)
            {
                throw new IndexOutOfRangeException();
            }

            return this.elements.TryGetValue(index, out var value) ? value : 0;
        }

        set
        {
            if (index < 0 || index >= this.Dimension)
            {
                throw new IndexOutOfRangeException();
            }

            if (value == 0)
            {
                this.elements.Remove(index);
            }
            else
            {
                this.elements[index] = value;
            }
        }
    }

    /// <summary>
    /// Add two vectors.
    /// </summary>
    /// <param name="first">First vector.</param>
    /// <param name="second">Second vector.</param>
    /// <returns>Result vector.</returns>
    /// <exception cref="ArgumentException">
    /// Unequal dimensions of vectors.</exception>
    public static MySparceVector VectorAddition(
        MySparceVector first,
        MySparceVector second)
    {
        if (first.Dimension != second.Dimension)
        {
            throw new ArgumentException();
        }

        MySparceVector result = new(first.Dimension);

        foreach (var item in first.elements)
        {
            result[item.Key] = item.Value;
        }

        foreach (var item in second.elements)
        {
            result[item.Key] = result[item.Key] + item.Value;
        }

        return result;
    }

    /// <summary>
    /// Subtract one vector from another.
    /// </summary>
    /// <param name="first">First vector.</param>
    /// <param name="second">Second vector.</param>
    /// <returns>Result vector.</returns>
    /// <exception cref="ArgumentException">
    /// Unequal dimensions of vectors.</exception>
    public static MySparceVector SubtractVectors(
        MySparceVector first,
        MySparceVector second)
    {
        if (first.Dimension != second.Dimension)
        {
            throw new ArgumentException();
        }

        MySparceVector result = new(first.Dimension);

        foreach (var item in first.elements)
        {
            result[item.Key] = item.Value;
        }

        foreach (var item in second.elements)
        {
            result[item.Key] = result[item.Key] - item.Value;
        }

        return result;
    }

    /// <summary>
    /// Multiply two vectors.
    /// </summary>
    /// <param name="first">First vector.</param>
    /// <param name="second">Second vector.</param>
    /// <returns>The result of multiplication.</returns>
    /// <exception cref="ArgumentException">
    /// Unequal dimensions of vectors.</exception>
    public static double MultiplyVectors(
        MySparceVector first,
        MySparceVector second)
    {
        if (first.Dimension != second.Dimension)
        {
            throw new ArgumentException();
        }

        double result = 0;

        var smaller = first.elements.Count < second.elements.Count ?
            first.elements : second.elements;
        var larger = first.elements.Count < second.elements.Count ?
            second.elements : first.elements;

        foreach (var item in smaller)
        {
            if (larger.TryGetValue(item.Key, out var value))
            {
                result += item.Value * value;
            }
        }

        return result;
    }

    /// <summary>
    /// Check for zero vector.
    /// </summary>
    /// <returns>True if zero, false else.</returns>
    public bool IsZero()
        => this.elements.Count == 0;
}
