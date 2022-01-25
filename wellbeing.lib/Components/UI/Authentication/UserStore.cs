namespace wellbeing.Components.UI.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using wellbeing;
    using wellbeing.Components.API.Users;
    using wellbeing.Mappers;
    using wellbeing.Models.UI.View.Users;

    public class UserStore : IUserStore<UserViewModel>, IUserRoleStore<UserViewModel>, IUserPasswordStore<UserViewModel>, IUserSecurityStampStore<UserViewModel>
    {
        private const string COMPONENT = "UserStore";

        public UserStore(IOptions<AppSettings> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            AppSettings.Current = settings.Value;
        }

        public Task AddToRoleAsync(UserViewModel user, string roleName, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

#pragma warning disable 1998
        public async Task<IdentityResult> CreateAsync(UserViewModel user, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return IdentityResult.Failed(new IdentityError[]
            {
                new IdentityError()
                {
                    Code = "NotSupported",
                    Description = "This method is not currently supported."
                }
            });
        }

#pragma warning disable 1998
        public async Task<IdentityResult> DeleteAsync(UserViewModel user, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return IdentityResult.Failed(new IdentityError[]
            {
                new IdentityError()
                {
                    Code = "NotSupported",
                    Description = "This method is not currently supported."
                }
            });
        }

        public async Task<UserViewModel> FindByIdAsync(string emailAddress, CancellationToken cancellationToken)
        {
            // called by AuthenticationManager.Current.GetCurrentUser
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            User user = null;

            if (!string.IsNullOrEmpty(emailAddress))
            {
                try
                {
                    user = await User.Get(emailAddress);
                }
                catch (Exception ex)
                {
                    throw ex;
                    //// await LoggingDbContext.Current.Write(null, COMPONENT, method, ex);
                }
            }

            return UsersMapper.MapUserToUserViewModel(user);
        }

        public Task<UserViewModel> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

        public Task<string> GetNormalizedUserNameAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

        public Task<string> GetPasswordHashAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

#pragma warning disable 1998
        public async Task<IList<string>> GetRolesAsync(UserViewModel user, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return new List<string>();
        }

        public async Task<string> GetUserIdAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return await this.GetUserNameAsync(user, cancellationToken);
        }

#pragma warning disable 1998
        public async Task<string> GetUserNameAsync(UserViewModel user, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return user.EmailAddress;
        }

        public Task<IList<UserViewModel>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

#pragma warning disable 1998
        public async Task<bool> HasPasswordAsync(UserViewModel user, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return true;
        }

#pragma warning disable 1998
        public async Task<bool> IsInRoleAsync(UserViewModel user, string roleName, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return false;
        }

        public Task RemoveFromRoleAsync(UserViewModel user, string roleName, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

#pragma warning disable 1998
        public async Task SetNormalizedUserNameAsync(UserViewModel user, string normalizedName, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

#pragma warning disable 1998
        public async Task SetPasswordHashAsync(UserViewModel user, string passwordHash, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

#pragma warning disable 1998
        public async Task SetUserNameAsync(UserViewModel user, string userName, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

#pragma warning disable 1998
        public async Task<IdentityResult> UpdateAsync(UserViewModel user, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return IdentityResult.Failed(new IdentityError[]
            {
                new IdentityError()
                {
                    Code = "NotSupported",
                    Description = "This method is not currently supported."
                }
            });
        }

#pragma warning disable 1998
        public async Task SetSecurityStampAsync(UserViewModel user, string stamp, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new NotSupportedException();
        }

        public async Task<string> GetSecurityStampAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return await Task<string>.Factory.StartNew(() => Guid.NewGuid().ToString("D"));
        }

        public void Dispose()
        {
        }
    }
}
