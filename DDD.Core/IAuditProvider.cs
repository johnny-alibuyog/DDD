namespace DDD.Core
{
    public interface IAuditProvider
    {
        object GetCurrentUserId();
    }
}
