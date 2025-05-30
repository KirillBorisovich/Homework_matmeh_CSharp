// <copyright file="ListUltisTests.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace BubbleSort.Tests;

public class ListUltisTests
{
    private MyList<int> list = new();

    [SetUp]
    public void SetUp()
    {
        this.list.Add(3);
        this.list.Add(1);
        this.list.Add(4);
        this.list.Add(2);
    }

    [Test]
    public void SortTest()
    {
        ListUtils.Sort(this.list);
        for (var i = 0; i < this.list.Count; i++)
        {
            if (this.list[i] != i + 1)
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }
}
