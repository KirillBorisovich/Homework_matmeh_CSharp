namespace MyLinq.Tests;

public class SequencesTest
{
    private int[] array = new int[] { 1, 2, 3, 4, 5 };

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetPrimesTest()
    {
        var primeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        var counter = 0;
        foreach (var item in Sequences.GetPrimes())
        {
            if (counter == primeNumbers.Length)
            {
                break;
            }

            if (item != primeNumbers[counter])
            {
                Assert.Fail();
            }

            counter++;
        }

        Assert.Pass();
    }

    [Test]
    public void TakeTest()
    {
        var elementNumber = 3;
        var counter = 0;
        foreach (var item in Sequences.Take(this.array, elementNumber))
        {
            if (item != this.array[counter] || counter > elementNumber)
            {
                Assert.Fail();
            }

            counter++;
        }

        Assert.Pass();
    }

    [Test]
    public void TakeNullReferenceExceptionTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            foreach (var item in Sequences.Take(this.array, 6))
            {
                var i = item;
            }
        });
    }

    [Test]
    public void SKipTest()
    {
        var elementNumber = 2;
        var counter = 0;
        foreach (var item in Sequences.Skip(this.array, elementNumber))
        {
            if (item != this.array[counter + 1] ||
                counter > this.array.Length - elementNumber)
            {
                Assert.Fail();
            }

            counter++;
        }

        Assert.Pass();
    }
}
