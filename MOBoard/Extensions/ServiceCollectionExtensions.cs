using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MOBoard.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureWriteContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            var connectionString = configuration.GetConnectionString(typeof(T).Name);
            services.AddDbContext<T>(builder => builder.UseSqlServer(connectionString));
            ((DbContext)services.BuildServiceProvider().GetService(typeof(T))).Database.Migrate();
        }

        public static void ConfigureReadonlyContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            var connectionString = configuration.GetConnectionString(typeof(T).Name);
            services.AddDbContext<T>(builder => builder
                .UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }
    }
}