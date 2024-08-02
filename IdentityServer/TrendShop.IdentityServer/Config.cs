// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace TrendShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           // Api erişim kaynakları.

           new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){Scopes = { "OrderFullPermission" } }

        };

        // Tokenı alınan kullanıcının hangi bilgilere erişim sağlayacağımızı belirliyoruz.
        // Kullanıcıların bazı bilgilerini almak için kullanılır.
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            // Api erişim izinlerini kontrol ederiz.
            // Scope --> Kaynak

            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermisson","Full authority for order operations")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor Client
            new Client
            {
                ClientId = "TrendShopVisitorId",
                ClientName ="Trend Shop Visitor User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("trendshopsecret".Sha256())},
                AllowedScopes = {"CatalogReadPermission"}
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

            //Admin
            new Client
            {
                ClientId = "TrendShopAdminId",
                ClientName = "Trend Shop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("trendshopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermisson",
                IdentityServerConstants.LocalApi.ScopeName,

                // Admin kullanıcı bilgilerine erişiyor.
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                },

                AccessTokenLifetime = 600
            },
        };
    }
}