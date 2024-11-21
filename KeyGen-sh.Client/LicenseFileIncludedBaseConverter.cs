using KeyGenClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace KeyGenClient
{
    public class LicenseFileIncludeBaseConverter : JsonConverter<List<IncludeBase>>
    {
        public override List<IncludeBase> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = new List<IncludeBase>();

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();

            while (reader.TokenType != JsonTokenType.EndArray)
            {
                using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
                {
                    var root = doc.RootElement;
                    var type = root.GetProperty("type").GetString();

                    switch (type)
                    {
                        case "products":
                            var newProduct = JsonSerializer.Deserialize<Product>(root.GetRawText(), options);
                            if (newProduct != null) result.Add(newProduct);
                            break;

                        case "entitlements":
                            var newEntitlement = JsonSerializer.Deserialize<Entitlement>(root.GetRawText(), options);
                            if (newEntitlement != null) result.Add(newEntitlement);
                            break;
                    }

                }

                reader.Read();
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, List<IncludeBase> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
