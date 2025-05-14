namespace MyLinq.Tests;

public class SequencesTest
{
    private int[] array = new int[] { 1, 2, 3, 4, 5 };

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
        var expected = new[] { 1, 2, 3 };
        var actual = this.array.Take(3);

        Assert.That(expected, Is.EqualTo(actual));
    }


    [Test]
    public void SKipTest()
    {
        var expected = new[] { 3, 4, 5 };
        var actual = this.array.Skip(2);

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TheUseOfTwoOperationsTest()
    {
        var expected = new[] { 2, 3, 4 };
        var actual = this.array.Skip(1).Take(3).ToArray();

        Assert.That(expected, Is.EqualTo(actual));
    }
}
