namespace DDD.Core.Models
{
    /// <summary>
    /// Reference http://www.uxmatters.com/mt/archives/2008/06/international-address-fields-in-web-forms.php
    /// </summary>
    public class Address : ValueObject<Address>
    {
        public virtual string AddressLine1 { get; private set; }

        public virtual string AddressLine2 { get; private set; }

        public virtual string City { get; private set; }

        public virtual string State { get; private set; }

        public virtual string Country { get; private set; }

        public virtual string PostalCode { get; private set; }

        public Address() { }

        public Address(string addressLine1 = null, string addressLine2 = null, string city = null, string state = null, string country = null, string postalCode = null)
        {
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.PostalCode = postalCode;
        }
    }
}
