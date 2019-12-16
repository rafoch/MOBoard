using System;
using System.Collections.Generic;

namespace MOBoard.Common.Contractors.V1.Project
{
    public class GetProjectResponse
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
        public object Persons { get; set; }
    }
}