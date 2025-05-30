// <copyright file="MySparceVectorTests.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace SparseVector.Tests;

public class MySparceVectorTests
{
    private MySparceVector vector1;
    private MySparceVector vector2;

    [SetUp]
    public void Setup()
    {
        this.vector1 = new(10);
        this.vector2 = new(10);
        this.vector1[3] = 5.5;
        this.vector1[7] = 2.0;
        this.vector2[3] = 1.5;
        this.vector2[5] = 3.0;
    }

    [Test]
    public void ConstructorThrowsExceptionWhenDimensionIsZero()
    {
        Assert.Throws<ArgumentException>(() => new MySparceVector(0));
    }

    [Test]
    public void VectorAdditionTest()
    {
        var result = MySparceVector.VectorAddition(
            this.vector1,
            this.vector2);

        Assert.That(result[3], Is.EqualTo(7.0));
        Assert.That(result[5], Is.EqualTo(3.0));
        Assert.That(result[7], Is.EqualTo(2.0));
        Assert.That(result[0], Is.EqualTo(0));
    }

    [Test]
    public void VectorAdditionArgumentExceptionTest()
    {
        MySparceVector item = new(1);
        Assert.Throws<ArgumentException>(
            () => MySparceVector.VectorAddition(
                this.vector1, item));
    }

    [Test]
    public void SubtractVectors()
    {
        var result = MySparceVector.SubtractVectors(
            this.vector1,
            this.vector2);

        Assert.That(result[3], Is.EqualTo(4.0));
        Assert.That(result[5], Is.EqualTo(-3.0));
        Assert.That(result[7], Is.EqualTo(2.0));
        Assert.That(result[0], Is.EqualTo(0));
    }

    [Test]
    public void SubtractVectorsArgumentExceptionTest()
    {
        MySparceVector item = new(1);
        Assert.Throws<ArgumentException>(
            () => MySparceVector.SubtractVectors(
                this.vector1, item));
    }

    [Test]
    public void MultiplyVectorsTest()
    {
        var result = MySparceVector.MultiplyVectors(
            this.vector1,
            this.vector2);

        Assert.That(result, Is.EqualTo(8.25));
    }

    [Test]
    public void MultiplyVectorsArgumentExceptionTest()
    {
        MySparceVector item = new(1);
        Assert.Throws<ArgumentException>(
            () => MySparceVector.MultiplyVectors(
                this.vector1, item));
    }

    [Test]
    public void IsZeroTest()
    {
        var vector = new MySparceVector(10);
        Assert.That(vector.IsZero(), Is.True);
    }

    [Test]
    public void IndexOutOfRangeExceptionForIndexTest()
    {
        double item = 0;
        Assert.Throws<IndexOutOfRangeException>(
            () => item = this.vector1[-1]);
        Assert.Throws<IndexOutOfRangeException>(
            () => item = this.vector1[12]);
        Assert.Throws<IndexOutOfRangeException>(
            () => this.vector1[-1] = 0);
        Assert.Throws<IndexOutOfRangeException>(
            () => this.vector1[12] = 0);
    }
}
