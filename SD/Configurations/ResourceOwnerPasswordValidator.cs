using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Storage.Models;

namespace SD.Configurations
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<AgentModel> _manager;
        private readonly IdentityOptions _options;

        public ResourceOwnerPasswordValidator(
            UserManager<AgentModel> manager,
            IOptions<IdentityOptions> optionsAccessor
        ) {
            _options = optionsAccessor.Value;
            _manager = manager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _manager.FindByNameAsync(context.UserName);

            Console.WriteLine(context.UserName);

            if (user != null && user.Password == context.Password)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), "password", new []
                {
                    new Claim(_options.ClaimsIdentity.UserNameClaimType, user.Login),
                    new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString())
                });
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest,
                    "Invalid username or password");
            }
        }
    }
}