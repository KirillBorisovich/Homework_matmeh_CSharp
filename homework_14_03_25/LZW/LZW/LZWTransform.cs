using System.Runtime.CompilerServices;

namespace LZW;

/// <summary>
/// Compression algorithm LZW.
/// </summary>
public class LZWTransform
{
    /// <summary>
    /// Creates a new compressed file with the extension .zipped.
    /// </summary>
    /// <param name="path">Path to the file to be compressed</param>
    public static void Compress(string path)
    {
        using (FileStream fstreamToRead = new FileStream(path, FileMode.OpenOrCreate))
        {
            var buffer = new byte[fstreamToRead.Length];
            fstreamToRead.ReadExactly(buffer);
            var compressedData = DataСompress(buffer);
            Console.WriteLine($"{buffer.Length} , {compressedData.Length}");
            using (FileStream fstreamToWrite = File.Create(@"C:\\Users\\Kiril\\OneDrive\\Рабочий стол\test.txt"))
            {
                fstreamToWrite.Write(compressedData, 0, compressedData.Length);
            }
        }
    }

    private static byte[] DataСompress(byte[] data)
    {
        Bor bor = new();
        var len = data.Length;
        List<byte> сompressedString = new();

        for (var i = 0; i < len; i++)
        {
            var temp = new List<byte> { (byte)i };
            bor.Add(temp, i);
        }

        var indexForResult = 0;
        var indexForByteCode = 256;
        var indexForChain = 0;
        List<byte> chain = new();

        for (var i = 0; i < len; i++)
        {
            chain.Add(data[i]);
            if (bor.Contains(chain) != -1)
            {
                indexForChain++;
            }
            else
            {
                bor.Add(chain, indexForByteCode);
                indexForByteCode++;

                chain.RemoveAt(indexForChain);
                сompressedString.Add((byte)bor.Contains(chain));
                indexForResult++;
                chain.Clear();
                indexForChain = 0;
                chain.Add(data[i]);
            }
        }

        сompressedString.Add((byte)bor.Contains(chain));
        var result = new byte[сompressedString.Count];
        for (int i = 0; i < сompressedString.Count; i++)
        {
            result[i] = сompressedString[i];
        }

        return result;
    }

    private static byte DataUncompress(byte[] data)
    {
        Bor bor = new();
        var len = data.Length;
        List<byte> unсompressedString = new();

        for (var i = 0; i < len; i++)
        {
            var temp = new List<byte> { (byte)i };
            bor.Add(temp, i);
        }

        for (var i = 0; i < len; i++)
        {
            
        }
    }
}
