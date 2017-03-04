using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SD.SelfIdentity
{
    public abstract class UserStore<T> : IUserPasswordStore<T>,
        IUserLoginStore<T>,
        IUserPhoneNumberStore<T>,
        IQueryableUserStore<T>,
        IUserTwoFactorStore<T> where T : class
    {
        public abstract Task<IdentityResult> CreateAsync(T user, CancellationToken cancellationToken);

        public abstract Task<IdentityResult> UpdateAsync(T user, CancellationToken cancellationToken);

        public abstract Task<IdentityResult> DeleteAsync(T user, CancellationToken cancellationToken);

        public abstract Task<T> FindByIdAsync(string userId, CancellationToken cancellationToken);

        public abstract Task<T> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);

        public abstract Task<string> GetUserIdAsync(T user, CancellationToken cancellationToken);

        public abstract Task<string> GetUserNameAsync(T user, CancellationToken cancellationToken);

        public abstract Task<string> GetNormalizedUserNameAsync(T user, CancellationToken cancellationToken);

        public abstract Task<string> GetPasswordHashAsync(T user, CancellationToken cancellationToken);

        public abstract Task<bool> HasPasswordAsync(T user, CancellationToken cancellationToken);

        public abstract Task SetUserNameAsync(T user, string userName, CancellationToken cancellationToken);

        public abstract Task SetNormalizedUserNameAsync(T user, string normalizedName,
            CancellationToken cancellationToken);

        public abstract Task SetPasswordHashAsync(T user, string passwordHash, CancellationToken cancellationToken);

        public Task<string> GetPhoneNumberAsync(T user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberAsync(T user, string phoneNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(T user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(T user, bool confirmed,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(T user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(T user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(T user, CancellationToken cancellationToken)
        {
            IList<UserLoginInfo> logins = new List<UserLoginInfo>();
            return Task.FromResult(logins);
        }

        public Task<T> FindByLoginAsync(string loginProvider, string providerKey,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(T user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(T user, string loginProvider, string providerKey,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public abstract IQueryable<T> Users { get; }
    }
}