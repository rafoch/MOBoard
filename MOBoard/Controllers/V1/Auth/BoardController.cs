using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Dispatchers;
using MOBoard.Web.Controllers.Base;

namespace MOBoard.Web.Controllers.V1.Auth
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BoardController : BaseController
    {
        public BoardController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet(ApiRoutes.Board.All)]
        public async Task<IActionResult> All()
        {
            return Ok();
        }

        [HttpGet(ApiRoutes.Board.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost(ApiRoutes.Board.Create)]
        public async Task<IActionResult> Add([FromRoute] Guid id)
        {
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