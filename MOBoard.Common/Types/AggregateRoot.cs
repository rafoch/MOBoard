using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MediatR;

namespace MOBoard.Common.Types
{
    public abstract class AggregateRoot : BaseEntity<Guid>
    {
        private readonly List<INotification> _domainEvents = new List<INotification>();
        public IImmutableList<INotification> DomainEvents => _domainEvents?.ToImmutableList();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}