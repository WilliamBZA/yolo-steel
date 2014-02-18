using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.Domain
{
    public class Workout : AggregateRoot
    {
        private string _name;

        public Workout(string name, DateTime workoutDate)
        {
            ProcessEvent(new WorkoutCreatedEvent(name));
        }

        public void AddExercise(string name, int reps, decimal prescribedWeight)
        {
            // what do?
        }

        internal void Apply(WorkoutCreatedEvent workoutCreatedEvent)
        {
            _name = workoutCreatedEvent.Name;
        }
    }
}