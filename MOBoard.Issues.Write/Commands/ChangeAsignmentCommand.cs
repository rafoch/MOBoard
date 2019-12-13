using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class ChangeAsignmentCommand : ICommand
    {
        public ChangeAsignmentCommand(Guid userId, Guid id)
        {
            UserId = userId;
            Id = id;
        }

        public Guid UserId { get; private set; }
        public Guid Id { get; private set; }
    }
}