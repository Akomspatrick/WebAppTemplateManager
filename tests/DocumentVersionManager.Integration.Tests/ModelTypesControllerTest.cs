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

namespace DocumentVersionManager.Integration.Tests
{
    public class ModelTypesControllerTest : IClassFixture<WebApplicationFactory<APIAssemblyRefrence>>,IAsyncLifetime
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5007/api/";
        private readonly List<Guid> createdGuids = new (); 

        public ModelTypesControllerTest(WebApplicationFactory<APIAssemblyRefrence> _appFactory)
        {
            _httpClient = _appFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        [Theory]
        [InlineData("ModelType/", "FIRSTMODELTYPE")]
        [InlineData("ModelType/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        [InlineData("ModelType/", "")]
        //[InlineData("api/ModelType/GetByJSONBody" )]
        public async Task GetModelTypeShouldRetunHttpStatusCode_OK(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }



        [Fact]

        public async Task GetModelTypeByJSONBodyShouldRetunHttpStatusCode_OK()
        {
            // arrange 
         
            var json = JsonConvert.SerializeObject(new ModelTypeGetRequestDTO ("FIRSTMODELTYPE" ));

            _httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5007/api/ModelType/JsonBody"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

         //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetModelTypeByJSONBodyShouldRetunShouldASingleModelType()
        {
            // arrange 
            ModelTypeGetRequestDTO modelTypeGetRequestDTO = new ModelTypeGetRequestDTO("FIRSTMODELTYPE");
            var json = JsonConvert.SerializeObject(modelTypeGetRequestDTO);

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5007/api/ModelType/JsonBody"),

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
        [InlineData("ModelType/", "FIRSTMODELTYPE")]
        [InlineData("ModelType/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        [InlineData("ModelType/", "")]
        public async Task GetResultShoulNotBeNullModelTypeShouldASingleModelType(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            Assert.NotNull(response);
        }


        [Theory]
        [InlineData("ModelType/", "FIRSTMODELTYPE")]
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
        [InlineData("ModelType/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        public async Task GetByIdModelTypeShouldASingleModelType_GUID(string path, string item)
        {

            // act
            var response = await _httpClient.GetAsync(path + item);
            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();

            //assert
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypesId.Should().Be(Guid.Parse(item));
        }

        [Theory]
        [InlineData("ModelType/", "")]
        public async Task GetModelTypeShouldAListOfModelTypes(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<List<ModelTypeResponseDTO>>();
            result.Capacity.Should().BeGreaterThan(1);
        }

        [Theory]
        [InlineData("ModelType/", "FIRSTMODELTYPExx")]
        [InlineData("ModelType/", "59dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        //[InlineData("api/ModelType/GetByJSONBody" )]

        public async Task GetASingleModelTypeShouldRetunHttpStatusCode_NotFound_IfItemDoesNotExit(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            var text = await response.Content.ReadAsStringAsync();
            var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        }

        [Theory]

        [InlineData("ModelTypexxx/", "FIRSTMODELTYPE")]
        public async Task ShouldReturnNotFoundIfPathIsWrong(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData("ModelType")]

        public async Task PostShouldCreateModelTypeObject(string path)
        {
            //araange
           var  faker = new AutoFaker<ModelTypeGetRequestDTO>().RuleFor(x => x.ModelTypeName, f =>f.Commerce.ProductName()); 
           ModelTypeGetRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var response = await _httpClient.PostAsJsonAsync(path ,modelTypeGetRequestDTO);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
           //  createdGuids.Add(response.Headers.Location.OriginalString.Split("/"));  

        }

        public Task InitializeAsync() => Task.CompletedTask;

        public Task DisposeAsync() => Task.CompletedTask;
        //{
        //    throw new NotImplementedException();
        //}
    }
}
