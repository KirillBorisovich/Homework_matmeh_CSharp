// <copyright file="ParseTree.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

namespace ParseTreeTask;

/// <summary>
/// Parse tree for evaluating arithmetic expressions.
/// </summary>
public class ParseTree
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParseTree"/> class.
    /// Initialize the tree.
    /// </summary>
    /// <param name="inputString">Input arithmetic expression.</param>
    public ParseTree(string inputString)
    {
        var index = 0;
        this.Root = SplitArithmeticExpression(inputString, ref index);

        Node SplitArithmeticExpression(string str, ref int index)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new StringIsEmptyException();
            }

            while (str[index] == '(' || str[index] == ')' || str[index] == ' ')
            {
                if (index == str.Length - 1)
                {
                    break;
                }

                index++;
            }

            List<char> number = new();

            const byte lowerValueASKII = 48;
            const byte upperValueASKII = 57;
            while (str[index] >= lowerValueASKII && str[index] <= upperValueASKII)
            {
                number.Add(str[index]);
                if (index == str.Length - 1)
                {
                    break;
                }

                index++;
            }

            if (number.Count != 0)
            {
                return new Node(new string(number.ToArray()));
            }
            else if (index < str.Length && (str[index] == '*' || str[index] == '-' ||
                str[index] == '+' || str[index] == '/'))
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
    /// Gets root of the tree.
    /// </summary>
    protected Node Root { get; }

    /// <summary>
    /// Print tree.
    /// </summary>
    public void PrintTree()
    {
        RecursivelyPrintTree(this.Root);

        void RecursivelyPrintTree(Node node)
        {
            Console.Write($"{node.Value} ");
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
