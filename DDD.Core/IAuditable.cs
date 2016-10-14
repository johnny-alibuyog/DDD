using DDD.Core.Models;
using System;

namespace DDD.Core
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }

        User CreatedBy { get; set; }

        DateTime? ModifiedOn { get; set; }

        User ModifiedBy { get; set; }
    }
}
