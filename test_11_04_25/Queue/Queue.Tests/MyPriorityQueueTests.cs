namespace Queue.Tests;

public class MyPriorityQueueTests
{
    private MyPriorityQueue queue;

    [SetUp]
    public void Setup()
    {
        this.queue = new();
    }

    [Test]
    public void EnqueueAndDequeueTest()
    {
        var correctResult = new int[] { 5, 7, 10, 8, 5, 1 };
        var result = true;

        this.queue.Enqueue(10, 2);
        this.queue.Enqueue(5, 3);
        this.queue.Enqueue(7, 3);
        this.queue.Enqueue(5, 1);
        this.queue.Enqueue(8, 2);
        this.queue.Enqueue(1, 1);

        for (var i = 0; i < correctResult.Length; i++)
        {
            if (this.queue.Dequeue() != correctResult[i])
            {
                result = false;
                break;
            }
        }

        Assert.That(result, Is.True);
    }

    [Test]
    public void EmptyTest()
    {
        var result = false;

        this.queue.Enqueue(10, 2);

        if (this.queue.Empty)
        {
            Assert.Fail();
        }

        this.queue.Dequeue();

        result = this.queue.Empty;

        Assert.That(result, Is.True);
    }

    [Test]
    public void QueueIsEmptyExceptionTest()
    {
        Assert.Throws<QueueIsEmpty>(()
        => this.queue.Dequeue());
    }
}
