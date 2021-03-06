﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MOBoard.Common.Types;

namespace MOBoard.Write.Project.Domain
{
    public class Project : AggregateRoot
    {
        private readonly ISet<ProjectPerson> _projectPersons = new HashSet<ProjectPerson>();
        public static Project NewProject(string name, string description, string @alias, Guid creatorId)
        {
            return new Project(name,description,@alias, creatorId);
        }
        public Project(string name, string description, string alias, Guid creatorId)
        {
            Name = name;
            Description = description;
            Alias = alias;
            CreatorId = creatorId;
            ProjectPersons = _projectPersons;
            ProjectPersons.Add(new ProjectPerson(creatorId, PermissionType.Admin));
            ProjectVersions = new HashSet<ProjectVersion>();
        }

        [Required]
        public string Name { get; private set; }
        public string Description { get; private set; }
        [Required]
        public string Alias { get; private set; }
        [Required]
        public Guid CreatorId { get; private set; }

        public ISet<ProjectPerson> ProjectPersons { get; private set; }
        public ISet<ProjectVersion> ProjectVersions { get; private set; }
    }
}