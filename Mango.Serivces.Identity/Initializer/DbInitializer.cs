using IdentityModel;
using Mango.Serivces.Identity.DbContexts;
using Mango.Serivces.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Serivces.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._db = db;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public void Initialize()
        {
            if(_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "farnood_t@yahoo.com",
                Email = "farnood_t@yahoo.com",
                EmailConfirmed = true,
                PhoneNumber = "9499229627",
                FirstName = "Farnood",
                LastName = "Borhani"
            };

            _userManager.CreateAsync(adminUser, "Admin123$").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName+ " " + adminUser.LastName ),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.FirstName),
                new Claim(JwtClaimTypes.Role, SD.Admin )
            }).Result;

            ApplicationUser CustomerUser = new ApplicationUser()
            {
                UserName = "farnodtaghdisi@gmail.com",
                Email = "farnodtaghdisi@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "9499229627",
                FirstName = "Aidin",
                LastName = "Borhani"
            };

            _userManager.CreateAsync(CustomerUser, "Customer123$").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(CustomerUser, SD.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(CustomerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, CustomerUser.FirstName+ " " + CustomerUser.LastName ),
                new Claim(JwtClaimTypes.GivenName, CustomerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, CustomerUser.FirstName),
                new Claim(JwtClaimTypes.Role, SD.Customer )
            }).Result;
        }
    }
}
