﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Extensions;
using MOBoard.Issues.Read.Query;
using MOBoard.Issues.Write.Commands;
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
            var createIssueCommand = new CreateIssueCommand(createIssueRequest.Name, userId, createIssueRequest.Description);
            await SendAsync(createIssueCommand);
            return Ok();
        }

        [HttpGet(ApiRoutes.Issue.All)]
        public async Task<IActionResult> GetAllIssues()
        {
            return Ok(await QueryAsync(new GetIssuesQuery()));
        }

    }
}