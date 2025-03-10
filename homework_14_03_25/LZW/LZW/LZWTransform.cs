namespace LZW;

/// <summary>
/// Compression algorithm LZW.
/// </summary>
public class LZWTransform
{
    /// <summary>
    /// Create or overwrite a compressed file.
    /// </summary>
    /// <param name="path">Path to the file being compressed.</param>
    public static void Compress(string path)
    {
        using (FileStream fstreamToRead = new FileStream(path, FileMode.Open))
        {
            var buffer = new byte[fstreamToRead.Length];
            fstreamToRead.ReadExactly(buffer);
            var compressedData = DataCompress(buffer);
            Console.WriteLine($"Without BWT {(float)buffer.Length / (float)compressedData.Length}\n");
            using (FileStream fstreamToWrite = File.Create(@"C:\\Users\\Kiril\\OneDrive\\Рабочий стол\test.txt"))
            {
                fstreamToWrite.Write(compressedData, 0, compressedData.Length);
            }
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
            var uncompressedData = DataUncompress(buffer);
            using (FileStream fstreamToWrite = File.Create(@"C:\\Users\\Kiril\\OneDrive\\Рабочий стол\test2.txt"))
            {
                fstreamToWrite.Write(uncompressedData, 0, uncompressedData.Length);
            }
        }
    }

    private static byte[] DataCompress(byte[] data)
    {
        if (data == null || data.Length == 0)
        {
            return new byte[0];
        }

        Bor bor = new();
        InitializeTheBor(bor);

        var len = data.Length;
        List<int> compressedString = new();
        var indexForByteCode = 256;
        List<byte> chain = new();

        for (var i = 0; i < len; i++)
        {
            if (bor.Size == 4095)
            {
                bor = new();
                InitializeTheBor(bor);
                indexForByteCode = 256;
            }

            chain.Add(data[i]);
            if (bor.Contains(chain) != -1)
            {
                continue;
            }

            bor.Add(chain, indexForByteCode);
            indexForByteCode++;

            chain.RemoveAt(chain.Count - 1);
            compressedString.Add(bor.Contains(chain));

            chain.Clear();
            chain.Add(data[i]);
        }

        if (chain.Count > 0)
        {
            compressedString.Add(bor.Contains(chain));
        }

        List<bool[]> bitSetList = TranslationFromListOfIntsToListOfBitsets(compressedString);

        return TranslationFromAListOfBitSetsToAListOfBytes(bitSetList);
    }

    private static byte[] DataUncompress(byte[] data)
    {
        if (data == null || data.Length == 0)
        {
            return new byte[0];
        }

        List<bool[]> bitSetList = TranslationFromAListOfBytesToAListOfBitSets(data);

        var intArray = TranslationFromListOfBitsetsToListOfInts(bitSetList).ToArray();

        Bor bor = new();
        InitializeTheBor(bor);

        List<byte> uncompressedData = new();
        List<byte> chain = new();
        int old = -1;
        var indexForByteCode = 256;

        for (var i = 0; i < intArray.Length; i++)
        {
            if (bor.Size == 4095)
            {
                bor = new();
                InitializeTheBor(bor);
                indexForByteCode = 256;
            }

            var bytes = bor.FindBytesByCode(intArray[i]);
            if (bytes.Length != 0)
            {
                foreach (var item in bytes)
                {
                    uncompressedData.Add(item);
                }

                if (old != -1)
                {
                    var newChain = new List<byte>(bor.FindBytesByCode(old));
                    newChain.Add(bytes[0]);
                    bor.Add(newChain, indexForByteCode);
                    indexForByteCode++;
                }

                old = intArray[i];
            }
            else
            {
                var oldBytes = bor.FindBytesByCode(old);
                if (oldBytes.Length == 0)
                {
                    throw new InvalidOperationException("Invalid compressed data.");
                }

                var newChain = new List<byte>(oldBytes);
                newChain.Add(oldBytes[0]);

                bor.Add(newChain, indexForByteCode);
                indexForByteCode++;

                foreach (var item in newChain)
                {
                    uncompressedData.Add(item);
                }

                old = intArray[i];
            }
        }

        Console.WriteLine(bor.Size);

        return uncompressedData.ToArray();
    }

    private static List<bool[]> TranslationFromAListOfBytesToAListOfBitSets(byte[] byteArray)
    {
        List<bool[]> bitSetList = new();
        var bitSet = new bool[12];
        var numberBit = 0;
        for (var i = 0; i < byteArray.Length; i++)
        {
            var byt = ConvertByteToBoolArray(byteArray[i]);
            Array.Reverse(byt);
            foreach (var bit in byt)
            {
                bitSet[numberBit] = bit;
                numberBit++;

                if (numberBit == 12)
                {
                    bitSetList.Add((bool[])bitSet.Clone());
                    Array.Clear(bitSet, 0, bitSet.Length);
                    numberBit = 0;
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
        var counter = 12;
        for (var indexValue = 0; indexValue < intList.Count; indexValue++)
        {
            var elementOfList = intList[indexValue];
            var bitArray = new bool[counter];

            for (int i = counter - 1; i >= 0; i--)
            {
                if (bitArray.Length == 0 && (elementOfList & (1 << i)) == 0)
                {
                    continue;
                }

                bitArray[i] = (elementOfList & (1 << i)) != 0;
            }

            Array.Reverse(bitArray);
            bitsList.Add(bitArray);
        }

        return bitsList;
    }

    private static byte[] TranslationFromAListOfBitSetsToAListOfBytes(List<bool[]> bitSetList)
    {
        List<byte> byteList = new();
        var recordStartIndex = 0;
        var byt1 = new bool[8];

        for (var intElementindex = 0; intElementindex < bitSetList.Count; intElementindex++)
        {
            var bitArray = bitSetList[intElementindex];
            var numberBit = recordStartIndex;
            for (var i = 0; i < bitArray.Length; i++)
            {
                byt1[numberBit] = bitArray[i];
                numberBit++;

                if (numberBit == 8)
                {
                    numberBit = 0;
                    recordStartIndex = 0;
                    bool[] clonedByt = (bool[])byt1.Clone();
                    byteList.Add(ConvertASetOfBitsToAByte(clonedByt));
                    Array.Clear(byt1, 0, byt1.Length);
                }

                if (i == bitArray.Length - 1 && numberBit != 0)
                {
                    recordStartIndex = numberBit;
                }
            }
        }

        byteList.Add(ConvertASetOfBitsToAByte(byt1));

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

    private static bool[] ConvertByteToBoolArray(byte b)
    {
        bool[] bitArray = new bool[8];

        for (int i = 0; i < 8; i++)
        {
            bitArray[i] = (b & (1 << i)) != 0;
        }

        return bitArray;
    }

    private static void InitializeTheBor(Bor bor)
    {
        for (var i = 0; i < 256; i++)
        {
            var temp = new List<byte> { (byte)i };
            bor.Add(temp, i);
        }
    }
}
