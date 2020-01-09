using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Extensions;
using MOBoard.Common.Handlers;
using MOBoard.Issues.Read.DataAccess;

namespace MOBoard.Issues.Read.Query
{
    [UsedImplicitly]
    public class GetIssuesQueryHandler : IQueryHandler<GetIssuesQuery, IList<IssueDto>>
    {
        private readonly IssueReadonlyContext _context;

        public GetIssuesQueryHandler(IssueReadonlyContext context)
        {
            _context = context;
        }

        public async Task<IList<IssueDto>> HandleAsync(GetIssuesQuery query)
        {
            return await _context.Issues.Include(x => x.IssueHistories).AsQueryable()
                .Where(i => i.RemovedAt == null && i.ProjectId == query.ProjectId)
            .Select(x => new IssueDto
            {
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                Priority = x.Priority,
                CreatorUserId = x.CreatorId,
                IssueNumber = x.IssueNumber,
                IssueFullNumber = x.IssueFullNumber,
                IssueHistories = x.IssueHistories.AsQueryable()
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
            }).ToListAsync();
        }
    }
}