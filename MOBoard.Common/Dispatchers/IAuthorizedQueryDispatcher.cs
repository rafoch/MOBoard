using System.Threading.Tasks;
using MOBoard.Common.Types;

namespace MOBoard.Common.Dispatchers
{
    public interface IAuthorizedQueryDispatcher
    {
        Task<TResult> QueryAuthorizedAsync<TResult>(IAuthorizedQuery<TResult> query);
    }
}