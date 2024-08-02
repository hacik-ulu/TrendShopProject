// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace TrendShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){Scopes = {"CatalogFullPermission","CatalogReadPermission" } },
           new ApiResource("ResourceDiscount"){Scopes = { "DiscountFullPermission" } },
           new ApiResource("OrderDiscount"){Scopes = { "OrderFullPermission" } }

        };

        // Tokenı alınan kullanıcının hangi bilgilere erişim sağlayacağımızı belirliyoruz.
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations")
        };
    }
}