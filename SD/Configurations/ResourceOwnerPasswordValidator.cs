using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace SD.Configurations
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var login = context.UserName;
            var pass = context.Password;

            if (login == "test" && pass == "test")
            {
                context.Result = new GrantValidationResult(
                    "test_id", "password"
                );
            }
            else
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidRequest,
                    "login or password is incorrect"
                );
            }

            return Task.FromResult(0);
        }
    }
}