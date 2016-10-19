using DDD.Core.Models;

namespace DDD.Core.Services.Customers
{
    public abstract class CustomerVisitor : IVisitor<Customer>
    {
        public abstract void Visit(Customer target);
    }
}
