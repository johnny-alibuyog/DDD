namespace DDD.Common.Pipes
{
    public class Pipeline<T> : IPipeline<T>
    {
        private IStep<T> _root;

        public T Execute(T input)
        {
            return _root.Execute(input);
        }

        public IPipeline<T> Register(IStep<T> filter)
        {
            if (_root == null)
                _root = filter;

            else
                _root.Register(filter);

            return this;
        }
    }
}
