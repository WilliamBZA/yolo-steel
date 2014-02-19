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
    }
}