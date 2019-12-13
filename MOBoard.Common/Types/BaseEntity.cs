using System;

namespace MOBoard.Common.Types
{
    public abstract class BaseEntity<T> : IIdentifiable<T>
    {
        public T Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime ModifiedAt { get; protected set; } = DateTime.Now;
        public DateTime? RemovedAt { get; protected set; } = null;

        public void Remove()
        {
            RemovedAt = DateTime.Now;
        }
    }

    public interface IQuery<T> : IQuery
    {
    }
}