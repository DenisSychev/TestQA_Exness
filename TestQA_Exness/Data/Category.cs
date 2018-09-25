namespace API.Data
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Id_vendor { get; set; }
        
        public Vendor Vendor { get; set; }
    }
}