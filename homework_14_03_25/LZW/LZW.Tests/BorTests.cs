// <copyright file="BorTests.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace LZW.Tests;

public class BorTests
{
    private Bor bor;
    private List<byte> var0 = new List<byte> { 1, 2 };
    private List<byte> var1 = new List<byte> { 1, 2, 3 };

    [SetUp]
    public void Setup()
    {
        this.bor = new Bor();
    }

    [Test]
    public void TestAdd()
    {
        Assert.That(this.bor.Add(this.var0, 0), Is.EqualTo(true));
        Assert.That(this.bor.Add(this.var0, 0), Is.EqualTo(false));
        Assert.That(this.bor.Add(this.var1, 0), Is.EqualTo(true));
        Assert.That(this.bor.Add(this.var1, 0), Is.EqualTo(false));
    }

    [Test]
    public void TestContains()
    {
        this.bor.Add(this.var0, 0);
        Assert.That(this.bor.Contains(this.var0), Is.EqualTo(0));
        Assert.That(this.bor.Contains(this.var1), Is.EqualTo(-1));
    }

    [Test]
    public void TestRemove()
    {
        Assert.That(this.bor.Add(this.var0, 1), Is.EqualTo(true));
        Assert.That(this.bor.Add(this.var1, 1), Is.EqualTo(true));
        Assert.That(this.bor.Remove(this.var0), Is.EqualTo(true));
        Assert.That(this.bor.Remove(this.var0), Is.EqualTo(false));
        Assert.That(this.bor.Contains(this.var0), Is.EqualTo(-1));
        Assert.That(this.bor.Contains(this.var1), Is.EqualTo(1));

        Assert.That(this.bor.Add(this.var0, 0), Is.EqualTo(true));
        Assert.That(this.bor.Remove(this.var1), Is.EqualTo(true));
        Assert.That(this.bor.Remove(this.var1), Is.EqualTo(false));
        Assert.That(this.bor.Contains(this.var0), Is.EqualTo(0));
        Assert.That(this.bor.Contains(this.var1), Is.EqualTo(-1));
    }

    [Test]
    public void TestHowManyStartsWithPrefix()
    {
        var var2 = new List<byte> { 1 };
        this.bor.Add(this.var0, 0);
        Assert.That(this.bor.HowManyStartsWithPrefix(var2), Is.EqualTo(1));
        Assert.That(this.bor.Add(this.var1, 1), Is.EqualTo(true));
        Assert.That(this.bor.HowManyStartsWithPrefix(var2), Is.EqualTo(2));
        Assert.That(this.bor.Remove(this.var1), Is.EqualTo(true));
        Assert.That(this.bor.HowManyStartsWithPrefix(var2), Is.EqualTo(1));
    }

    [Test]
    public void TestFindBytesByCode()
    {
        var var0Array = new byte[] { 1, 2 };
        var var1Array = new byte[] { 1, 2, 3 };
        this.bor.Add(this.var0, 0);
        this.bor.Add(this.var1, 1);
        Assert.That(this.bor.FindBytesByCode(1), Is.EqualTo(var1Array));
        Assert.That(this.bor.FindBytesByCode(0), Is.EqualTo(var0Array));
    }
}