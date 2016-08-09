using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestCore.BusinessLogic.Factories.Implementations;
using TestCore.BusinessLogic.Factories.Interfaces;
using TestCore.BusinessLogic.Service.Implementation;
using TestCore.BusinessLogic.Service.Interfaces;
using TestCore.DataAccess.Context;
using TestCore.DataAccess.Repositories.Generic.Implementation;
using TestCore.DataAccess.Repositories.Generic.Interfaces;
using TestCore.WebApi.Factories.Implementations;
using TestCore.WebApi.Factories.Interfaces;
using TestCore.WebApi.Mappings;

namespace TestCore.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private MapperConfiguration MapperConfiguration { get; set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            const string connection = @"Server=localhost;Database=TestCore;Trusted_Connection=True;";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddSingleton(provider => AutoMapperConfig.Configure());
            services.AddSingleton(provider => MapperConfiguration.CreateMapper());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IUserDtoFactory, UserDtoFactory>();
            services.AddScoped(typeof (IRepository<>), typeof (Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}