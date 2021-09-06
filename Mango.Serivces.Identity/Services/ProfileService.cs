
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Mango.Serivces.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Serivces.Identity.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProfileService(IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string sub = context.Subject.GetSubjectId();
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(sub);
                ClaimsPrincipal userClaim = await _userClaimsPrincipalFactory.CreateAsync(user);

                List<Claim> claims = userClaim.Claims.ToList();
                claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
                claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
                claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));

                if (_userManager.SupportsUserRole)
                {
                    IList<string> roles = await _userManager.GetRolesAsync(user);
                    foreach (var rolename in roles)
                    {
                        claims.Add(new Claim(JwtClaimTypes.Role, rolename));
                        if (_roleManager.SupportsQueryableRoles)
                        {
                            IdentityRole role = await _roleManager.FindByNameAsync(rolename);
                            if (role != null)
                            {
                                claims.AddRange(await _roleManager.GetClaimsAsync(role));
                            }
                        }
                    }
                }
                context.IssuedClaims = claims;
            }
            catch { }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string sub = context.Subject.GetSubjectId();
            ApplicationUser user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
