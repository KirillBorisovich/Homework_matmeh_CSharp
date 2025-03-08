namespace LZW.Tests;

public class BorTests
{
    private Bor _bor;

    [SetUp]
    public void Setup()
    {
        this._bor = new Bor();
        byte[] var = new byte[] { 1, 2 };
        this._bor.Add(var, 0);
    }

    [Test]
    public void TestAdd()
    {
        byte[] var = new byte[] { 1, 2 };
        byte[] var1 = new byte[] { 1, 2, 3 };
        Assert.That(this._bor.Add(var, 0), Is.EqualTo(false));
        Assert.That(this._bor.Add(var1, 0), Is.EqualTo(true));
        Assert.That(this._bor.Add(var1, 0), Is.EqualTo(false));
    }

    [Test]
    public void TestContains()
    {
        byte[] var = new byte[] { 1, 2 };
        byte[] var1 = new byte[] { 1, 2, 3 };
        Assert.That(this._bor.Contains(var), Is.EqualTo(0));
        Assert.That(this._bor.Contains(var1), Is.EqualTo(-1));
    }

    [Test]
    public void TestRemove()
    {
        var var = new byte[] { 1, 2 };
        var var1 = new byte[] { 1, 2, 3 };
        Assert.That(this._bor.Add(var1, 1), Is.EqualTo(true));
        Assert.That(this._bor.Remove(var), Is.EqualTo(true));
        Assert.That(this._bor.Remove(var), Is.EqualTo(false));
        Assert.That(this._bor.Contains(var), Is.EqualTo(-1));
        Assert.That(this._bor.Contains(var1), Is.EqualTo(1));

        Assert.That(this._bor.Add(var, 0), Is.EqualTo(true));
        Assert.That(this._bor.Remove(var1), Is.EqualTo(true));
        Assert.That(this._bor.Remove(var1), Is.EqualTo(false));
        Assert.That(this._bor.Contains(var), Is.EqualTo(0));
        Assert.That(this._bor.Contains(var1), Is.EqualTo(-1));
    }

    [Test]
    public void TestHowManyStartsWithPrefix()
    {
        var var1 = new byte[] { 1, 2, 3 };
        var var2 = new byte[] { 1 };
        Assert.That(this._bor.HowManyStartsWithPrefix(var2), Is.EqualTo(1));
        Assert.That(this._bor.Add(var1, 1), Is.EqualTo(true));
        Assert.That(this._bor.HowManyStartsWithPrefix(var2), Is.EqualTo(2));
        Assert.That(this._bor.Remove(var1), Is.EqualTo(true));
        Assert.That(this._bor.HowManyStartsWithPrefix(var2), Is.EqualTo(1));
    }
}