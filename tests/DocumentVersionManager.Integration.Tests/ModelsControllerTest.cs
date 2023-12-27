using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net;
using DocumentVersionManager.Api;
using FluentAssertions;
using DocumentVersionManager.Contracts.ResponseDTO;
using Newtonsoft.Json;
using DocumentVersionManager.Contracts.RequestDTO;
using LanguageExt.Pipes;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using ZXing.Aztec.Internal;
using System.Text;
using Bogus;
using AutoBogus;
using LanguageExt.Common;
using Microsoft.AspNetCore.Http;

namespace DocumentVersionManager.Integration.Tests
{
    public class ModelsControllerTest : IClassFixture<WebApplicationFactory<APIAssemblyRefrence>>, IAsyncLifetime
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5007/api/";
        private readonly List<Guid> createdGuids = new();

        public ModelsControllerTest(WebApplicationFactory<APIAssemblyRefrence> _appFactory)
        {
            _httpClient = _appFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        [Theory]
        [InlineData("Model/", "SECONDMODELNAME")]
        [InlineData("Model/", "7808711f-544a-423d-8d99-f00c31e35be5")]
        // [InlineData("Model/", "")]
        public async Task GetModelShouldRetunHttpStatusCode_OK(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]

        public async Task GetModelByJSONBodyShouldRetunHttpStatusCode_OK()
        {
            // arrange 

            var json = JsonConvert.SerializeObject(new ModelGetRequestDTO("SECONDMODELNAME"));

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5007/api/Model/JsonBody"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetModelByJSONBodyShouldRetunShouldASingleModelType()
        {
            // arrange 
            ModelGetRequestDTO modelGetRequestDTO = new ModelGetRequestDTO("SECONDMODELNAME");
            var json = JsonConvert.SerializeObject(modelGetRequestDTO);

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5007/api/Model/JsonBody"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ModelResponseDTO>();
            result.Should().BeAssignableTo<ModelResponseDTO>();
            result.ModelName.Should().Be(modelGetRequestDTO.ModelName);
        }


        [Theory]
        [InlineData("Model/", "SECONDMODELNAME")]
        [InlineData("Model/", "7808711f-544a-423d-8d99-f00c31e35be5")]
        [InlineData("Model/", "")]
        public async Task GetResultShoulNotBeNullModelTypeShouldASingleModelType(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            Assert.NotNull(response);
        }


        [Theory]
        [InlineData("Model/", "SECONDMODELNAME")]
        public async Task GetByIdModelShouldASingleModelType(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            var result = await response.Content.ReadFromJsonAsync<ModelResponseDTO>();

            //assert
            result.Should().BeAssignableTo<ModelResponseDTO>();
            result.ModelName.Should().Be(item);
        }

        [Theory]
        [InlineData("Model/", "7808711f-544a-423d-8d99-f00c31e35be5")]
        public async Task GetByIdModeShouldASingleModelType_GUID(string path, string item)
        {

            // act
            var response = await _httpClient.GetAsync(path + item);
            var result = await response.Content.ReadFromJsonAsync<ModelResponseDTO>();

            //assert
            result.Should().BeAssignableTo<ModelResponseDTO>();
            result.GuidId.Should().Be(Guid.Parse(item));
        }

        [Theory]
        [InlineData("Model/", "")]
        public async Task GetModelShouldAListOfModelTypes(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<List<ModelResponseDTO>>();
            result.Capacity.Should().BeGreaterThan(1);
        }

        [Theory]
        [InlineData("Model/", "SECONDMODELNAMEXX")]
        [InlineData("Model/", "9908711f-544a-423d-8d99-f00c31e35be5")]

        public async Task GetASingleModelShouldRetunHttpStatusCode_NotFound_IfItemDoesNotExit(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            //var text = await response.Content.ReadAsStringAsync();
            //var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        }

        [Theory]

        [InlineData("Modelxxx/", "SECONDMODELNAME")]
        public async Task ShouldReturnNotFoundIfPathIsWrong(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData("Model")]

        public async Task PostShouldReturnCreated_WhenModelNameIsUniqueAndModelTypeExist(string path)
        {
            //araange
            var faker = new AutoFaker<ModelCreateRequestDTO>()
                .RuleFor(x => x.GuidId, f => Guid.NewGuid())
                .RuleFor(x => x.ModelName, f => f.Commerce.ProductName())
               .RuleFor(x => x.ModelTypesName, f => "FIRSTMODELTYPE");
            ModelCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            //  createdGuids.Add(response.Headers.Location.OriginalString.Split("/"));  

        }

        [Theory]
        [InlineData("Model")]

        public async Task PostShouldReturn_BadRequest_WhenModelNameIsUniqueAndModelTypeDoesNotExist(string path)
        {
            //araange
            var faker = new AutoFaker<ModelCreateRequestDTO>()
                .RuleFor(x => x.GuidId, f => Guid.NewGuid())
                .RuleFor(x => x.ModelName, f => f.Commerce.ProductName())
               .RuleFor(x => x.ModelTypesName, f => f.Commerce.ProductName());
            ModelCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
        }
        public Task InitializeAsync() => Task.CompletedTask;

        public Task DisposeAsync() => Task.CompletedTask;
        //{
        //    throw new NotImplementedException();
        //}
    }
}
