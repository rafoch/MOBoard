using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Extensions;
using MOBoard.Read.Project.Query;
using MOBoard.Web.Controllers.Base;
using MOBoard.Write.Project.Command;

namespace MOBoard.Web.Controllers.V1.Issue
{
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

        [HttpGet(ApiRoutes.Project.Get)]
        public async Task<IActionResult> GetProjectData([FromRoute] Guid id)
        {
            return Ok(await QueryAsync(new GetProjectByIdQuery(id)));
        }

        [HttpDelete(ApiRoutes.Project.Delete)]
        public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
        {
            await SendAsync(new DeleteProjectByIdCommand(id));
            return Ok();
        }

        [HttpPost(ApiRoutes.Project.AddPerson)]
        public async Task<IActionResult> AddPersonToProject([FromRoute] Guid projectId, [FromBody] Guid test)
        {
            //todo add invitations for project 
            return Ok();
        }
    }
}