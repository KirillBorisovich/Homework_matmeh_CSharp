namespace LZW.Tests;

class BWTTests
{
    [Test]
    public void TestAllBWT()
    {
        Assert.That(BWT.DirectTransformation("BANANA"), Is.EqualTo(("NNBAAA" , 3)));
        Assert.That(BWT.InverseTransformation("NNBAAA", 3), Is.EqualTo("BANANA"));
    }
}
