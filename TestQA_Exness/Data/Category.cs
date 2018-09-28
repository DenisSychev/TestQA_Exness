using System;

namespace API.Data
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid VendorId { get; set; }
    }
}