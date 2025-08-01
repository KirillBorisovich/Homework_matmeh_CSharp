namespace Queue;

/// <summary>
/// Priority Queue.
/// </summary>
public class MyPriorityQueue
{
    private (int Value, int Priority)[] queue = new (int, int)[5];
    private int numberOfElements = 0;

    /// <summary>
    /// Gets a value indicating whether get true if the queue is empty.
    /// </summary>
    public bool Empty { get; private set; } = true;

    /// <summary>
    /// Add item to priority queue.
    /// </summary>
    /// <param name="value">Element value.</param>
    /// <param name="priority">Element priority.</param>
    public void Enqueue(int value, int priority)
    {
        this.Empty = false;

        if (this.numberOfElements == this.queue.Length)
        {
            Array.Resize(ref this.queue, this.queue.Length * 2);
        }

        this.numberOfElements += 1;

        this.queue[^1] = (value, priority);
        Array.Sort(this.queue, (x, y) => y.Priority.CompareTo(x.Priority));
    }

    /// <summary>
    /// Take an element from the queue.
    /// </summary>
    /// <exception cref="QueueIsEmpty">Empty queue exception.</exception>
    /// <returns>Element with the highest priority.</returns>
    public int Dequeue()
    {
        if (this.numberOfElements == 0)
        {
            throw new QueueIsEmpty();
        }

        if (this.numberOfElements - 1 == 0)
        {
            this.Empty = true;
        }

        this.numberOfElements -= 1;

        var result = this.queue[0];
        this.queue[0] = (0, 0);
        Array.Sort(this.queue, (x, y) => y.Priority.CompareTo(x.Priority));

        return result.Value;
    }
}
