Yolo-Steel - Playground app
============================

App designed for me to play with some DDD concepts to see how it comes out.

Domain description
------------------
The domain for the test app is software for a Crossfit gym. The key areas for software used to run a gym are listed below along with the importance of the feature (can the gym live without it?) as well as the difficulty of implementing the feature.

| Feature       | Importance for gym | Implementation size  |
| ------------- |:-------------| :-----|
| Progress Tracking | L | L |
| Schedule Management | M | M  |
| Client Sign-up | S  | S |
| Public website | S | S |
| Blog | S | M |
| Accounting package | S | L |


### Progress Tracking
Each class consists of a number of exercises grouped together into a **Workout**.  Each workout contains a multiple exercises. An exercise consists of a movement, a weight and a number of reps for that exercise.

The exercises within a workout can be structured in a number of ways with different goals for each:

1. For time
  * Here the client has to complete all the exercises as fast as possible
  * The time taken to complete all the exercises in the workout is recorded
2. AMRAP
  * AMRAP stands for As Many Reps (or Rounds) As Possible
  * Here the client has a fixed time to complete as many cycles of the exercises as possible
  * The total number of rounds and reps within the last round is recorded.
3. EMOM
  * EMOM stands for Every Minute On the Minute
  * Every minute the client has to complete a set of exercises
  * The exercises could stay the same from minute to minute or they could change or cycle

For each of these workouts, every client could do a slightly different workout either using different weights, different number of reps, different number of sets or even completely different exercises.

Some of the workouts are known as **Named Workouts**. These named workouts are considered benchmarks which clients can use to track their progress over time. An example of a named workout is Cindy:

The use cases for tracking clients' progress can be found here [a relative link](wiki/Progress-Use-Cases)

> #### Cindy
> 20 Minute AMRAP:
> * 5 Pull-ups
> * 10 Push-ups
> * 15 Squats

At the end of the named workout, the client will have completed a number of rounds and some reps which contribute towards a partial round.  An example for Cindy would be that the client completed 15 full rounds, and 8 push-ups. This means that the client was able to complete 15 full rounds, 5 pull-ups and 8 push-ups.

### Schedule Management
There are a set number of classes with a max number of clients per class (hardcoded? Or how does ramsay decide on the number? based on females:males ratio?)

### Client Sign-up
This refers not to clients signing up to be able to track their progress, this is specifically the intake process of new members joining the gym. Not in the scope of this test application

### Public website
Not in the scope of this test application

### Blog
Not in the scope of this test application

### Accounting package
Not in the scope of this test application