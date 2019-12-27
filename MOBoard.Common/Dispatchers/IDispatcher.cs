using System.Threading.Tasks;
using MOBoard.Common.Types;

namespace MOBoard.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task AuthorizedSendAsync<TCommand>(TCommand command) where TCommand : IAuthorizedCommand;
        Task<TResult> AuthorizedSendAsync<TCommand, TResult>(TCommand command) where TCommand : IAuthorizedCommand<TResult>;
        Task<TResult> SendAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
        Task<TResult> AuthorizedQueryAsync<TResult>(IAuthorizedQuery<TResult> query);
    }
}