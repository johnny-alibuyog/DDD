using DDD.Core.Services;
using DDD.Core.Services.Accounts;

namespace DDD.Core.Models
{
    public class CurrentAccount : Account, IAccept<CurrentAccountVisitor>
    {
        public virtual void Accept(CurrentAccountVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
