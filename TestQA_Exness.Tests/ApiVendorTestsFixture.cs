using System;
using API.Data;
using RestSharp;
using TestQA_Exness.Tests;

namespace API.Tests
{
    public class ApiVendorTestsFixture : IDisposable
    {
        readonly TestVendorProvider _testVendorProvider;
        public ApiVendorTestsFixture()
        {
            _testVendorProvider = new TestVendorProvider();

            InsertTestVendor(_testVendorProvider.Vendor1);
        }

        public void Dispose()
        {
            DeleteTestVendor(_testVendorProvider.Vendor1.Id);
            DeleteTestVendor(_testVendorProvider.Vendor3.Id);
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