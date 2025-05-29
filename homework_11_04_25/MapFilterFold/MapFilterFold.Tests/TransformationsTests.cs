namespace MapFilterFold.Tests;

public class Tests
{
    private List<int> list = new() { 1, 2, 3 };

    [Test]
    public void MapTest()
    {
        foreach (var item in Transformations.Map(this.list, x => x * 2))
        {
            if (item % 2 != 0)
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }

    [Test]
    public void FilterTest()
    {
        var resultList = Transformations.Filter(this.list, x => x % 2 == 0);
        Assert.That(resultList, Has.Exactly(1).Items);
        Assert.That(resultList[0], Is.EqualTo(2));
    }

    [Test]
    public void FoldTest()
    {
        Assert.That(Transformations.Fold(this.list, 1, (acc, elem) => acc * elem),
            Is.EqualTo(6));
    }
}