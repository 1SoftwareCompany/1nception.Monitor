using System.Collections.Concurrent;

namespace One.Inception.Monitor;

public sealed class LimitedConcurrentQueue<T> : ConcurrentQueue<T>
{
    public readonly int Limit;

    public LimitedConcurrentQueue(int limit)
    {
        Limit = limit;
    }

    public new void Enqueue(T element)
    {
        base.Enqueue(element);
        while (Count > Limit)
        {
            TryDequeue(out T discard);
        }
    }
}

