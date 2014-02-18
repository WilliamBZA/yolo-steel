using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yolo.Domain
{
    public interface IDomainEvent<T>
    {
        void ApplyEventTo(T instance);
    }
}