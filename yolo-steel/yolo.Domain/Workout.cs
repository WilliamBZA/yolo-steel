using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.Domain.Events;

namespace yolo.Domain
{
    public class Workout : AggregateRoot<Workout>
    {
        private string _name;
        private List<Exercise> _exercises;

        // Parameterless constructor implies no domain logic. Merely instantiating up an object.
        public Workout()
        {
            _exercises = new List<Exercise>();
        }

        // Using this parameter implies a command to create a new workout. No concept of commands in framework yet, so implied is what we have for now
        public Workout(string name)
            : this()
        {
            ProcessEvent(new WorkoutCreatedEvent(name));
        }

        public void AddExercise(string name, int reps, decimal prescribedWeight)
        {
            ProcessEvent(new ExerciseAddedEvent(name, reps, prescribedWeight));
        }

        protected void Apply(WorkoutCreatedEvent workoutCreatedEvent)
        {
            _name = workoutCreatedEvent.Name;
        }

        protected void Apply(ExerciseAddedEvent exerciseAddedEvent)
        {
            _exercises.Add(new Exercise(exerciseAddedEvent.Name, exerciseAddedEvent.Reps, exerciseAddedEvent.PrescribedWeight));
        }
    }
}