using System.Threading.Tasks;
using MOBoard.Common.Types;

namespace MOBoard.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> SendAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
    }
}