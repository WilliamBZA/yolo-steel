using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.Domain.Events
{
    public class ExerciseAddedEvent : IDomainEvent<Workout>
    {
        public readonly string Name;
        public readonly int Reps;
        public readonly decimal PrescribedWeight;

        public ExerciseAddedEvent(string name, int reps, decimal prescribedWeight)
        {
            Name = name;
            Reps = reps;
            PrescribedWeight = prescribedWeight;
        }
    }
}