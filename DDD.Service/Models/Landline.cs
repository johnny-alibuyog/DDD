namespace DDD.Service.Models
{
    public class Landline : Contact
    {
        public virtual string Number { get; set; }

        public Landline() { }

        public Landline(string number)
        {
            this.Number = number;
        }
    }
}
