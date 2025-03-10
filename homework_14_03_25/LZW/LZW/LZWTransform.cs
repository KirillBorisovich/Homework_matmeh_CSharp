namespace LZW;

/// <summary>
/// Compression algorithm LZW.
/// </summary>
public class LZWTransform
{
    private enum Events
    {
        Compress,
        Uncompress,
    }

    /// <summary>
    /// Create or overwrite a compressed file.
    /// </summary>
    /// <param name="path">Path to the file being compressed.</param>
    /// <returns>compression ratio without and with BWT.</returns>
    public static (float WithoutBWT, float WithBWT) Compress(string path)
    {
        using (FileStream fstreamToRead = new FileStream(path, FileMode.Open))
        {
            var buffer = new byte[fstreamToRead.Length];
            fstreamToRead.ReadExactly(buffer);

            var compressedDataWithoutBWT = DataCompress(buffer, -1);

            var bufferWithBWT = BWT.DirectTransformation(buffer);
            var compressedDataWithBWT = DataCompress(bufferWithBWT.ResultString, bufferWithBWT.IndexLastElement);

            var name = GetFileNameFromPath(path, Events.Compress);
            string newPath = path + ".zipped";
            using (FileStream fstreamToWrite = File.Create(newPath))
            {
                fstreamToWrite.Write(compressedDataWithBWT, 0, compressedDataWithBWT.Length);
            }

            return ((float)buffer.Length / (float)compressedDataWithoutBWT.Length,
                (float)buffer.Length / (float)compressedDataWithBWT.Length);
        }
    }

    /// <summary>
    /// Create or overwrite a uncompressed file.
    /// </summary>
    /// <param name="path">Path to the file being uncompressed.</param>
    public static void Uncompress(string path)
    {
        using (FileStream fstreamToRead = new FileStream(path, FileMode.Open))
        {
            var buffer = new byte[fstreamToRead.Length];
            fstreamToRead.ReadExactly(buffer);

            var indexBWT = new byte[4];
            var j = 0;
            for (var i = buffer.Length - 4; i < buffer.Length; i++)
            {
                indexBWT[j] = buffer[i];
                j++;
            }

            var bufferToUncompress = new byte[buffer.Length - 4];
            for (var i = 0; i < buffer.Length - 4; i++)
            {
                bufferToUncompress[i] = buffer[i];
            }

            var newPath = path.TrimEnd(".zipped".ToArray());

            var uncompressedData = DataUncompress(bufferToUncompress, BitConverter.ToInt32(indexBWT));
            using (FileStream fstreamToWrite = File.Create(newPath))
            {
                fstreamToWrite.Write(uncompressedData, 0, uncompressedData.Length);
            }
        }
    }

    private static byte[] DataCompress(byte[] data, int indexBWT)
    {
        if (data == null || data.Length == 0)
        {
            return Array.Empty<byte>();
        }

        var bor = new Bor();
        InitializeTheBor(bor);

        var compressedString = new List<int>();
        var chain = new List<byte>();
        var indexForByteCode = 256;

        foreach (byte currentByte in data)
        {
            if (bor.Size == 4095)
            {
                bor = new Bor();
                InitializeTheBor(bor);
                indexForByteCode = 256;
            }

            chain.Add(currentByte);
            var code = bor.Contains(chain);

            if (code == -1)
            {
                bor.Add(chain, indexForByteCode);
                indexForByteCode++;

                chain.RemoveAt(chain.Count - 1);
                compressedString.Add(bor.Contains(chain));

                chain.Clear();
                chain.Add(currentByte);
            }
        }

        if (chain.Count > 0)
        {
            compressedString.Add(bor.Contains(chain));
        }

        var bitSetList = TranslationFromListOfIntsToListOfBitsets(compressedString);

        return TranslationFromAListOfBitSetsToAListOfBytes(bitSetList, indexBWT);
    }

    private static byte[] DataUncompress(byte[] data, int indexBWT)
    {
        if (data == null || data.Length == 0)
        {
            return Array.Empty<byte>();
        }

        var bitSetList = TranslationFromAListOfBytesToAListOfBitSets(data);

        var intArray = TranslationFromListOfBitsetsToListOfInts(bitSetList);

        var bor = new Bor();
        InitializeTheBor(bor);

        List<byte> uncompressedData = new();
        var oldCode = -1;
        var indexForByteCode = 256;

        foreach (int currentCode in intArray)
        {
            if (bor.Size == 4095)
            {
                bor = new Bor();
                InitializeTheBor(bor);
                indexForByteCode = 256;
            }

            var bytes = bor.FindBytesByCode(currentCode);

            if (bytes.Length == 0)
            {
                if (oldCode == -1)
                {
                    throw new InvalidOperationException("Invalid compressed data.");
                }

                var oldBytes = bor.FindBytesByCode(oldCode);
                if (oldBytes.Length == 0)
                {
                    throw new InvalidOperationException("Invalid compressed data.");
                }

                bytes = new byte[oldBytes.Length + 1];
                Array.Copy(oldBytes, bytes, oldBytes.Length);
                bytes[^1] = oldBytes[0];
            }

            uncompressedData.AddRange(bytes);

            if (oldCode != -1)
            {
                var newChain = new List<byte>(bor.FindBytesByCode(oldCode));
                newChain.Add(bytes[0]);
                bor.Add(newChain, indexForByteCode);
                indexForByteCode++;
            }

            oldCode = currentCode;
        }

        return BWT.InverseTransformation(uncompressedData.ToArray(), indexBWT);
    }

    private static List<bool[]> TranslationFromAListOfBytesToAListOfBitSets(byte[] byteArray)
    {
        List<bool[]> bitSetList = new();
        var bitSet = new bool[12];
        var bitIndex = 0;

        foreach (byte b in byteArray)
        {
            for (int i = 7; i >= 0; i--)
            {
                bitSet[bitIndex++] = (b & (1 << i)) != 0;

                if (bitIndex == 12)
                {
                    bitSetList.Add(bitSet);
                    bitSet = new bool[12];
                    bitIndex = 0;
                }
            }
        }

        return bitSetList;
    }

    private static List<int> TranslationFromListOfBitsetsToListOfInts(List<bool[]> bitsList)
    {
        List<int> intList = new();

        foreach (var bitArray in bitsList)
        {
            intList.Add(ConvertFromBitsetToInt(bitArray));
        }

        return intList;
    }

    private static List<bool[]> TranslationFromListOfIntsToListOfBitsets(List<int> intList)
    {
        List<bool[]> bitsList = new();
        const int bitCount = 12;

        foreach (var value in intList)
        {
            bool[] bitArray = new bool[bitCount];

            for (int i = 0; i < bitCount; i++)
            {
                bitArray[bitCount - 1 - i] = (value & (1 << i)) != 0;
            }

            bitsList.Add(bitArray);
        }

        return bitsList;
    }

    private static byte[] TranslationFromAListOfBitSetsToAListOfBytes(List<bool[]> bitSetList, int indexBWT)
    {
        List<byte> byteList = new();
        bool[] byt1 = new bool[8];
        int bitIndex = 0;

        foreach (var bitArray in bitSetList)
        {
            foreach (var bit in bitArray)
            {
                byt1[bitIndex++] = bit;

                if (bitIndex == 8)
                {
                    byteList.Add(ConvertASetOfBitsToAByte(byt1));
                    byt1 = new bool[8];
                    bitIndex = 0;
                }
            }
        }

        if (bitIndex > 0)
        {
            byteList.Add(ConvertASetOfBitsToAByte(byt1));
        }

        if (indexBWT >= 0)
        {
            var indexBWTBytes = BitConverter.GetBytes(indexBWT);
            foreach (var item in indexBWTBytes)
            {
                byteList.Add(item);
            }
        }

        return byteList.ToArray();
    }

    private static byte ConvertASetOfBitsToAByte(bool[] setBits)
    {
        byte result = 0;
        for (int i = 0; i < 8; i++)
        {
            if (setBits[i])
            {
                result |= (byte)(1 << (7 - i));
            }
        }

        return result;
    }

    private static int ConvertFromBitsetToInt(bool[] bitArray)
    {
        int result = 0;
        for (int i = 0; i < bitArray.Length; i++)
        {
            if (bitArray[i])
            {
                result |= 1 << (bitArray.Length - 1 - i);
            }
        }

        return result;
    }

    private static void InitializeTheBor(Bor bor)
    {
        for (var i = 0; i < 256; i++)
        {
            var temp = new List<byte> { (byte)i };
            bor.Add(temp, i);
        }
    }

    private static string GetFileNameFromPath(string path, Events even)
    {
        var i = path.Length - 1;
        List<char> name = new();
        while (!path[i].Equals('\\'))
        {
            name.Add(path[i]);
            i--;
        }

        if (even == Events.Uncompress)
        {
            name.RemoveRange(0, 7);
        }

        name.Reverse();
        return new string(name.ToArray());
    }
}