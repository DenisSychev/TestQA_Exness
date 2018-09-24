using API.Data;

namespace TestQA_Exness.Tests
{
    public class TestVendors
    {
        public static Vendor Vendor1 => new Vendor
        {
            Id = "587d6b11-1491-456a-8e5c-d28d99ffdded",
            Name = "Testing corp",
            Rating = 5,
            categories = new Category[]{
                TestVendorsCategory.Category1,
                TestVendorsCategory.Category2
            }

        };

        public static Vendor Vendor2 => new Vendor
        {
            Id = "587d6b11-1491-456a-8e5c-d28d99ffdd00",
            Name = "Testing corp 2",
            Rating = 4
        };

        public static Vendor Vendor3 => new Vendor
        {
            Id = "00000000-0000-0000-0000-000000000d11",
            Name = "Testing corp 3",
            Rating = 3,
            categories = new Category[]
            {
                TestVendorsCategory.Category3,
                TestVendorsCategory.Category4
            }
        };
    }
}
