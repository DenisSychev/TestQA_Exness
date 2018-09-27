using System.Net;
using API.Data;
using RestSharp;
using TestQA_Exness.Tests;
using Xunit;

namespace API.Tests
{
    public class ApiVendorTests : IClassFixture<ApiVendorTestsFixture>
    {
        private const string GetVendorRequest = "/get";
        private const string CreateVendorRequest = "/create";
        private const string DeleteVendorRequest = "/delete";

        private readonly TestVendorCategoryProvider _categoryProvider;
        private readonly TestVendorProvider _vendorProvider;

        public ApiVendorTests()
        {
            _vendorProvider = new TestVendorProvider();
            _categoryProvider = new TestVendorCategoryProvider();
        }
        
        [Fact]
        public void ReturnsCorrectVendorDataWhenGetVendorByValidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("id", _vendorProvider.Vendor1.Id, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Content;

            Assert.Contains("Testing corp", content);
        }
        
        [Fact]
        public void ReturnsOkStatusWhenGetValidVendorById()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("id", $"{_vendorProvider.Vendor1.Id}", ParameterType.GetOrPost);

            IRestResponse response = client.Execute<Vendor>(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public void ReturnsNotFoundStatusWhenGetVendorByInvalidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("id", $"{_vendorProvider.Vendor2.Id}", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Content;

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Contains($"Vendor {_vendorProvider.Vendor2.Id} was not found", content);
        }
        
        [Fact]
        public void ReturnsOkStatusWhenCreatedNewVendorWithCorrectData()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(CreateVendorRequest, Method.POST);
            request.AddJsonBody(_vendorProvider.Vendor3);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Returns204StatusWhenDeletedExistVendor()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(DeleteVendorRequest, Method.DELETE);
            request.AddParameter("id", $"{_vendorProvider.Vendor3.Id}", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public void ReturnsCorrectVendorCategoryDataWhenGetVendorByValidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("id", _vendorProvider.Vendor1.Id, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Content;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Testing software", content);
            Assert.Contains("System utilities", content);
            Assert.Contains(_vendorProvider.Vendor1.Id, content);
            Assert.Contains(_categoryProvider.Category1.Id, content);
        }

        [Fact]
        public void ReturnsNotFoundStatusWhenDeletedNotExistVendor()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(DeleteVendorRequest, Method.DELETE);
            request.AddParameter("id", $"{_vendorProvider.Vendor2.Id}", ParameterType.GetOrPost);
            
            var response = client.Execute<Vendor>(request);
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void ReturnsNotFoundWhenRequestIncorrect()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("name", _vendorProvider.Vendor1.Name, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Fact]
        public void ReturnsErrorStatusWhenCreateNewVendorWithIncorrectData()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(CreateVendorRequest, Method.POST);
            request.AddJsonBody(_vendorProvider.Vendor4);
            
            var response = client.Execute<Vendor>(request);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public void ReturnsOkStatusWhenApiIsAvailable()
        {
            //Не будет ли эта проверка дублировать проверку на корректный ответ при запросе корректного Вендора?
        }
        
    }
}