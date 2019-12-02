using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.OAuth;
using MOBoard.Common.Dispatchers;
using MOBoard.Web.Controllers.Base;

namespace MOBoard.Web.Controllers.V1
{
    public class AuthorizationController : BaseController
    {
        public AuthorizationController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpPost(ApiRoutes.Authorization.Login)]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            return Ok();
        }
    }
}