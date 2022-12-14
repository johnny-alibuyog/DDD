namespace DDD.Service.Models
{
    public class Address
    {
        public virtual string AddressLine1 { get; set; }

        public virtual string AddressLine2 { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string Country { get; set; }

        public virtual string PostalCode { get; set; }
    }
}
