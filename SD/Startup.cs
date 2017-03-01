using System.Reflection;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SD.Configurations;

namespace SD
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors()
                .AddMvc();
            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryApiResources(ApiResources.GetApiResources())
                .AddInMemoryClients(Clients.GetClients());

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app
                .UseDeveloperExceptionPage()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseMvc()
                .UseCors(builder => builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin())
                .UseIdentityServer();
        }
    }
}