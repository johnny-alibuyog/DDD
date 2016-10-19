namespace DDD.Core.Models
{
    public class CheckDeposit : Transaction
    {
        public virtual string CheckNumber { get; protected internal set; }
    }
}
