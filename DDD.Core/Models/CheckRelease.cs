namespace DDD.Core.Models
{
    public class CheckRelease : Transaction
    {
        public virtual string CheckNumber { get; protected internal set; }
    }
}
