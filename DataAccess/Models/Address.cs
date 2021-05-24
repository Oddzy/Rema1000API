namespace DataAccess.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Supplier Supplier { get; set; }
    }
}