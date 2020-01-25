using System;
using System.Linq;
using System.Linq.Expressions;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Issues.Read.Domain;

namespace MOBoard.Issues.Read.Builders
{
    public class IssueToIssueDtoBuilder
    {
        public static IssueDto Build(Issue issue)
            => new IssueDto
            {
                Name = issue.Name,
                CreatedAt = issue.CreatedAt,
                ModifiedAt = issue.ModifiedAt,
                Priority = issue.Priority,
                CreatorUserId = issue.CreatorId,
                IssueNumber = issue.IssueNumber,
                IssueFullNumber = issue.IssueFullNumber,
                IssueHistories = issue.IssueHistories
                    .Where(ih => ih.RemovedAt == null)
                    .OrderByDescending(ih => ih.CreatedAt)
                    .Select(ih => new IssueHistoryDto
                    {
                        CreatedAt = ih.CreatedAt,
                        ChangeUserId = ih.UserId,
                        ActionType = ih.ActionType.ToString()
                    }),
                IssueComments = issue.IssueComments
                    .Where(ic => ic.RemovedAt == null)
                    .OrderByDescending(ic => ic.CreatedAt)
                    .Select(ic => new IssueCommentDto
                    {
                        CreatedAt = ic.CreatedAt,
                        CreatorId = ic.CreatorId,
                        Text = ic.Text
                    }),
                LoggedTime = issue.IssueWorklogs.Sum(worklog => worklog.Hours + (worklog.Minutes / 60m))
            }; 
    }
}