namespace DDD.Service.Models
{
    public class Mobile : Contact
    {
        public virtual string Number { get; set; }

        public Mobile() { }

        public Mobile(string number)
        {
            this.Number = number;
        }
    }
}
