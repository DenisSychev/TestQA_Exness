using System;
using System.Net;
using API.Data;
using RestSharp;
using TestQA_Exness.Tests;
using Xunit;

namespace API.Tests
{
    public class ApiVendorTests : IClassFixture<ApiVendorTestsFixture>
    {
        public ApiVendorTests()
        {
            _vendorProvider = new TestVendorProvider();
        }

        private readonly TestVendorProvider _vendorProvider;

        [Fact]
        public void Returns204StatusWhenDeletedExistVendor()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.DeleteVendorRequest, Method.DELETE);
            request.AddParameter("id", _vendorProvider.Vendor3.Id, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public void ReturnsCorrectVendorCategoryDataWhenGetVendorByValidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.GetVendorRequest, Method.GET);
            request.AddParameter("id", _vendorProvider.Vendor1.Id, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_vendorProvider.Vendor1.Categories[0].Id, response.Data.Categories[0].Id);
            Assert.Equal(_vendorProvider.Vendor1.Categories[1].Id, response.Data.Categories[1].Id);
        }

        [Fact]
        public void ReturnsCorrectVendorDataWhenGetVendorByValidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.GetVendorRequest, Method.GET);
            request.AddParameter("id", _vendorProvider.Vendor1.Id, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(_vendorProvider.Vendor1.Name, response.Data.Name);
        }

        [Fact]
        public void ReturnsErrorStatusWhenCreatedNewVendorWithIncorrectData()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.CreateVendorRequest, Method.POST);
            request.AddJsonBody(_vendorProvider.IncorrectVendor);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public void ReturnsNotFoundStatusWhenDeletedNotExistVendor()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.DeleteVendorRequest, Method.DELETE);
            request.AddParameter("id", Guid.Empty, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void ReturnsNotFoundStatusWhenGetVendorByInvalidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.GetVendorRequest, Method.GET);
            request.AddParameter("id", Guid.Empty, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Content;

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Contains($"Vendor {Guid.Empty} was not found", content);
        }

        [Fact]
        public void ReturnsNotFoundWhenRequestIsIncorrect()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.GetVendorRequest, Method.GET);
            request.AddParameter("name", _vendorProvider.Vendor1.Name, ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Fact]
        public void ReturnsOkStatusWhenCreatedNewVendorWithCorrectData()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.CreateVendorRequest, Method.POST);
            request.AddJsonBody(_vendorProvider.NewVendor);
            client.Execute<Vendor>(request);

            request = new RestRequest(ApiRequestMethods.GetVendorRequest, Method.GET);
            request.AddParameter("id", _vendorProvider.NewVendor.Id);
            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_vendorProvider.NewVendor.Name, response.Data.Name);
            Assert.Equal(_vendorProvider.NewVendor.Id, response.Data.Id);
            Assert.Equal(_vendorProvider.NewVendor.Rating, response.Data.Rating);
        }

        [Fact]
        public void ReturnsOkStatusWhenGetValidVendorById()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(ApiRequestMethods.GetVendorRequest, Method.GET);
            request.AddParameter("id", _vendorProvider.Vendor1.Id, ParameterType.GetOrPost);

            IRestResponse response = client.Execute<Vendor>(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}