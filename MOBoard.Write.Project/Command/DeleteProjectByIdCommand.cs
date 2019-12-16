using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Write.Project.Command
{
    public class DeleteProjectByIdCommand : ICommand
    {
        public DeleteProjectByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}