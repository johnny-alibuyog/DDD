namespace DDD.Common.Pipes
{
    public interface IPipeline<T>
    {
        T Execute(T input);
        IPipeline<T> Register(IStep<T> filter);
    }
}
