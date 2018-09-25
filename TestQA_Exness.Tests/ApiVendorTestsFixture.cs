using System;
using API.Data;
using RestSharp;
using TestQA_Exness.Tests;

namespace API.Tests
{
    public class ApiVendorTestsFixture : IDisposable
    {
        public ApiVendorTestsFixture()
        {
            InsertTestVendor(TestVendors.Vendor1);
        }

        public void Dispose()
        {
            DeleteTestVendor(TestVendors.Vendor1.Id);
        }

        private void InsertTestVendor(Vendor vendor)
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest("/create", Method.POST);
            request.AddJsonBody(vendor);

            client.Execute<Vendor>(request);
        }

        private void DeleteTestVendor(string id)
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest($"delete/{id}", Method.DELETE);

            client.Execute<Vendor>(request);
        }
    }
}