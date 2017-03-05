using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SD.Models;

namespace SD.SelfIdentity
{
    public class UserPrincipalFactory : IUserClaimsPrincipalFactory<ApplicationUser>
    {
        public Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var identity = new ClaimsIdentity("Microsoft.AspNet.Identity.Application");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            var principal = new ClaimsPrincipal(identity);

            return Task.FromResult(principal);
        }
    }
}