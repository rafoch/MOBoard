using System.Threading.Tasks;
using Autofac;

namespace MOBoard.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command);

        public async Task<TResult> SendAsync<T, TResult>(T command) where T : ICommand<TResult>
        {
            var handlerType = typeof(IResultCommandHandler<,>)
                .MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = _context.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)command);
        }
    }
}