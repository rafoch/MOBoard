﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Extensions;
using MOBoard.Issues.Read.Query;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.Handlers;
using MOBoard.Read.Project.Query;
using MOBoard.Web.Controllers.Base;

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

        [HttpGet(ApiRoutes.Issue.Get)]
        public async Task<IActionResult> GetIssue([FromQuery] Guid id)
        {
            return Ok(await QueryAsync(new GetIssueByIdQuery(id)));
        }

        [HttpDelete(ApiRoutes.Issue.Remove)]
        public async Task<IActionResult> DeleteIssue([FromQuery] Guid id)
        {
            await SendAsync(new RemoveIssueCommand(id));
            return Ok();
        }

        [HttpPut(ApiRoutes.Issue.Edit)]
        public async Task<IActionResult> EditIssue([FromRoute] Guid id, [FromBody] EditIssueRequest editIssueRequest)
        {
            await SendAsync(new EditIssueCommand(editIssueRequest.Name, editIssueRequest.Description, id));
            return Ok();
        }

        [HttpGet(ApiRoutes.Issue.Assignment)]
        public async Task<IActionResult> ChangeAssignment([FromBody] ChangeAssignementRequest changeAssignementRequest)
        {
            await SendAsync(new ChangeAsignmentCommand(changeAssignementRequest.ChangeUserId,
                HttpContext.GetUserId()));
            return Ok();
        }
    }
}