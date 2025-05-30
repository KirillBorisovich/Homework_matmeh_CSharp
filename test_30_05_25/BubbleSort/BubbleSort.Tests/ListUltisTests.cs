// <copyright file="ListUltisTests.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace BubbleSort.Tests;

public class ListUltisTests
{
    private MyList<int> inputList = new();

    [SetUp]
    public void SetUp()
    {
        this.inputList.Add(3);
        this.inputList.Add(1);
        this.inputList.Add(4);
        this.inputList.Add(2);
    }

    [Test]
    public void SortTest()
    {
        var list = ListUtils.Sort(this.inputList);
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i] != i + 1)
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }
}
