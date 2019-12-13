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
            return await _context.Issues.Select(x => new IssueDto {Name = x.Name}).ToListAsync();
        }
    }
}