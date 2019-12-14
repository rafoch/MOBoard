using System;
using System.ComponentModel.DataAnnotations;
using MOBoard.Common.Types;

namespace MOBoard.Write.Project.Domain
{
    public class Project : AggregateRoot
    {
        public Project(string name, string description, string @alias, Guid creatorId)
        {
            Name = name;
            Description = description;
            Alias = alias;
            CreatorId = creatorId;
        }

        [Required]
        public string Name { get; private set; }
        public string Description { get; private set; }
        [Required]
        public string Alias { get; private set; }
        [Required]
        public Guid CreatorId { get; private set; }
    }
}