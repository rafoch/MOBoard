using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Extensions;
using MOBoard.Issues.Read.Query;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.Handlers;
using MOBoard.Read.Project.Query;
using MOBoard.Web.Controllers.Base;
using MOBoard.Write.Project.Command;

namespace MOBoard.Web.Controllers.V1.Issue
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IssueController : BaseController
    {
        public IssueController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpPost(ApiRoutes.Issue.Create)]
        public async Task<IActionResult> CreateIssue([FromBody] CreateIssueRequest createIssueRequest)
        {
            var userId = HttpContext.GetUserId();

            var projectAlias = await QueryAsync(new GetProjectAliasByIdQuery(createIssueRequest.ProjectId));

            var createIssueCommand = new CreateIssueCommand(
                createIssueRequest.Name,
                userId,
                createIssueRequest.Description,
                createIssueRequest.ProjectId,
                projectAlias);
            await SendAsync(createIssueCommand);
            return Ok();
        }

        [HttpGet(ApiRoutes.Issue.All)]
        public async Task<IActionResult> GetAllIssues([FromQuery] Guid projectId)
        {
            return Ok(await QueryAsync(new GetIssuesQuery(projectId)));
        }

        [HttpGet(ApiRoutes.Issue.Assignment)]
        public async Task<IActionResult> ChangeAssignment()
        {
            await SendAsync(new ChangeAsignmentCommand(Guid.Parse("CBCA68EB-85B2-4725-C7EC-08D77FEEC9E4"),
                HttpContext.GetUserId()));
            return Ok();
        }
    }


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectController : BaseController
    {
        public ProjectController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpPost(ApiRoutes.Project.Create)]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest createProjectRequest)
        {
            var userId = HttpContext.GetUserId();

            await SendAsync(new CreateNewProjectCommand(createProjectRequest.Name, createProjectRequest.Alias, createProjectRequest.Description, userId));

            return Ok();
        }
    }
}