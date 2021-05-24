using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; } = new();
        public string ZipCode { get; set; }
        public List<ContactPerson> ContactPersons { get; set; } = new();
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}