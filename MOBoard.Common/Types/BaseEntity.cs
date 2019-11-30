namespace MOBoard.Common.Types
{
    public abstract class BaseEntity<T> : IIdentifiable<T>
    {
        public T Id { get; protected set; }
    }

    public interface IQuery<T> : IQuery
    {
    }
}