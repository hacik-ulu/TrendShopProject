using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace TrendShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            // Api erişim kaynakları.
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
            new ApiResource("ResourceOrder"){Scopes = { "OrderFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        // Tokenı alınan kullanıcının hangi bilgilere erişim sağlayacağımızı belirliyoruz.
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            // Api erişim izinlerini kontrol ederiz.
            // Scope --> Kaynak, kapsam
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),  
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor Client
            new Client
            {
                ClientId = "TrendShopVisitorId",
                ClientName = "Trend Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("trendshopsecret".Sha256())},
                AllowedScopes = { "DiscountFullPermission" }
            },

            // Manager
            new Client
            {
                ClientId = "TrendShopManagerId",
                ClientName = "Trend Shop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("trendshopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
            },

            // Admin
            new Client
            {
                ClientId = "TrendShopAdminId",
                ClientName = "Trend Shop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("trendshopsecret".Sha256())},
                AllowedScopes={
                    "CatalogFullPermission",
                    "CatalogReadPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",  
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            },
        };
    }
}
