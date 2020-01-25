using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Extensions;
using MOBoard.Common.Handlers;
using MOBoard.Common.Types;
using MOBoard.Issues.Read.Builders;
using MOBoard.Issues.Read.DataAccess;

namespace MOBoard.Issues.Read.Query
{
    public class GetIssuesByFullTextSearchAuthorizedQuery : IAuthorizedQuery<IList<IssueDto>>
    {
        public string Text { get; set; }
    }

    public class GetIssuesByFullTextSearchAuthorizedQueryHandler : IAuthorizedQueryHandler<GetIssuesByFullTextSearchAuthorizedQuery, IList<IssueDto>>
    {
        private readonly IssueReadonlyContext _context;

        public GetIssuesByFullTextSearchAuthorizedQueryHandler(IssueReadonlyContext context)
        {
            _context = context;
        }

        public async Task<IList<IssueDto>> HandleAsync(GetIssuesByFullTextSearchAuthorizedQuery query)
        {
            var queryable = await _context.Issues
                .Include(i => i.IssueComments)
                .Include(i => i.IssueHistories)
                .Include(i => i.IssueWorklogs)
                .AsQueryable().Where(
                i => EF.Functions.FreeText(i.Name, query.Text) ||
                     EF.Functions.FreeText(i.Description, query.Text) ||
                     EF.Functions.FreeText(i.IssueFullNumber, query.Text))
                .Select(issue =>
                    IssueToIssueDtoBuilder.Build(issue))
                .ToListAsync();
            return queryable;
        }
    }
}