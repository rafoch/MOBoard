using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Write.Project.Command
{
    public class CreateNewProjectCommand : ICommand
    {
        public CreateNewProjectCommand(string name, string @alias, string description, Guid userId)
        {
            Name = name;
            Alias = alias;
            Description = description;
            CreatorId = userId;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Alias { get; set; }

        public Guid CreatorId { get; set; }
    }
}