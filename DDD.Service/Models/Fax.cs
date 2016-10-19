namespace DDD.Service.Models
{
    public class Fax : Contact
    {
        public virtual string Number { get; set; }

        public Fax() { }

        public Fax(string number)
        {
            this.Number = number;
        }
    }
}
