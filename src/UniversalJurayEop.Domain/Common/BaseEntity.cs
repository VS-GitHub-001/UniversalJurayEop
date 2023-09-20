using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalJurayEop.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
    }
}
