using System.Collections.Generic;
using API.Data;

namespace API.Tests
{
    public static class TestVendors
    {
        public static Vendor Vendor1 => new Vendor
        {
            Id = "00000000-0000-0000-0000-000000000001",
            Name = "Testing corp",
            Rating = 5,
            Categories = new List<Category>
            {
                TestVendorsCategory.Category1,
                TestVendorsCategory.Category2
            }
        };

        public static Vendor Vendor2 => new Vendor
        {
            Id = "00000000-0000-0000-0000-000000000002",
            Name = "Testing corp 2",
            Rating = 4
        };

        public static Vendor Vendor3 => new Vendor
        {
            Id = "00000000-0000-0000-0000-000000000003",
            Name = "Testing corp 3",
            Rating = 3,
            Categories = new List<Category>
            {
                TestVendorsCategory.Category3,
                TestVendorsCategory.Category4
            }
        };
    }
}