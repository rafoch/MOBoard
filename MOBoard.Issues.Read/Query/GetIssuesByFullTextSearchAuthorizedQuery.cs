using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Handlers;
using MOBoard.Common.Types;
using MOBoard.Issues.Read.DataAccess;

namespace MOBoard.Issues.Read.Query
{
    public class GetIssuesByFullTextSearchAuthorizedQuery : IAuthorizedQuery<bool>
    {
        public string Text { get; set; }
    }

    public class GetIssuesByFullTextSearchAuthorizedQueryHandler : IAuthorizedQueryHandler<GetIssuesByFullTextSearchAuthorizedQuery, bool>
    {
        private readonly IssueReadonlyContext _context;

        public GetIssuesByFullTextSearchAuthorizedQueryHandler(IssueReadonlyContext context)
        {
            _context = context;
        }

        public async Task<bool> HandleAsync(GetIssuesByFullTextSearchAuthorizedQuery query)
        {
            var queryable = await _context.Issues.AsQueryable().Where(
                i => EF.Functions.FreeText(i.Name, query.Text) ||
                     EF.Functions.FreeText(i.Description, query.Text) ||
                     EF.Functions.FreeText(i.IssueFullNumber, query.Text))
                .ToListAsync();
            return true;
        }
    }
}