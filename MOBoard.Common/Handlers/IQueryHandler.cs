using System.Threading.Tasks;
using JetBrains.Annotations;
using MOBoard.Common.Types;

namespace MOBoard.Common.Handlers
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        [UsedImplicitly]
        Task<TResult> HandleAsync(TQuery query);
    }
}