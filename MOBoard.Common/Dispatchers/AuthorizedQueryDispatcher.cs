using System.Threading.Tasks;
using Autofac;
using MOBoard.Common.Handlers;
using MOBoard.Common.Types;

namespace MOBoard.Common.Dispatchers
{
    public class AuthorizedQueryDispatcher : IAuthorizedQueryDispatcher {
        
        private readonly IComponentContext _context;

        public AuthorizedQueryDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task<TResult> QueryAuthorizedAsync<TResult>(IAuthorizedQuery<TResult> query)
        {
            var handlerType = typeof(IAuthorizedQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _context.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)query);
        }
    }
}