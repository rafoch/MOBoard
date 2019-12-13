﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBoard.Common.Contractors.V1.Issue
{
    public class IssueDto
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IEnumerable<IssueHistoryDto> IssueHistories { get; set; }
    }

    public class IssueHistoryDto
    {
        public DateTime CreatedAt { get; set; }
        public Guid ChangeUserId { get; set; }
        public string ActionType { get; set; }
    }
}