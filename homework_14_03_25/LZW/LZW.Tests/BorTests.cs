namespace LZW.Tests;

public class BorTests
{
    private Bor _bor;
    private List<byte> var0 = new List<byte> { 1, 2 };
    private List<byte> var1 = new List<byte> { 1, 2, 3 };

    [SetUp]
    public void Setup()
    {
        this._bor = new Bor();
    }

    [Test]
    public void TestAdd()
    {
        Assert.That(this._bor.Add(this.var0, 0), Is.EqualTo(true));
        Assert.That(this._bor.Add(this.var0, 0), Is.EqualTo(false));
        Assert.That(this._bor.Add(this.var1, 0), Is.EqualTo(true));
        Assert.That(this._bor.Add(this.var1, 0), Is.EqualTo(false));
    }

    [Test]
    public void TestContains()
    {
        this._bor.Add(var0, 0);
        Assert.That(this._bor.Contains(this.var0), Is.EqualTo(0));
        Assert.That(this._bor.Contains(this.var1), Is.EqualTo(-1));
    }

    [Test]
    public void TestRemove()
    {
        Assert.That(this._bor.Add(this.var0, 1), Is.EqualTo(true));
        Assert.That(this._bor.Add(this.var1, 1), Is.EqualTo(true));
        Assert.That(this._bor.Remove(this.var0), Is.EqualTo(true));
        Assert.That(this._bor.Remove(this.var0), Is.EqualTo(false));
        Assert.That(this._bor.Contains(this.var0), Is.EqualTo(-1));
        Assert.That(this._bor.Contains(this.var1), Is.EqualTo(1));

        Assert.That(this._bor.Add(this.var0, 0), Is.EqualTo(true));
        Assert.That(this._bor.Remove(this.var1), Is.EqualTo(true));
        Assert.That(this._bor.Remove(this.var1), Is.EqualTo(false));
        Assert.That(this._bor.Contains(this.var0), Is.EqualTo(0));
        Assert.That(this._bor.Contains(this.var1), Is.EqualTo(-1));
    }

    [Test]
    public void TestHowManyStartsWithPrefix()
    {
        var var2 = new List<byte> { 1 };
        this._bor.Add(var0, 0);
        Assert.That(this._bor.HowManyStartsWithPrefix(var2), Is.EqualTo(1));
        Assert.That(this._bor.Add(this.var1, 1), Is.EqualTo(true));
        Assert.That(this._bor.HowManyStartsWithPrefix(var2), Is.EqualTo(2));
        Assert.That(this._bor.Remove(this.var1), Is.EqualTo(true));
        Assert.That(this._bor.HowManyStartsWithPrefix(var2), Is.EqualTo(1));
    }

    [Test]
    public void Test()
    {
        var var0Array = new byte[] { 1, 2 };
        var var1Array = new byte[] { 1, 2, 3 };
        this._bor.Add(var0, 0);
        this._bor.Add(var1, 1);
        Assert.That(this._bor.FindBytesByCode(1), Is.EqualTo(var1Array));
        Assert.That(this._bor.FindBytesByCode(0), Is.EqualTo(var0Array));
    }
}