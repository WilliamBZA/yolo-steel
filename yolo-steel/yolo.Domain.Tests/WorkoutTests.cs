using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using yolo.Domain.Events;

namespace yolo.Domain.Tests
{
    public class WorkoutTests
    {
        [Fact]
        public void Creating_A_Workout_Results_In_An_WorkoutCreatedEvent_Being_Applied()
        {
            // Arrange

            // Act
            var workout = new Workout("Test workout");

            // Assert
            var changes = workout.GetStateChangeEvents();

            Assert.Equal(1, changes.Count(e => e.GetType() == typeof (WorkoutCreatedEvent)));
        }

        [Fact]
        public void Adding_An_Exercise_To_A_Workout_Results_In_An_ExerciseAddedEvent_Being_Applied()
        {
            // Arrange
            var workout = new Workout("Grace");

            // act
            workout.AddExercise("Clean & Jerk", 30, 60);

            // assert
            var changes = workout.GetStateChangeEvents();

            Assert.Equal(1, changes.Count(e => e.GetType() == typeof(ExerciseAddedEvent)));
        }

        [Fact]
        public void Replaying_A_WorkoutCreatedEvent_Sets_The_WorkoutName_Correctly()
        {
            // Arrange
            var events = new[] { new WorkoutCreatedEvent("Create my mofo workout please") };
            var workoutRoot = new Workout();

            // Act
            workoutRoot.ReplayFromEvents(events);

            // Assert
            // OMG, am I really forced to use reflection to test this? Surely there's another indicator that the state is valid without
            // exposing a public property on the aggregate?
            var field = workoutRoot.GetType().GetField("_name", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(workoutRoot) as string;
            Assert.Equal("Create my mofo workout please", field);
        }

        [Fact]
        public void Replaying_A_WorkoutCreatedEvent_And_ExerciseAddedEvent_Sets_The_WorkoutName_And_Exercises_Correctly()
        {
            // Arrange
            var events = new IDomainEvent<Workout> [] { 
                new WorkoutCreatedEvent("Create my mofo workout please"),
                new ExerciseAddedEvent("Skwaatz", 300, 0)
            };
            var workoutRoot = new Workout();

            // Act
            workoutRoot.ReplayFromEvents(events);

            // Assert
            // OMG, am I really forced to use reflection to test this? Surely there's another indicator that the state is valid without
            // exposing a public property on the aggregate?
            var exercises = workoutRoot.GetType().GetField("_exercises", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(workoutRoot) as List<Exercise>;
            Assert.Equal(1, exercises.Count);

            var instance = exercises.First();
            var exerciseName = instance.GetType().GetField("_name", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance) as string;
            var exerciseReps = (int)instance.GetType().GetField("_reps", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
            var exerciseWeight = (decimal)instance.GetType().GetField("_prescribedWeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);

            Assert.Equal("Skwaatz", exerciseName);
            Assert.Equal(300, exerciseReps);
            Assert.Equal(0, exerciseWeight);
        }
    }
}