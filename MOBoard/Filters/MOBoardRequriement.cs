using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MOBoard.Web.Filters
{
    public class MOBoardRequriement : IAuthorizationRequirement
    {
        public MOBoardRequriement(string domainName)
        {
            DomainName = domainName;
        }
        public string DomainName { get; set; }
    }

    public class MOBoardRequriementHandler : AuthorizationHandler<MOBoardRequriement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MOBoardRequriement requirement)
        {
            var userEmailAddress = context.User?.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            if (userEmailAddress.EndsWith(requirement.DomainName))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}