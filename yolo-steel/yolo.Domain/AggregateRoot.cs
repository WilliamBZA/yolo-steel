using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.Domain.Events;

namespace yolo.Domain
{
    public abstract class AggregateRoot<T>
    {
        private IList<IDomainEvent<T>> _stateChanges;

        public AggregateRoot()
        {
            _stateChanges = new List<IDomainEvent<T>>();
        }

        protected void ProcessEvent(IDomainEvent<T> domainEvent)
        {
            Apply(domainEvent);
            _stateChanges.Add(domainEvent);
        }

        protected void ReplayEvent(IDomainEvent<T> domainEvent)
        {
            Apply(domainEvent);
        }

        public void Apply(IDomainEvent<T> domainEvent)
        {
            // Not entirely happy with the magic string for Apply, but I don't see it as too much of an evil...
            GetType().InvokeMember("Apply", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, this, new[] { domainEvent });
        }

        public IEnumerable<IDomainEvent<T>> GetStateChangeEvents()
        {
            return _stateChanges;
        }

        public void ReplayFromEvents(IEnumerable<IDomainEvent<T>> events)
        {
            foreach (var e in events)
            {
                ReplayEvent(e);
            }
        }
    }
}