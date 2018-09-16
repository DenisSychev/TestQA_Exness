using System;
using System.Net;
using RestSharp;
using Xunit;
using Xunit.Sdk;

namespace TestQA_Exness.Tests
{
    public class ApiVendorTests
    {
        [Fact]
        public void ReturnsCorrectDataWhenIdIsExist()
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/api/vendor/get", Method.GET);
            request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdded", ParameterType.GetOrPost);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Assert.Contains("Testing corp", content);
        }

        [Fact]
        public void ReturnHttp200WhenValidId()
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/api/vendor/get", Method.GET);
            request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdded", ParameterType.GetOrPost);
            
            IRestResponse response = client.Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void ReturnHttp404WhenInvalidId()
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/api/vendor/get", Method.GET);
            request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdd00", ParameterType.GetOrPost);
            
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Contains("Vendor 587d6b11-1491-456a-8e5c-d28d99ffdd00 is not found", content);
        }
    }
}
