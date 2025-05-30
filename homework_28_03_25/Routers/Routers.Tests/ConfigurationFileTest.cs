// <copyright file="ConfigurationFileTest.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace Routers.Tests;

public class ConfigurationFileTest
{
    [Test]
    public void ReadAndWriteTest()
    {
        DataStorage testData = new();
        ConfigurationFile.Read("../../../inputTestFile.txt", testData);
        ConfigurationFile.Write(
            "../../../OutputTestFile.txt",
            testData.GenerateConfiguration());
        byte[] expected = File.ReadAllBytes("../../../sampleFileForOutput.txt");
        byte[] actual = File.ReadAllBytes("../../../OutputTestFile.txt");

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void ReadShouldReturnExceptonTest()
    {
        DataStorage testData = new();
        Assert.Throws<FormatException>(
            () => ConfigurationFile.Read(
                "../../../invalidInputFile.txt",
                testData));
    }
}
