using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.Helpers
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource> 
            { 
                 new IdentityResources.OpenId(),
                 new IdentityResources.Profile(),
                 new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> 
            { 
                new ApiResource("AspNetCore_Api")
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client 
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = 
                    { 
                        "AspNetCore_Api", 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    RequireConsent = false
                }
            };
    }
}
