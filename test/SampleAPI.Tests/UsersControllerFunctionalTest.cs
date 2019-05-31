using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SampleAPI.Domain.Infrastructure.Data;
using SampleAPI.Tests.Common;
using SampleAPI.Tests.Util;
using System.Linq;
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
            // Execute
            var response = await _client.GetAsync(Endpoints.USERS);
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(SeedExtensions.UsersSeed.Serialize(), content);
        }

        [Fact]
        public async Task GetByUsername_UnexistingUser_ReturnsError()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{Endpoints.USERS}/unknown");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetByUsername_User_ReturnsUser()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{Endpoints.USERS}/{SeedExtensions.UsersSeed.FirstOrDefault().Username}");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(SeedExtensions.UsersSeed.FirstOrDefault().Serialize(), content);
        }
    }
}
