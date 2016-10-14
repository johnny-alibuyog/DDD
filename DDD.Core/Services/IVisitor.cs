namespace DDD.Core.Services
{
    public interface IVisitor { }

    public interface IVisitor<T> : IVisitor
    {
        void Visit(T target);
    }

    //public interface IVisitor<TTarget, TResult> : IVisitor 
    //{
    //    TResult Visit(TTarget target);
    //}

    //public interface IReturn { }

    //public interface IReturn<T> : IReturn { }
}
