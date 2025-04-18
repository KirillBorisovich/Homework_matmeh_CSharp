namespace ParseTreeTask.Tests;

public class CalcExceptionsTests
{
    [Test]
    public void StringIsEmptyExceptionTest()
    {
        Assert.Throws<StringIsEmptyException>(()
            => new Calc(""));
    }

    [Test]
    public void InvalidCharacterExceptionTest()
    {
        Assert.Throws<InvalidCharacterException>(()
            => new Calc("+%12 3"));
    }
}
