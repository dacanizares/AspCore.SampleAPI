using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SampleAPI.Domain.Infrastructure.Data;
using SampleAPI.Tests.Common;
using SampleAPI.Tests.Util;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SampleAPI.Tests
{
    public class UsersControllerFunctionalTest : WebTest
    {
        [Fact]
        public async Task Get_User_ReturnsSeededList()
        {
            // Ejecutar
            var response = await _client.GetAsync(Endpoints.USERS);
            var content = await response.Content.ReadAsStringAsync();

            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(SeedExtensions.UsersSeed.Serialize(), content);
        }
    }
}
