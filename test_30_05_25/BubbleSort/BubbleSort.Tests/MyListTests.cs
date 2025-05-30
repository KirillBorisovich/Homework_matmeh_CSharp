// <copyright file="MyListTests.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace BubbleSort.Tests;

public class MyListTests
{
    private MyList<int> list = new();

    [SetUp]
    public void Setup()
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(3);
    }

    [Test]
    public void AddTest()
    {
        if (this.list[0] != 1 ||
            this.list[1] != 2 ||
            this.list[2] != 3)
        {
            Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public void AccessByIndexTest()
    {
        this.list[0] = 5;
        this.list[1] = 6;
        this.list[2] = 7;

        if (this.list[0] != 5 ||
            this.list[1] != 6 ||
            this.list[2] != 7)
        {
            Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public void ArgumentOutOfRangeExceptionTest()
    {
        int item = 0;
        Assert.Throws<ArgumentOutOfRangeException>(()
            => item = this.list[-1]);
        Assert.Throws<ArgumentOutOfRangeException>(()
            => this.list[-1] = 0);
        Assert.Throws<ArgumentOutOfRangeException>(()
            => item = this.list[4]);
        Assert.Throws<ArgumentOutOfRangeException>(()
            => this.list[4] = 0);
    }
}
