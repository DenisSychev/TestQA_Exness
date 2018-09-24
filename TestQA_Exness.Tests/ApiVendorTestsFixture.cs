using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace TestQA_Exness.Tests
{
    public class ApiVendorTestsFixture : IDisposable
    {
        private readonly VendorsDbContext _vendorsDbContext;
       
        public void InsertTestVendor(Vendor vendor)
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest("/create", Method.POST);
            request.AddJsonBody(vendor);

            client.Execute<Vendor>(request);
        }

        public void DeleteTestVendor(string id)
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest($"delete/{id}", Method.DELETE);

            client.Execute<Vendor>(request);
        }

        public ApiVendorTestsFixture()
        {
            InsertTestVendor(TestVendors.Vendor1);
        }
        
        public void Dispose()
        {
            DeleteTestVendor(TestVendors.Vendor1.Id);
        }

    }
}