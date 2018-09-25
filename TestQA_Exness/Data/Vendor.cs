using System.Collections.Generic;

namespace API.Data

{
    public class Vendor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public List<Category> Categories { get; set; }
    }
}