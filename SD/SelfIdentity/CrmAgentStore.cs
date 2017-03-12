using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Storage;
using Storage.Models;

namespace SD.SelfIdentity
{
    public class CrmAgentStore : UserStore<AgentModel>
    {
        private readonly IServiceDeskStorage _storage;

        public CrmAgentStore(IServiceDeskStorage storage)
        {
            _storage = storage;
        }

        public override Task<IdentityResult> CreateAsync(AgentModel user, CancellationToken cancellationToken)
            => Task.Run(() => 
                    _storage.AddOrUpdateAgent(user) != null ? IdentityResult.Success : IdentityResult.Failed(),
                cancellationToken);
            
        

        public override Task<IdentityResult> UpdateAsync(AgentModel user, CancellationToken cancellationToken)
            => Task.Run(() =>
                    _storage.AddOrUpdateAgent(user) != null ? IdentityResult.Success : IdentityResult.Failed(),
                cancellationToken);

        public override Task<IdentityResult> DeleteAsync(AgentModel user, CancellationToken cancellationToken)
            => Task.Run(() =>
                    _storage.DeleteAgent(user) != null ? IdentityResult.Success : IdentityResult.Failed(),
                 cancellationToken);


        public override Task<AgentModel> FindByIdAsync(string userId, CancellationToken cancellationToken)
            => Task.Run(() => _storage.Agents.FirstOrDefault(u => u.Id.ToString() == userId));


        public override Task<AgentModel> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            => Task.Run(() => _storage.Agents.FirstOrDefault(u => u.Login.ToUpper() == normalizedUserName));

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

        public override IQueryable<AgentModel> Users => _storage.Agents.AsQueryable();
    }
}