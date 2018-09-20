using System.Net;
using API.Data;
using RestSharp;
using Xunit;

namespace TestQA_Exness.Tests
{
    public class ApiVendorTests
    {
        private const string BaseApiUrl = "https://localhost:5001";

        public ApiVendorTests()
        {
            
        }

        [Fact]
        public void ReturnsCorrectDataWhenIdIsExist()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest("/api/vendor/587d6b11-1491-456a-8e5c-d28d99ffdded", Method.GET);
            //request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdded", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Data.name;

            Assert.Contains("Testing corp", content);
        }

        [Fact]
        public void ReturnHttp200WhenValidId()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest("/api/vendor/587d6b11-1491-456a-8e5c-d28d99ffdded", Method.GET);
            //request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdded", ParameterType.GetOrPost);
            
            IRestResponse response = client.Execute<Vendor>(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void ReturnHttp404WhenInvalidId()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest("/api/vendor/587d6b11-1491-456a-8e5c-d28d99ffdd00", Method.GET);
            //request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdd00", ParameterType.GetOrPost);
            
            var response = client.Execute<Vendor>(request);
            var content = response.Content;
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Contains("Vendor 587d6b11-1491-456a-8e5c-d28d99ffdd00 was not found", content);
        }


        [Fact]
        public void Create_NewVendor()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest("/api/vendor", Method.POST);
            request.AddJsonBody(new Vendor
            {
                id = "587d6b11-1491-456a-8e5c-d28d99ffdd11",
                name = "New name",
                rating = 6
            });

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public void DeleteCorrectDataWhenIdIsExist()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest("/api/vendor", Method.POST);
            request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdd11", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
