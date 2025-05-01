using System.Diagnostics.Metrics;

namespace SkipListCollection.Tests;

public class SkipListTests
{
    private SkipList<int> list;

    [SetUp]
    public void Setup()
    {
        this.list = new();
        this.list.Add(1);
        this.list.Add(3);
        this.list.Add(2);
        this.list.Add(2);
    }

    [Test]
    public void AddAndContainsTest()
    {
        if (this.list.Contains(1) && this.list.Contains(1)
            && this.list.Contains(1) && !this.list.Contains(4)
            && this.list.Count == 3)
        {
            Assert.Pass();
        }

        Assert.Fail();
    }

    [Test]
    public void RemoveAndRemoveAtTest()
    {
        this.list.Remove(2);
        this.list.Remove(2);
        if (!this.list.Contains(1) || !this.list.Contains(3)
            || this.list.Count != 2)
        {
            Assert.Fail();
        }

        this.list.Add(2);
        this.list.Remove(1);
        if (!this.list.Contains(2) || !this.list.Contains(3))
        {
            Assert.Fail();
        }

        this.list.Add(1);
        this.list.Remove(3);
        if (!this.list.Contains(2) || !this.list.Contains(1))
        {
            Assert.Fail();
        }

        this.list.Add(3);
        this.list.RemoveAt(0);
        if (!this.list.Contains(2) || !this.list.Contains(3)
            || this.list.Count != 2)
        {
            Assert.Fail();
        }

        this.list.Add(1);
        this.list.RemoveAt(1);
        if (!this.list.Contains(1) || !this.list.Contains(3))
        {
            Assert.Fail();
        }

        this.list.Add(2);
        this.list.RemoveAt(2);
        if (!this.list.Contains(1) || !this.list.Contains(2))
        {
            Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public void RemoveAtExceptionTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(()
            => this.list.RemoveAt(-1));
    }

    [Test]
    public void IndexerAndIndexOfTest()
    {
        if (!(this.list[0] == 1 && this.list[1] == 2 && this.list[2] == 3))
        {
            Assert.Fail();
        }

        if (!(this.list.IndexOf(1) == 0 && this.list.IndexOf(2) == 1
            && this.list.IndexOf(3) == 2))
        {
            Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public void CopyToTest()
    {
        var array = new int[this.list.Count];
        this.list.CopyTo(array, 0);
        if (array[0] == 1 && array[1] == 2 && array[2] == 3)
        {
            Assert.Pass();
        }

        Assert.Fail();
    }

    [Test]
    public void CopyToArgumentOutOfRangeExceptionExeption()
    {
        var array = new int[10];
        Assert.Throws<ArgumentOutOfRangeException>(()
            => this.list.CopyTo(array, -1));
    }

    [Test]
    public void CopyToArgumentExceptionExeption()
    {
        var array = new int[10];
        Assert.Throws<ArgumentException>(()
            => this.list.CopyTo(array, 9));
    }

    [Test]
    public void InsertTest()
    {
        Assert.Throws<NotSupportedException>(()
            => this.list.Insert(1, 10));
    }

    [Test]
    public void ForeachTest()
    {
        var array = new int[] { 1, 2, 3 };
        var counter = 0;
        foreach (var item in this.list)
        {
            if (array[counter] != item)
            {
                Assert.Fail();
            }

            counter++;
        }

        Assert.Pass();
    }

    [Test]
    public void ForeachNotSupportedExceptionTest()
    {
        Assert.Throws<NotSupportedException>(() =>
        {
            foreach (var item in this.list)
            {
                this.list.Remove(1);
            }
        });
    }
}
