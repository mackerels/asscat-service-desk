using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SD.Configurations;
using SD.Models;
using SD.Models.ExampleIdentityWithoutEF.Models;
using SD.SelfIdentity;

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

            var userStore = new UserStore();
            var roleStore = new RoleStore();
            var userPrincipalFactory = new UserPrincipalFactory();

            services.AddSingleton<IUserStore<ApplicationUser>>(userStore);
            services.AddSingleton<IRoleStore<ApplicationRole>>(roleStore);
            services.AddSingleton<IUserClaimsPrincipalFactory<ApplicationUser>>(userPrincipalFactory);

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddDefaultTokenProviders();
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
                .UseIdentityServer()
                .UseJwtBearerAuthentication(new JwtBearerOptions
                {
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = false,
                        ValidateLifetime = true
                    }
                });
        }
    }
}