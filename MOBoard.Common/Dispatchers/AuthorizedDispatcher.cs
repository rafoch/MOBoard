using System.Threading.Tasks;
using Autofac;

namespace MOBoard.Common.Dispatchers
{
    public class AuthorizedDispatcher : IAuthorizedDispatcher
    {
        private readonly IComponentContext _context;

        public AuthorizedDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task AuthorizedSendAsync<T>(T command) where T : IAuthorizedCommand
            => await _context.Resolve<IAuthorizedCommandHandler<T>>().HandleAsync(command);

        public async Task<TResult> AuthorizedSendAsync<T, TResult>(T command) where T : IAuthorizedCommand<TResult>
        {
            var handlerType = typeof(IResultCommandHandler<,>)
                .MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = _context.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)command);
        }
    }
}