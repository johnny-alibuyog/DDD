namespace DDD.Service.Models
{
    public class Email : Contact
    {
        public virtual string Address { get; set; }

        public Email() { }

        public Email(string address)
        {
            this.Address = address;
        }
    }
}
