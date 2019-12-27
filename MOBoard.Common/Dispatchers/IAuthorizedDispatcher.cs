using System.Threading.Tasks;

namespace MOBoard.Common.Dispatchers
{
    public interface IAuthorizedDispatcher
    {
        Task AuthorizedSendAsync<T>(T command) where T : IAuthorizedCommand;
        Task<TResult> AuthorizedSendAsync<T, TResult>(T command) where T : IAuthorizedCommand<TResult>;
    }
}