using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace vega.OAuth.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                // Add a resource for some set of APIs that we may be protecting
                // Note that the constructor will automatically create an allowed scope with
                // name and claims equal to the resource's name and claims. If the resource
                // has different scopes/levels of access, the scopes property can be set to
                // list specific scopes included in this resource, instead.
                new ApiResource(
                    "vega",  // Api resource name
                    "VEGA API" // Display name
                              ) // Claims to be included in access token
            };
        }


        public static IEnumerable<Client> Clients { get; } = new[]
        {
            new Client
            {
                ClientId = "vega",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AllowedScopes =  { "vega" }
            },

            // OpenID Connect implicit flow client (MVC)
            new Client
            {
                ClientId = "vega_mvc",
                ClientName = "MVC Client",
                AllowedGrantTypes = GrantTypes.Implicit,

                RedirectUris = { "http://localhost:5001/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },
                AllowAccessTokensViaBrowser = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "mail@serii.md",
                    Password = "password",

                    Claims = new []
                    {
                        new Claim("name", "Serii"),
                        new Claim("website", "https://serii.com")
                    }
                },

                new TestUser
                {
                    SubjectId = "2",
                    Username = "mail2@serii.md",
                    Password = "password2",
                    Claims = new []
                    {
                        new Claim("name", "Serii2"),
                        new Claim("website", "https://serii_2.com")
                    }

                },

            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }


    }
}
