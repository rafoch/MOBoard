using System;
using MOBoard.Board.Write.Domain;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Board.Write.Command
{
    public class CreateNewBoardAuthorizedCommand : IAuthorizedCommand
    {
        public CreateNewBoardAuthorizedCommand(Guid id, string requestName)
        {
            ProjectId = id;
            Name = requestName;
        }

        public Guid ProjectId { get; private set; }
        public string Name { get; private set; }
    }
}