using System;
using System.Net;
using API.Data;
using RestSharp;
using Xunit;

namespace TestQA_Exness.Tests
{
    public class ApiVendorTests : IClassFixture<ApiVendorTestsFixture>
    {
        //private readonly ApiVendorTestsFixture _fixture;
        private const string BaseApiUrl = "http://localhost:5000/api/vendor";
        private const string ValidIdVendor = "587d6b11-1491-456a-8e5c-d28d99ffdded";
        private const string InValidIdVendor = "587d6b11-1491-456a-8e5c-d28d99ffdd00";
        private const string NewValidIdVendor = "587d6b11-1491-456a-8e5c-d28d99ffdd22";

        private Vendor _newValidVendor = new Vendor
        {
            id = "587d6b11-1491-456a-8e5c-d28d99ffdd22",
            name = "New name",
            rating = 6
        };
        
        /*
        public ApiVendorTests(ApiVendorTestsFixture fixture)
        {
            _fixture = fixture;
        }
        */

        [Fact]
        public void ReturnsCorrectDataWhenIdIsExist()
        {
            //var prop = _fixture.Prop;
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest($"/get/{ValidIdVendor}", Method.GET);
            //request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdded", ParameterType.GetOrPost);

            var response = client.Execute<Vendor>(request);
            var content = response.Data.name;

            Assert.Contains("Testing corp", content);
        }

        
        [Fact]
        public void ReturnHttp200WhenValidId()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest($"/get/{ValidIdVendor}", Method.GET);
            //request.AddParameter("id", "587d6b11-1491-456a-8e5c-d28d99ffdded", ParameterType.GetOrPost);
            
            IRestResponse response = client.Execute<Vendor>(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        

        [Fact]
        public void ReturnHttp404WhenInvalidId()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest($"/get/{InValidIdVendor}", Method.GET);
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

            var request = new RestRequest("/create", Method.POST);
            request.AddJsonBody(_newValidVendor);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        
        
        [Fact]
        public void DeleteCorrectDataWhenIdIsExist_v2()
        {
            var client = new RestClient(BaseApiUrl);

            var request = new RestRequest($"delete/{_newValidVendor.id}", Method.DELETE);

            var response = client.Execute<Vendor>(request);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        
        
        
    }
}
