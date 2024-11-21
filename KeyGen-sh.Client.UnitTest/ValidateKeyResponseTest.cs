using AutoFixture;
using System.Text.Json;
using KeyGenClient.Models;

namespace KeyGenClient.UnitTest
{
    public class ValidateKeyResponseTest
    {
        [Fact]
        public void Serialize_CreatesProperJson_WhenValuesAreProvided()
        {
            var fixture = new Fixture();
            var response = new License();

            var json = $"{{\r\n  \"meta\": {{\r\n    \"ts\": \"2021-03-15T19:27:50.440Z\",\r\n    \"valid\": false,\r\n    \"detail\": \"fingerprint scope does not match\",\r\n    \"code\": \"FINGERPRINT_SCOPE_MISMATCH\",\r\n    \"nonce\": 1574265297,\r\n    \"scope\": {{\r\n      \"fingerprint\": \"9a:Eq:Uv:p3:yZ:tL:lC:Bz:mA:Eg:E6:Mk:YX:dK:NC\"\r\n    }}\r\n  }},\r\n  \"data\": {{\r\n    \"id\": \"b18e3f3a-330c-4d8d-ae2e-014db21fa827\",\r\n    \"type\": \"licenses\",\r\n    \"links\": {{\r\n      \"self\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827\"\r\n    }},\r\n    \"attributes\": {{\r\n      \"name\": null,\r\n      \"key\": \"6DFB15-6597FC-B7DBB6-E34DAB-9D77C0-V3\",\r\n      \"expiry\": \"2022-03-15T19:27:50.440Z\",\r\n      \"status\": \"ACTIVE\",\r\n      \"uses\": 0,\r\n      \"protected\": false,\r\n      \"version\": \"1.0.0\",\r\n      \"suspended\": false,\r\n      \"scheme\": null,\r\n      \"encrypted\": false,\r\n      \"floating\": true,\r\n      \"strict\": false,\r\n      \"maxMachines\": 5,\r\n      \"maxProcesses\": null,\r\n      \"maxUsers\": null,\r\n      \"maxCores\": 64,\r\n      \"maxUses\": null,\r\n      \"requireHeartbeat\": false,\r\n      \"requireCheckIn\": false,\r\n      \"lastValidated\": \"2021-03-15T19:27:50.440Z\",\r\n      \"lastCheckOut\": null,\r\n      \"lastCheckIn\": null,\r\n      \"nextCheckIn\": null,\r\n      \"metadata\": {{}},\r\n      \"created\": \"2017-01-02T20:26:53.464Z\",\r\n      \"updated\": \"2017-01-02T20:26:53.464Z\"\r\n    }},\r\n    \"relationships\": {{\r\n      \"account\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>\"\r\n        }},\r\n        \"data\": {{\r\n          \"type\": \"accounts\",\r\n          \"id\": \"<account>\"\r\n        }}\r\n      }},\r\n      \"product\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827/product\"\r\n        }},\r\n        \"data\": {{\r\n          \"type\": \"products\",\r\n          \"id\": \"eb4e14a7-ea41-4ede-b3fe-5e835c17156b\"\r\n        }}\r\n      }},\r\n      \"policy\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827/policy\"\r\n        }},\r\n        \"data\": {{\r\n          \"type\": \"policies\",\r\n          \"id\": \"70af414d-6152-4ff1-892b-15a40ada6b4e\"\r\n        }}\r\n      }},\r\n      \"owner\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827/owner\"\r\n        }},\r\n        \"data\": {{\r\n          \"type\": \"users\",\r\n          \"id\": \"e8bf27c0-5f9c-4135-a65c-f52706c5fd4c\"\r\n        }}\r\n      }},\r\n      \"users\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827/users\"\r\n        }},\r\n        \"meta\": {{\r\n          \"count\": 0\r\n        }}\r\n      }},\r\n      \"machines\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827/machines\"\r\n        }},\r\n        \"meta\": {{\r\n          \"count\": 0\r\n        }}\r\n      }},\r\n      \"tokens\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827/tokens\"\r\n        }}\r\n      }},\r\n      \"entitlements\": {{\r\n        \"links\": {{\r\n          \"related\": \"/v1/accounts/<account>/licenses/b18e3f3a-330c-4d8d-ae2e-014db21fa827/entitlements\"\r\n        }}\r\n      }}\r\n    }}\r\n  }}\r\n}}";

            var actual = JsonSerializer.Deserialize<KeyGen_sh.Client.Models.License>(json);

            Assert.NotNull(actual);
            Assert.Equal("fingerprint scope does not match", actual.meta.detail);
        }

        [Fact]
        public void Deserialize_CreatesProperJson_WhenValuesAreProvided()
        {
            var fixture = new Fixture();
            var response = new KeyGen_sh.Client.Models.License();

            response.meta.detail = "Test";

            var actual = JsonSerializer.Serialize<KeyGen_sh.Client.Models.License>(response);

            Assert.NotNull(actual);

        }
    }
}
