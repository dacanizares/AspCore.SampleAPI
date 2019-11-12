using Newtonsoft.Json;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Migrations.Data;
using SampleAPI.Tests.Common;
using SampleAPI.Tests.Util;
using SampleAPI.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SampleAPI.Tests
{
    public class UsersControllerFunctionalTest : WebTest
    {
        [Fact]
        public async Task Get_ReturnsSeededList()
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

        [Fact]
        public async Task Create_WithoutUsername_ReturnsError()
        {
            // Prepare
            var createUserCommand = new CreateUserCommand
            {
                Email = "something@nothing.com"
            };

            // Execute
            var response = await _client.PostAsJsonAsync(Endpoints.USERS, createUserCommand);
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsUser()
        {
            // Prepare
            var createUserCommand = new CreateUserCommand
            {
                Username = "Mr. Test",
                Email = "something@nothing.com"
            };

            // Execute
            var responseCreate = await _client.PostAsJsonAsync(Endpoints.USERS, createUserCommand);
            var contentCreate = await responseCreate.Content.ReadAsStringAsync();

            // Check
            var expectedBasicUser = new BasicUserViewModel
            {
                Username = createUserCommand.Username,
                Email = createUserCommand.Email,
                IsActive = true
            };
            Assert.Equal(HttpStatusCode.Created, responseCreate.StatusCode);
            Assert.Equal(expectedBasicUser.Serialize(), contentCreate);

        }

        [Fact]
        public async Task Create_UserAndThenQuerying_ReturnsUser()
        {
            // Prepare
            var createUserCommand = new CreateUserCommand
            {
                Username = "MrTest",
                Email = "something@nothing.com"
            };

            // Execute
            var responseCreate = await _client.PostAsJsonAsync(Endpoints.USERS, createUserCommand);
            var contentCreate = await responseCreate.Content.ReadAsStringAsync();

            var responseGetByUsername = await _client.GetAsync(
                $"{Endpoints.USERS}/{createUserCommand.Username}");
            var resultUser = JsonConvert.DeserializeObject<User>(await responseGetByUsername.Content.ReadAsStringAsync());

            // Check
            // Creation
            var expectedBasicUser = new BasicUserViewModel
            {
                Username = createUserCommand.Username,
                Email = createUserCommand.Email,
                IsActive = true
            };
            Assert.Equal(HttpStatusCode.Created, responseCreate.StatusCode);
            Assert.Equal(expectedBasicUser.Serialize(), contentCreate);

            // GetByUsername
            Assert.Equal(HttpStatusCode.OK, responseGetByUsername.StatusCode);
            Assert.Equal(createUserCommand.Username, resultUser.Username);
            Assert.Equal(createUserCommand.Email, resultUser.Email);
            Assert.True(resultUser.IsActive);
            Assert.NotNull(resultUser.CreatedAt);
            Assert.NotNull(resultUser.UpdatedAt);
        }
    }
}
