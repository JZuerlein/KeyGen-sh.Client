﻿using System.Text.Json.Serialization;

namespace KeyGenClient.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(Product), "products")]
    [JsonDerivedType(typeof(Entitlement), "entitlements")]
    public class IncludeBase
    {
        public string type { get; set; } = string.Empty;
    }
}
