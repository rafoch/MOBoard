using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Auth.Users.Read.Queries;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Extensions;
using MOBoard.Read.Project.Query;
using MOBoard.Web.Controllers.Base;
using MOBoard.Write.Project.Command;
using MOBoard.Write.Project.Domain;

namespace MOBoard.Web.Controllers.V1.Project
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
        public async Task<ActionResult<GetProjectResponse>> GetProjectData([FromRoute] Guid id)
        {
            return Single(await QueryAsync(new GetProjectByIdQuery(id)));
        }

        [HttpDelete(ApiRoutes.Project.Delete)]
        public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
        {
            await SendAsync(new DeleteProjectByIdCommand(id));
            return Ok();
        }

        [HttpPost(ApiRoutes.Project.AddPerson)]
        public async Task<IActionResult> AddPersonToProject([FromRoute] Guid projectId, [FromBody] AddUserToProjectRequest addUserToProjectRequest)
        {
            var userId = HttpContext.GetUserId();
            var addUserToProjectCommand = new AddUserToProjectCommand(
                addUserToProjectRequest.UserId, 
                (PermissionType)addUserToProjectRequest.PermissionType, 
                projectId,
                userId);
            await SendAsync(addUserToProjectCommand);
            return Ok();
        }

        [HttpDelete(ApiRoutes.Project.RemovePerson)]
        public async Task<IActionResult> RemovePersonFromProject([FromRoute] Guid id, [FromRoute] Guid userId)
        {
            var requestUserId = HttpContext.GetUserId();
            var removeUserFromProjectCommand = new RemoveUserFromProjectCommand(
                userId, 
                id, 
                requestUserId);
            await SendAsync(removeUserFromProjectCommand);
            return Ok();
        }

        [HttpGet(ApiRoutes.Project.GetPersons)]
        public async Task<ActionResult<IReadOnlyCollection<GetAllProjectPersonsResponse>>> GetAllProjectPersons([FromRoute] Guid id)
        {
            // return await SendAsyncWithResult<>()
            var queryAsync = await QueryAsync(new GetProjectUsersByProjectIdQuery(id));
            var projectPersons = await QueryAsync(new GetUsernamesForProjectUsersQuery(queryAsync));
            return Collection(projectPersons);
        }

        [HttpGet(ApiRoutes.Project.MyProjects)]
        public async Task<IActionResult> GetProjectsForLoggedUser()
        {
            var queryAsync = await AuthorizedQueryAsync(new GetProjectsByUserIdQuery());
            return Collection(queryAsync);
        }
    }
}