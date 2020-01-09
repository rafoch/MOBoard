using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Handlers;
using MOBoard.Issues.Read.DataAccess;

namespace MOBoard.Issues.Read.Query
{
    [UsedImplicitly]
    public class GetIssueByIdQueryHandler : IQueryHandler<GetIssueByIdQuery, IssueDto>
    {
        private readonly IssueReadonlyContext _issueReadonlyContext;

        public GetIssueByIdQueryHandler(IssueReadonlyContext issueReadonlyContext)
        {
            _issueReadonlyContext = issueReadonlyContext;
        }

        public async Task<IssueDto> HandleAsync(GetIssueByIdQuery query)
        {
            var issue = await _issueReadonlyContext.Issues.AsQueryable()
                .Where(i => i.RemovedAt == null && i.Id == query.Id)
                .Select(x => new IssueDto
                {
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt,
                    Priority = x.Priority,
                    CreatorUserId = x.CreatorId,
                    IssueNumber = x.IssueNumber,
                    IssueFullNumber = x.IssueFullNumber,
                    IssueHistories = x.IssueHistories
                        .Where(ih => ih.RemovedAt == null)
                        .OrderByDescending(ih => ih.CreatedAt)
                        .Select(ih => new IssueHistoryDto
                        {
                            CreatedAt = ih.CreatedAt,
                            ChangeUserId = ih.UserId,
                            ActionType = ih.ActionType.ToString()
                        }),
                    IssueComments = x.IssueComments
                        .Where(ic => ic.RemovedAt == null)
                        .OrderByDescending(ic => ic.CreatedAt)
                        .Select(ic => new IssueCommentDto
                        {
                            CreatedAt = ic.CreatedAt,
                            CreatorId = ic.CreatorId,
                            Text = ic.Text
                        }),
                    LoggedTime = x.IssueWorklogs.Sum(worklog => worklog.Hours + (worklog.Minutes % 60))
                }).FirstOrDefaultAsync();
            return issue;
        }
    }
}