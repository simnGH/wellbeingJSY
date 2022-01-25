namespace wellbeing.Components.UI.Authentication
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using wellbeing.Models.UI.Page.Authentication;
    using wellbeing.Models.UI.View.Users;

    public class UserRoleStore : IRoleStore<RoleViewModel>
    {
        public Task<RoleViewModel> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

        public Task<RoleViewModel> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(RoleViewModel role, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

        public Task<string> GetRoleIdAsync(RoleViewModel role, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

        public Task<string> GetRoleNameAsync(RoleViewModel role, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

#pragma warning disable 1998
        public async Task<IdentityResult> CreateAsync(RoleViewModel role, CancellationToken cancellationToken)
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
        public async Task<IdentityResult> DeleteAsync(RoleViewModel role, CancellationToken cancellationToken)
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
        public async Task SetNormalizedRoleNameAsync(RoleViewModel role, string normalizedName, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

#pragma warning disable 1998
        public async Task SetRoleNameAsync(RoleViewModel role, string roleName, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            throw new System.NotSupportedException();
        }

#pragma warning disable 1998
        public async Task<IdentityResult> UpdateAsync(RoleViewModel role, CancellationToken cancellationToken)
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

        public void Dispose()
        {
        }
    }
}
