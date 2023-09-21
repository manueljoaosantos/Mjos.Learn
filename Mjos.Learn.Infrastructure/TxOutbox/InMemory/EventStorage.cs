using System.Collections.Concurrent;

namespace Mjos.Learn.Infrastructure.TxOutbox.InMemory
{
    public interface IEventStorage
    {
        public ConcurrentBag<OutboxEntity> Events { get; }
    }

    public class EventStorage : IEventStorage
    {
        public ConcurrentBag<OutboxEntity> Events { get; } = new();
    }
}
