﻿using System;

namespace MOBoard.Common.Contractors.V1.Project
{
    public class GetProjectForUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
    }
}