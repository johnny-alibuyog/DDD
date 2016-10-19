namespace DDD.Core.Services
{
    public interface IAccept<T> where T : IVisitor
    {
        void Accept(T visitor);
    }

    //public interface IReturn { }

    //public interface IReturn<T> : IReturn { }
}
