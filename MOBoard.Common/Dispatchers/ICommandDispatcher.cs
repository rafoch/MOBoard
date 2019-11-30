using System.Threading.Tasks;

namespace MOBoard.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
        Task<TResult> SendAsync<T, TResult>(T command) where T : ICommand<TResult>;
    }
}