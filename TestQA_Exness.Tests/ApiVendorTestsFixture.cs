using System;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace TestQA_Exness.Tests
{
    public class ApiVendorTestsFixture : IDisposable
    {
        private readonly VendorsDbContext _vendorsDbContext;
        
        public ApiVendorTestsFixture()
        {
            Prop = "New prop";
            
            var options = new DbContextOptions<VendorsDbContext>();
            _vendorsDbContext = new VendorsDbContext(options);
            
            const string id = "587d6b11-1491-456a-8e5c-d28d99ffdd33";
            const string name = "Testing corp";
            const int rating = 5;
        }
        
        public void Dispose()
        {
            
        }


        public readonly string Prop;
    }
}