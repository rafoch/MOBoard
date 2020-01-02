using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Board.Read.Query;
using MOBoard.Board.Write.Command;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.Board;
using MOBoard.Common.Dispatchers;
using MOBoard.Web.Controllers.Base;

namespace MOBoard.Web.Controllers.V1.Auth
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BoardController : BaseController
    {
        private readonly IDispatcher _dispatcher;

        public BoardController(IDispatcher dispatcher) : base(dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet(ApiRoutes.Board.All)]
        public async Task<IActionResult> All()
        {
            return Ok();
        }

        [HttpGet(ApiRoutes.Board.Get)]
        public async Task<ActionResult<Guid>> Get([FromRoute] Guid id)
        {
            var authorizedQueryAsync = await _dispatcher.AuthorizedQueryAsync(new GetBoardByIdAuthorizedQuery(id));
            return Single(authorizedQueryAsync);
        }

        [HttpPost(ApiRoutes.Board.Create)]
        public async Task<IActionResult> Add([FromRoute] Guid projectId, [FromBody] CreateBoardRequest request)
        {
            await _dispatcher.AuthorizedSendAsync(new CreateNewBoardAuthorizedCommand(projectId, request.Name));
            return Ok();
        }

        [HttpDelete(ApiRoutes.Board.Remove)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPut(ApiRoutes.Board.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}