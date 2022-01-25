namespace wellbeing.Components.UI.Authentication
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using wellbeing.Models.UI.Page.Authentication;
    using wellbeing.Models.UI.View.Users;

    public class WellbeingClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserViewModel, RoleViewModel>
    {
        public WellbeingClaimsPrincipalFactory(UserManager<UserViewModel> userManager, RoleManager<RoleViewModel> roleManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        public async override Task<ClaimsPrincipal> CreateAsync(UserViewModel user)
        {
            var principal = await base.CreateAsync(user);

            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Thumbprint, user.PasswordResetToken));
            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Expiration, user.PasswordResetTokenExpiry.ToBinary().ToString()));

            return principal;
        }
    }
}
