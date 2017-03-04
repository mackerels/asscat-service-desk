using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Storage.Models;

namespace SD.SelfIdentity
{
    public class CrmAgentStore : UserStore<AgentModel>
    {
        private readonly List<AgentModel> _users;

        public CrmAgentStore()
        {
            _users = new List<AgentModel>();
        }

        public override Task<IdentityResult> CreateAsync(AgentModel user, CancellationToken cancellationToken)
        {
            user.Id = new Random().Next();

            _users.Add(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityResult> UpdateAsync(AgentModel user, CancellationToken cancellationToken)
        {
            var match = _users.FirstOrDefault(u => u.Id == user.Id);
            if (match != null)
            {
                match.Name = user.Name;
                match.Password = user.Password;
                match.Company = user.Company;

                return Task.FromResult(IdentityResult.Success);
            }
            return Task.FromResult(IdentityResult.Failed());
        }

        public override Task<IdentityResult> DeleteAsync(AgentModel user, CancellationToken cancellationToken)
        {
            var match = _users.FirstOrDefault(u => u.Id == user.Id);
            if (match != null)
            {
                _users.Remove(match);

                return Task.FromResult(IdentityResult.Success);
            }
            return Task.FromResult(IdentityResult.Failed());
        }

        public override Task<AgentModel> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(u => u.Id.ToString() == userId);

            return Task.FromResult(user);
        }

        public override Task<AgentModel> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(u => u.Name == normalizedUserName);

            return Task.FromResult(user);
        }

        public override Task<string> GetUserIdAsync(AgentModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public override Task<string> GetUserNameAsync(AgentModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public override Task<string> GetNormalizedUserNameAsync(AgentModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public override Task<string> GetPasswordHashAsync(AgentModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public override Task<bool> HasPasswordAsync(AgentModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        public override Task SetUserNameAsync(AgentModel user, string userName, CancellationToken cancellationToken)
        {
            user.Name = userName;
            return Task.FromResult(true);
        }

        public override Task SetNormalizedUserNameAsync(AgentModel user, string normalizedName,
            CancellationToken cancellationToken)
        {
            user.Name = normalizedName;
            return Task.FromResult(true);
        }

        public override Task SetPasswordHashAsync(AgentModel user, string passwordHash,
            CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.FromResult(true);
        }
    }
}