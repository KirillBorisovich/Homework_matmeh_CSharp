namespace NullElements.Tests;

public class ListTest
{
    [Test]
    public void AddAndGetEnumeratorTest()
    {
        var sample = new int[] { 1, 2, 3 };
        var counter = 0;
        MyList<int> list = new();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        foreach (var item in list)
        {
            if (sample[counter] != item)
            {
                Assert.Fail();
            }

            counter++;
        }

        Assert.Pass();
    }
}
