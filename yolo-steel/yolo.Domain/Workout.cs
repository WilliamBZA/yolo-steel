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

        public Workout(string name)
        {
            _exercises = new List<Exercise>();
            ProcessEvent(new WorkoutCreatedEvent(name));
        }

        public void AddExercise(string name, int reps, decimal prescribedWeight)
        {
            ProcessEvent(new ExerciseAddedEvent(name, reps, prescribedWeight));
        }

        public void Apply(WorkoutCreatedEvent workoutCreatedEvent)
        {
            _name = workoutCreatedEvent.Name;
        }

        public void Apply(ExerciseAddedEvent exerciseAddedEvent)
        {
            _exercises.Add(new Exercise(exerciseAddedEvent.Name, exerciseAddedEvent.Reps, exerciseAddedEvent.PrescribedWeight));
        }
    }
}