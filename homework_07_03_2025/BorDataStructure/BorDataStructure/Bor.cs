using Microsoft.Win32.SafeHandles;

namespace BorDataStructure;

public class Bor
{
    public int Size { get; private set; } = 0;
    private Node root = new();

    private class Node
    {
        public bool EndOfWord { get; set; } = false;
        public Dictionary<char, Node> Nodes { get; set; } = new();
    }

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

    public bool Contains(string str)
    {
        var len = str.Length;
        var node = this.root;
        for (var i = 0; i < len; i++)
        {
            if (!node.Nodes.ContainsKey(str[i]) || (i == len - 1 && !node.Nodes[str[i]].EndOfWord))
            {
                return false;
            }
            node = node.Nodes[str[i]];
        }
        return true;
    }
}
