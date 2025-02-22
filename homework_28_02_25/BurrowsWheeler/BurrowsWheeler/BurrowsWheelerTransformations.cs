namespace BurrowsWheeler;

public class BurrowsWheelerTransformations
{
    public static (string resultString, int indexLastElement) DirectTransformation(string str)
    {
        var len = str.Length;
        var shiftIndices = new int[len];
        var result = new char[len];

        for (var i = 0; i < len; i++)
        {
            shiftIndices[i] = i;
        }

        Array.Sort(shiftIndices, (a, b) =>
        {
            for (var i = 0; i < len; i++)
            {
                var charA = str[(a + i) % len];
                var charB = str[(b + i) % len];

                if (charA != charB)
                {
                    return charA.CompareTo(charB);
                }
            }
            return 0;
        });

        var lastIndex = -1;
        for (var i = 0; i < len; i++)
        {
            result[i] = str[(shiftIndices[i] - 1 + len) % len];
            if (shiftIndices[i] == 0)
            {
                lastIndex = i;
            }
        }

        return (new string(result), lastIndex);
    }

    public static string InverseTransformation(string str, int lastIndex)
    {
        var len = str.Length;
        var alphabet = 256;
        var counter = new int[alphabet];
        var inverseTransformVector = new int[alphabet];

        for (var i = 0; i < len; i++)
        {
            counter[(int)str[i]]++;
        }

        var sum = 0;
        for (int i = 0; i < alphabet; i++)
        {
            sum += counter[i];
            counter[i] = sum - counter[i];
        }

        for (var i = 0; i < len; i++)
        {
            inverseTransformVector[counter[(int)str[i]]] = i;
            counter[(int)str[i]]++;
        }

        var result = new char[len];
        var j = inverseTransformVector[lastIndex];
        for (var i = 0; i < len; i++)
        {
            result[i] = str[j];
            j = inverseTransformVector[j];
        }

        return new string(result);
    }
}
