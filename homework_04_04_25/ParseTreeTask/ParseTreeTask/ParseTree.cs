namespace ParseTreeTask;

/// <summary>
/// Parse tree for evaluating arithmetic expressions.
/// </summary>
public class ParseTree
{
    /// <summary>
    /// Root of the tree.
    /// </summary>
    protected Node root;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParseTree"/> class.
    /// Initialize the tree.
    /// </summary>
    /// <param name="inputString">Input arithmetic expression.</param>
    public ParseTree(string inputString)
    {
        var index = 0;
        this.root = SplitArithmeticExpression(inputString, ref index);

        Node SplitArithmeticExpression(string str, ref int index)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new StringIsEmptyException();
            }

            while (str[index] == '(' || str[index] == ')' || str[index] == ' ')
            {
                index++;
            }

            List<char> number = new();

            const byte lowerValueASKII = 48;
            const byte upperValueASKII = 57;
            while (str[index] >= lowerValueASKII && str[index] <= upperValueASKII)
            {
                number.Add(str[index]);
                index++;
            }

            if (number.Count != 0)
            {
                return new Node(new string(number.ToArray()));
            }
            else if (str[index] == '*' || str[index] == '-' ||
                str[index] == '+' || str[index] == '/')
            {
                number.Add(str[index]);
                Node node = new(new string(number.ToArray()));
                index++;
                node.LeftChild = SplitArithmeticExpression(str, ref index);
                node.RightChild = SplitArithmeticExpression(str, ref index);
                return node;
            }
            else
            {
                throw new InvalidCharacterException();
            }
        }
    }

    /// <summary>
    /// Print tree.
    /// </summary>
    public void PrintTree()
    {
        RecursivelyPrintTree(this.root);

        void RecursivelyPrintTree(Node node)
        {
            Console.WriteLine($"{node.Value} ");
            if (node.LeftChild != null)
            {
                RecursivelyPrintTree(node.LeftChild);
            }

            if (node.RightChild != null)
            {
                RecursivelyPrintTree(node.RightChild);
            }
        }
    }
}
