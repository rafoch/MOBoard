using System.Threading.Tasks;

namespace MOBoard.Common.Dispatchers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}