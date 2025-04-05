namespace ParseTreeTask;

/// <summary>
/// Parse tree node.
/// </summary>
public class Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="value">Value of the node.</param>
    public Node(string value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets value of the node.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Gets or sets left child node.
    /// </summary>
    public Node? LeftChild { get; set; }

    /// <summary>
    /// Gets or sets right child node.
    /// </summary>
    public Node? RightChild { get; set; }
}
