﻿using DDD.Core.Services;
using DDD.Core.Services.Accounts;

namespace DDD.Core.Models
{
    public class SavingsAccount : Account, IAccept<SavingsAccountVisitor>
    {
        public virtual void Accept(SavingsAccountVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
