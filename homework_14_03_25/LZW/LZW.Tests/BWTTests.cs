// <copyright file="BWTTests.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace LZW.Tests;

public class BWTTests
{
    [Test]
    public void TestAllBWT()
    {
        var data = new byte[] { 66, 65, 78, 65, 78, 65 };
        var transformData = new byte[] { 78, 78, 66, 65, 65, 65 };

        Assert.That(BWT.DirectTransformation(data), Is.EqualTo((transformData, 3)));
        Assert.That(BWT.InverseTransformation(transformData, 3), Is.EqualTo(data));
    }
}
