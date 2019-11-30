using System.Threading.Tasks;

namespace MOBoard.Common.Dispatchers
{
    public interface IResultCommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}