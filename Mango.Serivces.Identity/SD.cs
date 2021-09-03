using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Serivces.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
           };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> {
                new ApiScope("mango", "MangoServer"),
                new ApiScope(name: "read", displayName:"Read your data."),
                new ApiScope(name: "write", displayName:"write your data."),
                new ApiScope(name: "delete", displayName:"Delete your data.")
            };

        public static IEnumerable<Client> clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secrt".Sha256())},
                    AllowedGrantTypes = new List<string> {GrantType.ClientCredentials },
                    AllowedScopes = {"read","write","profile"}
                },
                new Client
                {
                    ClientId = "mango",
                    ClientSecrets = {new Secret("secrt".Sha256())},
                    RedirectUris={ "https://localhost:44313/signin-oidc" },
                    PostLogoutRedirectUris={ "https://localhost:44313/signout-callback-oidc" },
                    AllowedGrantTypes = new List<string> {GrantType.AuthorizationCode },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "mango"
                    }
                }
            };

    }
}
