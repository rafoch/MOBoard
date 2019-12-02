using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Types;

namespace MOBoard.Web.Controllers.Base
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class BaseController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public BaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        protected async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _dispatcher.QueryAsync<TResult>(query);

        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        protected ActionResult<PagedResult<T>> Collection<T>(PagedResult<T> pagedResult)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }

            return Ok(pagedResult);
        }

        protected ActionResult<ImmutableList<T>> Collection<T>(ImmutableList<T> list)
        {
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        protected async Task SendAsync<T>(T command) where T : ICommand
        {
            await _dispatcher.SendAsync(command);
        }

        protected async Task<TResult> SendAsyncWithResult<T, TResult>(T command) where T : ICommand<TResult>
        {
            return await _dispatcher.SendAsync<T, TResult>(command);
        }
    }
}