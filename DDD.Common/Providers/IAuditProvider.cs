namespace DDD.Common.Providers
{
    public interface IAuditProvider
    {
        object GetCurrentUserId();
    }
}
