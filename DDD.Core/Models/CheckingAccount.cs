using DDD.Core.Services;
using DDD.Core.Services.Accounts;

namespace DDD.Core.Models
{
    public class CheckingAccount : Account, IAccept<CheckingAccountVisitor>
    {
        public virtual void Accept(CheckingAccountVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
