using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MOBoard.Auth.Users.Read.DataAccess;
using MOBoard.Auth.Users.Write.DataAccess;
using MOBoard.Auth.Users.Write.Domain;
using MOBoard.Board.Read.DataAccess;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Types;
using MOBoard.Issues.Write.DataAccess;
using MOBoard.Issues.Read.DataAccess;
using MOBoard.Web.Extensions;
using MOBoard.Web.Filters;
using MOBoard.Board.Write.DataAccess;
using MOBoard.Read.Project.DataAccess;
using MOBoard.Web.ContractorsFilters.V1.Auth;
using MOBoard.Write.Project.DataAccess;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;

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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            var tokenValidationParameters = TokenValidationParametersProvider.Get();

            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = tokenValidationParameters;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustWorkOnMOBoard", policy =>
                {
                    policy.AddRequirements(new MOBoardRequriement("MOBoard"));
                });
            });

            // In production, the Angular files will be served from this directory
            ConfigureDatabases(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MOBoard",
                    Version = "V1"
                });
                
                c.ExampleFilters();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },  new List<string>()}
                });

                var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xml);
                c.IncludeXmlComments(xmlPath);

            });
            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            return ConfigureIocContainer(services);
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
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            app.UseWebSockets();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MOBoard");
            });

//            app.UseSpa(spa =>
//            {
//                // To learn more about options for serving an Angular SPA from ASP.NET Core,
//                // see https://go.microsoft.com/fwlink/?linkid=864501
//
//                spa.Options.SourcePath = "ClientApp";
//
//                if (env.IsDevelopment())
//                {
//                    spa.UseAngularCliServer(npmScript: "start");
//                }
//            });
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

        private void ConfigureDatabases(IServiceCollection services)
        {
            {
                services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddRoles<ApplicationRole>()
                    .AddEntityFrameworkStores<AuthUserWriteContext>();
            }
            {
                services.ConfigureWriteContext<IssueWriteContext>(Configuration);
                services.ConfigureReadonlyContext<IssueReadonlyContext>(Configuration);
            }
            {
                services.ConfigureWriteContext<AuthUserWriteContext>(Configuration);
                services.ConfigureReadonlyContext<AuthUserReadonlyContext>(Configuration);
            }
            {
                services.ConfigureWriteContext<BoardWriteContext>(Configuration);
                services.ConfigureReadonlyContext<BoardReadonlyContext>(Configuration);
            }
            {
                services.ConfigureWriteContext<ProjectWriteContext>(Configuration);
                services.ConfigureReadonlyContext<ProjectReadonlyContext>(Configuration);
            }
        }
    }
}
