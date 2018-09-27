using System.Collections.Generic;
using API.Data;

namespace API.Tests
{
    public class TestVendorProvider
    {
        public readonly Vendor Vendor1;
        public readonly Vendor Vendor2;
        public readonly Vendor Vendor3;
        public readonly Vendor Vendor4;

        public TestVendorProvider()
        {
            var categoryProvider = new TestVendorCategoryProvider();

            Vendor1 = new Vendor
            {
                Id = "00000000-0000-0000-0000-000000000011",
                Name = "Testing corp",
                Rating = 5
            };
            Vendor1.Categories = new List<Category>
            {
                new Category()
                {
                    Id = categoryProvider.Category1.Id,
                    Name = categoryProvider.Category1.Name,
                    //Vendor = Vendor1,
                    VendorId = Vendor1.Id
                },
                new Category()
                {
                    Id = categoryProvider.Category2.Id,
                    Name = categoryProvider.Category2.Name,
                    //Vendor = Vendor1,
                    VendorId = Vendor1.Id
                }
            };

            Vendor2 = new Vendor
            {
                Id = "00000000-0000-0000-0000-000000000002",
                Name = "Testing corp 2",
                Rating = 4
            };

            Vendor3 = new Vendor
            {
                Id = "00000000-0000-0000-0000-000000000003",
                Name = "Testing corp 3",
                Rating = 3,
                Categories = new List<Category>
                {
                    categoryProvider.Category3,
                    categoryProvider.Category4
                }
            };
            
            Vendor4 = new Vendor
            {
                Id = "00000000-0000-0000-0000-0000000000044",
                Name = "Testing corp 4",
                Rating = 0
            };
        }
    }
}