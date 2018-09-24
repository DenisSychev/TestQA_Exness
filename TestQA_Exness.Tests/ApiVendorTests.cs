using System;
using System.Net;
using API.Data;
using RestSharp;
using Xunit;

namespace TestQA_Exness.Tests
{

    public class ApiVendorTests : IClassFixture<ApiVendorTestsFixture>
    {
        [Fact]
        public void ReturnsCorrectDataWhenIdIsExist()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest("/get", Method.GET);
            request.AddParameter("id", $"{TestVendors.Vendor1.Id}", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Data.Name;

            Assert.Contains("Testing corp", content);
        }

        
        [Fact]
        public void ReturnHttp200WhenValidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest("/get", Method.GET);
            request.AddParameter("id", $"{TestVendors.Vendor1.Id}", ParameterType.GetOrPost);
            
            IRestResponse response = client.Execute<Vendor>(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        

        [Fact]
        public void ReturnHttp404WhenInvalidId()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest("/get", Method.GET);
            request.AddParameter("id", $"{TestVendors.Vendor2.Id}", ParameterType.GetOrPost);
            
            var response = client.Execute<Vendor>(request);
            var content = response.Content;
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Contains($"Vendor {TestVendors.Vendor2.Id} was not found", content);
        }


        [Fact]
        public void Create_NewVendor()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest("/create", Method.POST);
            request.AddJsonBody(TestVendors.Vendor3);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        
        
        [Fact]
        public void DeleteCorrectDataWhenIdIsExist()
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest("/delete", Method.DELETE);
            request.AddParameter("id", $"{TestVendors.Vendor3.Id}", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        
    }
}
