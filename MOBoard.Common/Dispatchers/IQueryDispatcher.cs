using System.Threading.Tasks;
using MOBoard.Common.Types;

namespace MOBoard.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}