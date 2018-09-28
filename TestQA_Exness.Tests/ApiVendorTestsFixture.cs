using System;
using System.Net;
using API.Data;
using RestSharp;
using TestQA_Exness.Tests;

namespace API.Tests
{
    public class ApiVendorTestsFixture : IDisposable
    {
        private readonly TestVendorProvider _testVendorProvider;

        public ApiVendorTestsFixture()
        {
            _testVendorProvider = new TestVendorProvider();

            DeleteTestVendor(_testVendorProvider.Vendor1.Id);
            DeleteTestVendor(_testVendorProvider.Vendor2.Id);
            DeleteTestVendor(_testVendorProvider.Vendor3.Id);
            DeleteTestVendor(_testVendorProvider.NewVendor.Id);

            InsertTestVendor(_testVendorProvider.Vendor1);
            InsertTestVendor(_testVendorProvider.Vendor2);
            InsertTestVendor(_testVendorProvider.Vendor3);
        }

        public void Dispose()
        {
            DeleteTestVendor(_testVendorProvider.Vendor1.Id);
            DeleteTestVendor(_testVendorProvider.Vendor2.Id);
            DeleteTestVendor(_testVendorProvider.Vendor3.Id);
            DeleteTestVendor(_testVendorProvider.NewVendor.Id);
        }

        private void InsertTestVendor(Vendor vendor)
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest(ApiRequestMethods.CreateVendorRequest, Method.POST);
            request.AddJsonBody(vendor);

            var restResponse = client.Execute<Vendor>(request);
            if (!restResponse.IsSuccessful)
            {
                throw new Exception("Ошибка при добавлении тестовых данных", restResponse.ErrorException);
            }
        }

        private void DeleteTestVendor(Guid id)
        {
            var client = new RestClient(TestConstants.BaseApiUrl);

            var request = new RestRequest(ApiRequestMethods.DeleteVendorRequest, Method.DELETE);
            request.AddParameter("id", id, ParameterType.GetOrPost);

            var restResponse = client.Execute<Vendor>(request);
            if (restResponse.StatusCode != HttpStatusCode.NoContent &&
                restResponse.StatusCode != HttpStatusCode.NotFound)
            {
                throw new Exception("Ошибка при добавлении тестовых данных", restResponse.ErrorException);
            }
        }
    }
}