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

        [Fact]
        public void Returns204StatusWhenDeletedExistVendor()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(DeleteVendorRequest, Method.DELETE);
            request.AddParameter("id", $"{TestVendors.Vendor3.Id}", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public void ReturnsCorrectVendorCategoryDataWhenGetVendorByValidId()
        {
        }

        [Fact]
        public void ReturnsCorrectVendorDataWhenGetVendorByValidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("id", $"{TestVendors.Vendor1.Id}", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Content;

            Assert.Contains("Testing corp", content);
        }

        [Fact]
        public void ReturnsErrorStatusWhenCreateNewVendorWithIncorrectData()
        {
        }

        [Fact]
        public void ReturnsNotFoundStatusWhenDeletedNotExistVendor()
        {
            //or 500 Status?
        }


        [Fact]
        public void ReturnsNotFoundStatusWhenGetVendorByInvalidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("id", $"{TestVendors.Vendor2.Id}", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Content;

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Contains($"Vendor {TestVendors.Vendor2.Id} was not found", content);
        }

        [Fact]
        public void ReturnsNotFoundWhenRequestIncorrect()
        {
        }

        [Fact]
        public void ReturnsOkStatusWhenApiIsAvailable()
        {
        }

        [Fact]
        public void ReturnsOkStatusWhenCreatedNewVendorWithCorrectData()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(CreateVendorRequest, Method.POST);
            request.AddJsonBody(TestVendors.Vendor3);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void ReturnsOkStatusWhenGetValidVendorById()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);
            var request = new RestRequest(GetVendorRequest, Method.GET);
            request.AddParameter("id", $"{TestVendors.Vendor1.Id}", ParameterType.GetOrPost);

            IRestResponse response = client.Execute<Vendor>(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}