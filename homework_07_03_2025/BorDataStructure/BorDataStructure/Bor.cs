namespace BorDataStructure;

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
    /// <param name="str">String to add.</param>
    /// <returns>Returns true if such a row does not exist yet.</returns>
    public bool Add(string str)
    {
        var missingLine = false;
        var len = str.Length;
        var node = this.root;

        for (var i = 0; i < len; i++)
        {
            if (!node.Nodes.ContainsKey(str[i]))
            {
                missingLine = true;
                node.Nodes[str[i]] = new Node();
                node.Nodes[str[i]].EndOfWord = i == len - 1;
            }
            else if (!node.Nodes[str[i]].EndOfWord && i == len - 1)
            {
                missingLine = true;
                node.Nodes[str[i]].EndOfWord = true;
            }
            node = node.Nodes[str[i]];
        }

        if (missingLine)
        {
            this.Size++;
        }

        return missingLine;
    }

    /// <summary>
    /// Presence of a word in a structure.
    /// </summary>
    /// <param name="str">String to check.</param>
    /// <returns>Returns true if such a string exists.</returns>
    public bool Contains(string str)
    {
        (bool contains, Node node) = this.FindEndOfLine(str);
        return contains;
    }

    /// <summary>
    /// Remove word from structure.
    /// </summary>
    /// <param name="str">String to remove.</param>
    /// <returns>Returns true if such a row existed.</returns>
    public bool Remove(string str)
    {
        (bool contains, Node node) = this.FindEndOfLine(str);
        if (contains)
        {
            node.EndOfWord = false;
            return true;
        }
        return false;
    }

    private (bool Contains, Node Node) FindEndOfLine(string str)
    {
        var len = str.Length;
        var node = this.root;
        for (var i = 0; i < len; i++)
        {
            if (!node.Nodes.ContainsKey(str[i]) || (i == len - 1 && !node.Nodes[str[i]].EndOfWord))
            {
                return (false, node);
            }

            node = node.Nodes[str[i]];
        }

        return (true, node);
    }

    private class Node
    {
        public bool EndOfWord { get; set; } = false;

        public Dictionary<char, Node> Nodes { get; set; } = new();
    }
}
