using Autofac;

namespace MOBoard.Common.Dispatchers
{
    public static class Extensions
    {
        public static void AddDispatchers(this ContainerBuilder builder)
        {
            builder.RegisterType<Dispatcher>().As<IDispatcher>();
            builder.RegisterType<AuthorizedDispatcher>().As<IAuthorizedDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<AuthorizedQueryDispatcher>().As<IAuthorizedQueryDispatcher>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
        }
    }
}