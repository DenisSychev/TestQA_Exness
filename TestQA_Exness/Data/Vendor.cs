using System;
using System.Collections.Generic;

namespace API.Data

{
    public class Vendor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public List<Category> Categories { get; set; }
    }
}