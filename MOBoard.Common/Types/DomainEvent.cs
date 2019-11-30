using System;
using MediatR;

namespace MOBoard.Common.Types
{
    public class DomainEvent : INotification
    {
        public Guid EntityId { get; set; }
    }
}