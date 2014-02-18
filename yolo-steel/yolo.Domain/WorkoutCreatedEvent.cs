using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yolo.Domain
{
    public class WorkoutCreatedEvent : IDomainEvent<Workout>
    {
        public readonly string Name;

        public WorkoutCreatedEvent(string name)
        {
            Name = name;
        }

        public void ApplyEventTo(Workout instance)
        {
            instance.Apply(this);

        }
    }
}