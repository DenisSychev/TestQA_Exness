using API.Data;

namespace TestQA_Exness.Tests
{
    public class TestVendorsCategory
    {
        public static Category Category1 => new Category
        {
            Id = "58bd2c46-6f8f-4474-9ba4-1038730e01d4",
            Name = "Testing software",
            Id_vendor = "587d6b11-1491-456a-8e5c-d28d99ffdded"
        };
        
        public static Category Category2 => new Category
        {
            Id = "1ef43957-05a1-4900-819e-a4d8646188d5",
            Name = "System utilities",
            Id_vendor = "587d6b11-1491-456a-8e5c-d28d99ffdded"
        };
        
        public static Category Category3 => new Category
        {
            Id = "00000000-0000-0000-0000-0000000001d4",
            Name = "Testing software 2",
            Id_vendor = "00000000-0000-0000-0000-000000000d11"
        };
        
        public static Category Category4 => new Category
        {
            Id = "00000000-0000-0000-000000000000008d5",
            Name = "System utilities 2",
            Id_vendor = "00000000-0000-0000-0000-000000000d11"
        };
}
}