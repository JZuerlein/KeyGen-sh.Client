using AutoFixture;
using System.Text.Json;
using KeyGenClient.Models;

namespace KeyGenClient.IntegrationTest
{
    public class KeyGenClientTests
    {
        [Fact]
        public void CheckOutLicenseUrl_ReturnUrl_WithProvidedLicenseKey()
        {
            //Arranged
            var fixture = new Fixture();
            var account = fixture.Create<string>();
            var licenseKey = fixture.Create<string>();
            var httpClient = new HttpClient();
            var sut = new Client(httpClient, account);
            var expected = $"https://api.keygen.sh/v1/accounts/{account}/licenses/{licenseKey}/actions/check-out";

            //Act
            var actual = sut.CheckOutLicenseUrl(licenseKey, false, false);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckOutLicenseUrl_ReturnUrl_WithEncryption()
        {
            //Arranged
            var fixture = new Fixture();
            var account = fixture.Create<string>();
            var licenseKey = fixture.Create<string>();
            var httpClient = new HttpClient();
            var sut = new Client(httpClient, account);
            var expected = $"https://api.keygen.sh/v1/accounts/{account}/licenses/{licenseKey}/actions/check-out?encrypt=1";

            //Act
            var actual = sut.CheckOutLicenseUrl(licenseKey, true, false);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckOutLicenseUrl_ReturnUrl_WithEntitlements()
        {
            //Arranged
            var fixture = new Fixture();
            var account = fixture.Create<string>();
            var licenseKey = fixture.Create<string>();
            var httpClient = new HttpClient();
            var sut = new Client(httpClient, account);
            var expected = $"https://api.keygen.sh/v1/accounts/{account}/licenses/{licenseKey}/actions/check-out?include=entitlements";

            //Act
            var actual = sut.CheckOutLicenseUrl(licenseKey, false, true);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckOutLicenseUrl_ReturnUrl_WithEncryptionAndEntitlements()
        {
            //Arranged
            var fixture = new Fixture();
            var account = fixture.Create<string>();
            var licenseKey = fixture.Create<string>();
            var httpClient = new HttpClient();
            var sut = new Client(httpClient, account);
            var expected = $"https://api.keygen.sh/v1/accounts/{account}/licenses/{licenseKey}/actions/check-out?encrypt=1&include=entitlements";

            //Act
            var actual = sut.CheckOutLicenseUrl(licenseKey, true, true);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void ValidateLicense()
        {
            var httpClient = new HttpClient();
            var account = "demo";
            var client = new Client(httpClient, account);

            var request = new ValidateLicenseByKeyRequest();
            request.meta.key = "0BB042-E1A90B-A5DC67-D651E0-73E6C5-V3";
            request.meta.scope.fingerprint = "4d:Eq:UV:D3:XZ:tL:WN:Bz:mA:Eg:E6:Mk:YX:dK:NC";

            var response = await client.ValidateLicense(request);

            Assert.NotNull(response);
            Assert.Equal(request.meta.scope.fingerprint, response.meta.scope.fingerprint);
            Assert.Equal(request.meta.key, response.data.attributes.key);
        }

        [Fact]
        public async void ActivateMachine()
        {
            //Arrange
            var account = "demo";
            var licenseKey = "0BB042-E1A90B-A5DC67-D651E0-73E6C5-V3";

            var httpClient = new HttpClient();
            var client = new Client(httpClient, account);

            var request = new ActivateMachineRequest();
            request.data.attributes.fingerprint = client.CreateFingerprint();
            request.data.type = "machines";
            request.data.relationships.license.data.type = "licenses";
            request.data.relationships.license.data.id = licenseKey;

            //Act
            var response = await client.ActivateMachine(request, licenseKey);


            //Assert
            Assert.NotNull(response);
            //Assert.Equal(request.data.attributes.fingerprint, response.data.attributes.fingerprint);
        }

        [Fact]
        public async void CheckOutLicense()
        {
            //Arrange
            var account = "demo";
            var licenseKey = "0BB042-E1A90B-A5DC67-D651E0-73E6C5-V3";

            var httpClient = new HttpClient();
            var client = new Client(httpClient, account);

            //Act
            var response = await client.CheckOutLicense(licenseKey);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.data.attributes.certificate.Length > 20);
            Assert.True(response.data.attributes.expiry > DateTime.Now);
        }
    }
}
