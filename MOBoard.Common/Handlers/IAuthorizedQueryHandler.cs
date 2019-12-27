using System.Threading.Tasks;
using JetBrains.Annotations;
using MOBoard.Common.Types;

namespace MOBoard.Common.Handlers
{
    public interface IAuthorizedQueryHandler<TQuery, TResult> where TQuery : IAuthorizedQuery<TResult>
    {
        [UsedImplicitly]
        Task<TResult> HandleAsync(TQuery query);
    }
}