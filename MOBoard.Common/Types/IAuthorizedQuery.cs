using System;

namespace MOBoard.Common.Types
{
    public abstract class IAuthorizedQuery
    {
        public Guid UserId { get; set; }
    }

    public abstract class IAuthorizedQuery<T> : IAuthorizedQuery
    {

    }
}