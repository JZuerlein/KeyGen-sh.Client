using AutoFixture;
using KeyGen_sh.Client.Models;
using System.Text.Json;

namespace KeyGen_sh.Client.UnitTest
{
    public class ValidateLicenseKeyRequestTest
    {
        [Fact]
        public void Serialize_CreatesProperJson_WhenValuesAreProvided()
        {
            //Arrange
            var fixture = new Fixture();
            var request = new ValidateLicenseByKeyRequest();

            request.meta.key = fixture.Create<string>();
            request.meta.nonce = fixture.Create<int>();
            request.meta.scope.fingerprint = fixture.Create<string>();

            var expected = $"{{\"meta\":{{\"key\":\"{request.meta.key}\",\"nonce\":{request.meta.nonce},\"scope\":{{\"fingerprint\":\"{request.meta.scope.fingerprint}\"}}}}}}";

            //Act
            var actual = JsonSerializer.Serialize(request);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
