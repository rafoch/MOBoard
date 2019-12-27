using System.Threading.Tasks;
using System.Windows.Input;
using MOBoard.Common.Types;

namespace MOBoard.Common.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly IAuthorizedDispatcher _authorizedDispatcher;

        public Dispatcher(
            ICommandDispatcher commandDispatcher, 
            IQueryDispatcher queryDispatcher,
            IAuthorizedDispatcher authorizedDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _authorizedDispatcher = authorizedDispatcher;
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
            => await _commandDispatcher.SendAsync(command);

        public async Task AuthorizedSendAsync<TCommand>(TCommand command) where TCommand : IAuthorizedCommand
            => await _authorizedDispatcher.AuthorizedSendAsync(command);

        public async Task<TResult> AuthorizedSendAsync<TCommand, TResult>(TCommand command)
            where TCommand : IAuthorizedCommand<TResult>
            => await _authorizedDispatcher.AuthorizedSendAsync<TCommand, TResult>(command);

        public async Task<TResult> SendAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
            => await _commandDispatcher.SendAsync<TCommand, TResult>(command);

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _queryDispatcher.QueryAsync<TResult>(query);
    }
}