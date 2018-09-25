using API.Data;

namespace API.Tests
{
    public static class TestVendorsCategory
    {
        public static Category Category1 => new Category
        {
            Id = "10000000-0000-0000-0000-000000000001",
            Name = "Testing software",
            Id_vendor = TestVendors.Vendor1.Id
        };

        public static Category Category2 => new Category
        {
            Id = "10000000-0000-0000-0000-000000000002",
            Name = "System utilities",
            Id_vendor = TestVendors.Vendor1.Id
        };

        public static Category Category3 => new Category
        {
            Id = "10000000-0000-0000-0000-000000000003",
            Name = "Testing software 2",
            Id_vendor = TestVendors.Vendor3.Id
        };

        public static Category Category4 => new Category
        {
            Id = "10000000-0000-0000-0000-000000000004",
            Name = "System utilities 2",
            Id_vendor = TestVendors.Vendor3.Id
        };
    }
}