using System.Security.Claims;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SD.Configurations;
using SD.Models;
using SD.Models.ExampleIdentityWithoutEF.Models;
using SD.SelfIdentity;
using Storage;
using Storage.Configuration;
using Storage.Models;

namespace SD
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var defaultPolicy =
                new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes("Bearer")
                    .RequireAuthenticatedUser()
                    .Build();

            services
                .AddCors()
                .AddAuthorization(opt => opt.DefaultPolicy = defaultPolicy)
                .AddMvc(x => x.Filters.Add(new AuthorizeFilter(defaultPolicy)));

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryApiResources(ApiResources.GetApiResources())
                .AddInMemoryClients(Clients.GetClients());

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();

            var storage = new DescStorage(Configurator.Config["constr"]);

            var userStore = new CrmAgentStore(storage);
            var roleStore = new RoleStore();
            var userPrincipalFactory = new UserPrincipalFactory();

            services.AddSingleton<IUserStore<AgentModel>>(userStore);
            services.AddSingleton<IRoleStore<ApplicationRole>>(roleStore);
            services.AddSingleton<IUserClaimsPrincipalFactory<ApplicationUser>>(userPrincipalFactory);

            services.AddSingleton<IServiceDeskStorage>(storage);

            services.AddIdentity<AgentModel, ApplicationRole>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app
                .UseDeveloperExceptionPage()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseCors(builder => builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin())
                .UseIdentityServer()
                .UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
                {
                    Authority = "http://localhost:22022",
                    RequireHttpsMetadata = false,
                    ValidateScope = false,
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true,
                    NameClaimType = ClaimsIdentity.DefaultNameClaimType
                })
                .UseIdentity()
                .UseMvc();
        }
    }
}