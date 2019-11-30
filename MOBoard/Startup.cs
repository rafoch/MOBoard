using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private IServiceProvider ConfigureIocContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            RegisterAllTypesByConvention(builder);

            builder.AddDispatchers();

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        private void RegisterAllTypesByConvention(ContainerBuilder builder)
        {
            var startupAssembly = GetType().Assembly;

            var referencedAssemblyNames = startupAssembly.GetReferencedAssemblies().Where(name =>
                new[]
                {
                    "MOBoard"
                }.Any(projectNamespacePart => name.FullName.StartsWith(projectNamespacePart)));
            var assemblyNames = new List<AssemblyName> { startupAssembly.GetName() };
            assemblyNames.AddRange(referencedAssemblyNames);

            foreach (var referencedAssemblyName in assemblyNames)
            {
                builder.RegisterAssemblyTypes(Assembly.Load(referencedAssemblyName)).AsSelf();
                builder.RegisterAssemblyTypes(Assembly.Load(referencedAssemblyName)).AsImplementedInterfaces();
            }
        }
    }
}
