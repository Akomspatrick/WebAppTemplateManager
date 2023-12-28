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
using System.IO;
using static System.Net.WebRequestMethods;

namespace DocumentVersionManager.Integration.Tests
{
    public class ModelTypesControllerTest : IClassFixture<WebApplicationFactory<APIAssemblyRefrence>>, IAsyncLifetime
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = $"http://localhost:5007/{DocumentVersionManagerAPIEndPoints.APIBase}/";
        private readonly List<Guid> createdGuids = new();

        public ModelTypesControllerTest(WebApplicationFactory<APIAssemblyRefrence> _appFactory)
        {
            _httpClient = _appFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPE")]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "")]
        public async Task GetModelTypeShouldRetunHttpStatusCode_OK(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Theory]
        [InlineData($"http://localhost:5007/{DocumentVersionManagerAPIEndPoints.APIBase}/{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/JsonBody/", "FIRSTMODELTYPE")]
        [InlineData($"http://localhost:5007/{DocumentVersionManagerAPIEndPoints.APIBase}/{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/JsonBody/", "SECONDMODELTYPE")]
        public async Task GetModelTypeByJSONBodyShouldRetunHttpStatusCode_OK(string path, string item)
        {
            // arrange 

            var json = JsonConvert.SerializeObject(new ModelTypeGetRequestDTO(item));

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(path),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData($"http://localhost:5007/{DocumentVersionManagerAPIEndPoints.APIBase}/{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/JsonBody/", "FIRSTMODELTYPE")]
        [InlineData($"http://localhost:5007/{DocumentVersionManagerAPIEndPoints.APIBase}/{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/JsonBody/", "SECONDMODELTYPE")]
        public async Task GetModelTypeByJSONBodyShouldRetunShouldAnObjectOfTypeModelTypeEntityWhenSuccesful(string path, string item)
        {
            // arrange 
            ModelTypeGetRequestDTO modelTypeGetRequestDTO = new ModelTypeGetRequestDTO(item);
            var json = JsonConvert.SerializeObject(modelTypeGetRequestDTO);

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(path),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypeName.Should().Be(modelTypeGetRequestDTO.ModelTypeName);

        }



        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPE")]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "")]
        public async Task GetResultShoulNotBeNullModelTypeShouldASingleModelType(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            Assert.NotNull(response);
        }


        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPE")]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "SECONDMODELTYPE")]
        public async Task GetByIdModelTypeShouldASingleModelType(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();

            //assert
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypeName.Should().Be(item);
        }

        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        public async Task GetByIdModelTypeShouldASingleModelType_GUID(string path, string item)
        {

            // act
            var response = await _httpClient.GetAsync(path + item);
            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();

            //assert
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypeId.Should().Be(Guid.Parse(item));
        }

        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "")]
        public async Task GetModelTypeShouldAListOfModelTypes(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<List<ModelTypeResponseDTO>>();
            result.Capacity.Should().BeGreaterThan(1);
        }

        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPEWRONG")]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}/", "99dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        public async Task GetASingleModelTypeShouldRetunHttpStatusCode_NotFound_IfItemDoesNotExit(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}WRONG/", "FIRSTMODELTYPE")]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}WRONG/", "SECONDMODELTYPE")]
        public async Task ShouldReturnNotFoundIfPathIsWrong(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}")]
        public async Task PostShouldReturnCreated_WhenModelTypeNameIsUnique(string path)
        {
            //araange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}")]
        public async Task PostShouldReturnBadRequest_When_DuplicateModelTypeName(string path)
        {
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var response1 = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }


        [Theory]
        [InlineData($"{DocumentVersionManagerAPIEndPoints.ModelType.Controller}")]
        public async Task PostShouldCreateModelTypeObject_WithCorrectHeaderLocation_WhenSuccessful(string path)
        {
            //arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var ExpetedHeaderLocation = $"{path}/{modelTypeGetRequestDTO.GuidId}";

            //act
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
 
            //assert

           response.Headers.Location?.OriginalString.Should().EndWith(ExpetedHeaderLocation);  

        }

        public Task InitializeAsync() => Task.CompletedTask;

        public Task DisposeAsync() => Task.CompletedTask;
        //{
        //    throw new NotImplementedException();
        //}
    }
}
