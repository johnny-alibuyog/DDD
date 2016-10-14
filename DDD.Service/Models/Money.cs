namespace DDD.Service.Models
{
    public class Money
    {
        public virtual decimal Amount { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
