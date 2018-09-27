using API.Data;

namespace API.Tests
{
    public class TestVendorCategoryProvider
    {
        public readonly Category Category1;
        public readonly Category Category2;
        public readonly Category Category3;
        public readonly Category Category4;

        public TestVendorCategoryProvider()
        {
            Category1 = new Category
            {
                Id = "20000000-0000-0000-0000-000000000001",
                Name = "Testing software"
            };

            Category2 = new Category
            {
                Id = "20000000-0000-0000-0000-000000000002",
                Name = "System utilities"
            };

            Category3 = new Category
            {
                Id = "20000000-0000-0000-0000-000000000003",
                Name = "Testing software 2"
            };

            Category4 = new Category
            {
                Id = "20000000-0000-0000-0000-000000000004",
                Name = "System utilities 2"
            };
        }
    }
}