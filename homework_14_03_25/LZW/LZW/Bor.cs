namespace LZW;

/// <summary>
/// Data structure for storing strings.
/// </summary>
public class Bor
{
    private readonly Node root = new();

    /// <summary>
    ///  Gets number of words in the structure.
    /// </summary>
    public int Size { get; private set; } = 0;

    /// <summary>
    /// Add a word to the structure.
    /// </summary>
    /// <param name="element">String to add.</param>
    /// <returns>Returns true if such a row does not exist yet.</returns>
    public bool Add(byte[] element, int substringCode)
    {
        if (element.Length == 0)
        {
            return false;
        }

        var missingLine = false;
        if (RecursiveAddition(element, substringCode, this.root, 0, ref missingLine))
        {
            this.Size++;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Presence of a word in a structure.
    /// </summary>
    /// <param name="element">String to check.</param>
    /// <returns>Returns true if such a string exists.</returns>
    public int Contains(byte[] element)
    {
        if (element.Length == 0)
        {
            return -1;
        }

        var substringCode = -1;
        var len = element.Length;
        var node = this.root;
        for (var i = 0; i < len; i++)
        {
            if (!node.Nodes.ContainsKey(element[i]) || (i == len - 1 && node.Nodes[element[i]].EndOfWord == -1))
            {
                return -1;
            }
            else if (i == len - 1 && node.Nodes[element[i]].EndOfWord != -1)
            {
                substringCode = node.Nodes[element[i]].EndOfWord;
            }

            node = node.Nodes[element[i]];
        }

        return substringCode;
    }

    /// <summary>
    /// Remove word from structure.
    /// </summary>
    /// <param name="element">String to remove.</param>
    /// <returns>Returns true if such a row existed.</returns>
    public bool Remove(byte[] element)
    {
        if (element.Length == 0)
        {
            return false;
        }

        return RecursiveRemove(element, this.root, 0);
    }

    /// <summary>
    /// Number of lines that start with the given prefix.
    /// </summary>
    /// <param name="prefix">Prefix to check.</param>
    /// <returns>Returns number of line thath start.</returns>
    public int HowManyStartsWithPrefix(byte[] prefix)
    {
        if (prefix.Length == 0)
        {
            return 0;
        }

        var len = prefix.Length;
        var node = this.root;
        for (var i = 0; i < len; i++)
        {
            if (!node.Nodes.ContainsKey(prefix[i]))
            {
                return 0;
            }

            node = node.Nodes[prefix[i]];
        }

        return node.NumberOfWordsAfterPrefix;
    }

    private static bool RecursiveAddition(byte[] element, int substringCode, Node node, int index, ref bool missingLine)
    {
        if (index < element.Length && !node.Nodes.ContainsKey(element[index]))
        {
            missingLine = true;
            node.Nodes[element[index]] = new Node();
        }
        else if (index == element.Length && node.EndOfWord == -1)
        {
            node.EndOfWord = substringCode;
            missingLine = true;
        }

        if (index < element.Length && RecursiveAddition(element, substringCode, node.Nodes[element[index]], index + 1, ref missingLine))
        {
            node.NumberOfWordsAfterPrefix++;
        }

        return missingLine;
    }

    private static bool RecursiveRemove(byte[] element, Node node, int index)
    {
        if (index == element.Length && node.EndOfWord == -1)
        {
            return false;
        }
        else if (index == element.Length && node.EndOfWord != -1)
        {
            node.EndOfWord = -1;
            return true;
        }

        var theResenceOfTheWord = false;
        if (index < element.Length)
        {
            if (!node.Nodes.ContainsKey(element[index]))
            {
                return false;
            }

            theResenceOfTheWord = RecursiveRemove(element, node.Nodes[element[index]], index + 1);
        }

        if (theResenceOfTheWord)
        {
            if (node.Nodes[element[index]].NumberOfWordsAfterPrefix == 0 && node.Nodes[element[index]].EndOfWord == -1)
            {
                node.Nodes.Remove(element[index]);
            }

            node.NumberOfWordsAfterPrefix--;
        }

        return theResenceOfTheWord;
    }

    private class Node
    {
        public int EndOfWord { get; set; } = -1;

        public int NumberOfWordsAfterPrefix { get; set; } = 0;

        public Dictionary<byte, Node> Nodes { get; set; } = [];
    }
}
