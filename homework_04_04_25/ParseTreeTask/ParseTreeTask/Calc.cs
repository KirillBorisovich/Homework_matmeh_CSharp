namespace ParseTreeTask;

/// <summary>
/// Resolving expressions in a parse tree.
/// </summary>
/// <param name="inputString">Input arithmetic expression.</param>
public class Calc(string inputString) : ParseTree(inputString)
{
    /// <summary>
    /// Calculate the expression.
    /// </summary>
    /// <returns>Calculate result.</returns>
    /// <exception cref="FormatException">The expression structure is incorrect.</exception>
    /// <exception cref="InvalidCharacterException">Invalid characters in expression.</exception>
    public int CalculateExpression()
    {
        return CalculateExpressionRecursively(this.root);

        int CalculateExpressionRecursively(Node node)
        {
            const byte lowerValueASKII = 48;
            const byte upperValueASKII = 57;
            if (node.Value[0] >= lowerValueASKII && node.Value[0] <= upperValueASKII)
            {
                return int.Parse(node.Value);
            }

            if (node.LeftChild == null || node.RightChild == null)
            {
                throw new FormatException();
            }

            switch (node.Value)
            {
                case "*":
                    return CalculateExpressionRecursively(node.LeftChild) *
                    CalculateExpressionRecursively(node.RightChild);
                case "+":
                    return CalculateExpressionRecursively(node.LeftChild) +
                    CalculateExpressionRecursively(node.RightChild);
                case "-":
                    return CalculateExpressionRecursively(node.LeftChild) -
                    CalculateExpressionRecursively(node.RightChild);
                case "/":
                    return CalculateExpressionRecursively(node.LeftChild) /
                    CalculateExpressionRecursively(node.RightChild);
                default:
                    throw new InvalidCharacterException();
            }
        }
    }
}
