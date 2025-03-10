using System.IO;

namespace LZW.Tests;

class LZWTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestCompressAndUncompress()
    {
        LZWTransform.Compress(@"..\..\..\testCompress.txt");
        File.Copy(@"..\..\..\testCompress.txt", @"..\..\..\testCompressOriginal.txt", true);
        LZWTransform.Uncompress(@"..\..\..\testCompress.txt.zipped");

        using (FileStream fstreamToRead1 = new FileStream(@"..\..\..\testCompress.txt", FileMode.Open))
        {
            var buffer1 = new byte[fstreamToRead1.Length];
            fstreamToRead1.ReadExactly(buffer1);
            using (FileStream fstreamToRead2 = new FileStream(@"..\..\..\testCompressOriginal.txt", FileMode.Open))
            {
                var buffer2 = new byte[fstreamToRead2.Length];
                fstreamToRead2.ReadExactly(buffer2);
                Assert.That(buffer1, Is.EqualTo(buffer2));
                Assert.That(buffer1, Is.EqualTo(buffer2));

                using (FileStream fstreamToRead3 = new FileStream(@"..\..\..\testCompress.txt.zipped", FileMode.Open))
                {
                    var buffer3 = new byte[fstreamToRead3.Length];
                    fstreamToRead3.ReadExactly(buffer3);
                    Assert.That(buffer3.Length, Is.LessThan(buffer2.Length));

                }
            }
        }

        File.Delete(@"..\..\..\testCompressOriginal.txt");
        File.Delete(@"..\..\..\testCompress.txt.zipped");
    }

}
