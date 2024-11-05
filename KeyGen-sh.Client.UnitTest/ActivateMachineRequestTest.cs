using AutoFixture;
using System.Text.Json;
using KeyGen_sh.Client.Models;

namespace KeyGen_sh.Client.UnitTest
{
    public class ActivateMachineRequestTest
    {
        [Fact]
        public void Serialize_CreatesProperJson_WhenValuesAreProvided()
        {
            //Arrange
            var fixture = new Fixture();
            var request = new ActivateMachineRequest();
            request.data.type = "machines";
            request.data.attributes.name = fixture.Create<string>();
            request.data.attributes.platform = fixture.Create<string>();
            request.data.attributes.fingerprint = fixture.Create<string>();
            request.data.relationships.license.data.type = fixture.Create<string>();
            request.data.relationships.license.data.id = fixture.Create<string>();

            var expected = $"{{\"data\":{{\"type\":\"machines\",\"attributes\":{{\"fingerprint\":\"{request.data.attributes.fingerprint}\",\"platform\":\"{request.data.attributes.platform}\",\"name\":\"{request.data.attributes.name}\"}},\"relationships\":{{\"license\":{{\"data\":{{\"type\":\"{request.data.relationships.license.data.type}\",\"id\":\"{request.data.relationships.license.data.id}\"}}}}}}}}}}";

            //Act
            var actual = JsonSerializer.Serialize(request);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}