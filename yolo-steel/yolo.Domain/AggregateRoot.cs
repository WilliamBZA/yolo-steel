using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.Domain
{
    public abstract class AggregateRoot
    {
        protected void ProcessEvent<T>(IDomainEvent<T> domainEvent) where T : class
        {
            domainEvent.ApplyEventTo(this as T);
            PersistEvent(domainEvent);
        }

        protected void ReplayEvent<T>(IDomainEvent<T> domainEvent) where T : class
        {
            domainEvent.ApplyEventTo(this as T);
        }

        private void PersistEvent<T>(IDomainEvent<T> domainEvent)
        {
            // blah blah, save event somewhere
        }
    }
}