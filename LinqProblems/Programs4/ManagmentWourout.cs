namespace LinqProblems.Programs4
{
    public class ManagmentWourout
    {
        public static void Execute()
        {
             var exercises = new List<Exercise>
        {
            new Exercise { Id = 1, Name = "Push-ups", Category = "Upper Body", Equipment = "Bodyweight" },
            new Exercise { Id = 2, Name = "Squats", Category = "Lower Body", Equipment = "Bodyweight" },
            new Exercise { Id = 3, Name = "Plank", Category = "Core", Equipment = "Bodyweight" },
            new Exercise { Id = 4, Name = "Running", Category = "Cardio", Equipment = "Treadmill" },
            new Exercise { Id = 5, Name = "Dumbbell Curls", Category = "Upper Body", Equipment = "Dumbbell" },
            new Exercise { Id = 6, Name = "Lunges", Category = "Lower Body", Equipment = "Bodyweight" }
        };

        var workouts = new List<Workout>
        {
            new Workout { Id = 1, Type = "Strength", Date = DateTime.Now.AddDays(-3), 
                         Duration = 60, CaloriesBurned = 350, Notes = "Chest and arms" },
            new Workout { Id = 2, Type = "Cardio", Date = DateTime.Now.AddDays(-2), 
                         Duration = 30, CaloriesBurned = 250, Notes = "Morning run" },
            new Workout { Id = 3, Type = "Strength", Date = DateTime.Now.AddDays(-1), 
                         Duration = 45, CaloriesBurned = 280, Notes = "Leg day" },
            new Workout { Id = 4, Type = "Flexibility", Date = DateTime.Now, 
                         Duration = 20, CaloriesBurned = 100, Notes = "Yoga session" }
        };

        var exerciseRecords = new List<ExerciseRecord>
        {
            // Workout 1 records
            new ExerciseRecord { Id = 1, WorkoutId = 1, ExerciseId = 1, Sets = 3, Reps = 15, Weight = 0 },
            new ExerciseRecord { Id = 2, WorkoutId = 1, ExerciseId = 5, Sets = 3, Reps = 12, Weight = 12.5m },
            
            // Workout 2 records
            new ExerciseRecord { Id = 3, WorkoutId = 2, ExerciseId = 4, Sets = 1, Reps = 1, Weight = 0 }, // Running
            
            // Workout 3 records
            new ExerciseRecord { Id = 4, WorkoutId = 3, ExerciseId = 2, Sets = 4, Reps = 12, Weight = 0 },
            new ExerciseRecord { Id = 5, WorkoutId = 3, ExerciseId = 6, Sets = 3, Reps = 10, Weight = 0 }
        };

        var nutritionLogs = new List<Nutrition>
        {
            new Nutrition { Id = 1, MealType = "Breakfast", FoodItem = "Oatmeal with fruits", 
                          Calories = 350, Protein = 12, Carbs = 60, Fat = 6, Date = DateTime.Now.AddDays(-1) },
            new Nutrition { Id = 2, MealType = "Lunch", FoodItem = "Chicken salad", 
                          Calories = 450, Protein = 35, Carbs = 20, Fat = 25, Date = DateTime.Now.AddDays(-1) },
            new Nutrition { Id = 3, MealType = "Dinner", FoodItem = "Grilled fish with vegetables", 
                          Calories = 400, Protein = 30, Carbs = 25, Fat = 20, Date = DateTime.Now.AddDays(-1) },
            new Nutrition { Id = 4, MealType = "Breakfast", FoodItem = "Eggs and toast", 
                          Calories = 320, Protein = 20, Carbs = 25, Fat = 15, Date = DateTime.Now },
            new Nutrition { Id = 5, MealType = "Lunch", FoodItem = "Turkey sandwich", 
                          Calories = 380, Protein = 25, Carbs = 40, Fat = 12, Date = DateTime.Now }
        };

        var fitnessGoals = new List<FitnessGoal>
        {
            new FitnessGoal { Id = 1, Type = "Workout", Target = "3 workouts per week", 
                            StartDate = DateTime.Now.AddDays(-14), TargetDate = null, IsCompleted = true },
            new FitnessGoal { Id = 2, Type = "Weight", Target = "Lose 2kg", 
                            StartDate = DateTime.Now.AddDays(-7), TargetDate = DateTime.Now.AddDays(21), IsCompleted = false },
            new FitnessGoal { Id = 3, Type = "Nutrition", Target = "Eat 100g protein daily", 
                            StartDate = DateTime.Now.AddDays(-3), TargetDate = null, IsCompleted = false }
        };

         var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        var endOfWeek = startOfWeek.AddDays(7);
        
        var weeklyWorkouts = workouts
            .Where(w => w.Date >= startOfWeek && w.Date < endOfWeek)
            .OrderBy(w => w.Date)
            .Select(w => new
            {
                Day = w.Date.ToString("ddd"),
                w.Type,
                w.Duration,
                w.CaloriesBurned,
                w.Notes,
                Exercises = exerciseRecords
                    .Where(er => er.WorkoutId == w.Id)
                    .Select(er => new
                    {
                        Exercise = exercises.First(e => e.Id == er.ExerciseId).Name,
                        er.Sets,
                        er.Reps,
                        er.Weight
                    })
                    .ToList()
            })
            .ToList();

        Console.WriteLine("=== This Week's Workouts ===");
        foreach (var workout in weeklyWorkouts)
        {
            Console.WriteLine($"{workout.Day}: {workout.Type} workout");
            Console.WriteLine($"  Duration: {workout.Duration} min, Calories: {workout.CaloriesBurned}");
            Console.WriteLine($"  Notes: {workout.Notes}");
            
            if (workout.Exercises.Any())
            {
                Console.WriteLine("  Exercises:");
                foreach (var exercise in workout.Exercises)
                {
                    string weightInfo = exercise.Weight > 0 ? $", {exercise.Weight}kg" : "";
                    Console.WriteLine($"    - {exercise.Exercise}: {exercise.Sets}×{exercise.Reps}{weightInfo}");
                }
            }
        }

        var exerciseProgress = exerciseRecords
            .GroupBy(er => er.ExerciseId)
            .Select(g => new
            {
                Exercise = exercises.First(e => e.Id == g.Key).Name,
                Category = exercises.First(e => e.Id == g.Key).Category,
                Sessions = g.Select(er => er.WorkoutId).Distinct().Count(),
                MaxWeight = g.Max(er => er.Weight),
                AvgReps = Math.Round(g.Average(er => er.Reps), 1),
                TotalVolume = g.Sum(er => er.Sets * er.Reps * (double)er.Weight),
                LastPerformed = workouts
                    .Where(w => g.Any(er => er.WorkoutId == w.Id))
                    .Max(w => w.Date)
            })
            .OrderByDescending(ep => ep.Sessions)
            .ToList();

        Console.WriteLine("\n=== Exercise Progress ===");
        foreach (var progress in exerciseProgress)
        {
            Console.WriteLine($"{progress.Exercise} ({progress.Category}):");
            Console.WriteLine($"  Sessions: {progress.Sessions}");
            Console.WriteLine($"  Max Weight: {progress.MaxWeight}kg");
            Console.WriteLine($"  Average Reps: {progress.AvgReps}");
            Console.WriteLine($"  Last Performed: {progress.LastPerformed:MMM dd}");
        }

         var dailyNutrition = nutritionLogs
            .GroupBy(n => n.Date.Date)
            .Select(g => new
            {
                Date = g.Key,
                TotalCalories = g.Sum(n => n.Calories),
                TotalProtein = g.Sum(n => n.Protein),
                TotalCarbs = g.Sum(n => n.Carbs),
                TotalFat = g.Sum(n => n.Fat),
                MealCount = g.Count(),
                MostCaloricMeal = g.OrderByDescending(n => n.Calories).First().MealType
            })
            .OrderByDescending(d => d.Date)
            .Take(3)
            .ToList();

        Console.WriteLine("\n=== Daily Nutrition (Last 3 Days) ===");
        foreach (var day in dailyNutrition)
        {
            Console.WriteLine($"{day.Date:MMM dd}:");
            Console.WriteLine($"  Calories: {day.TotalCalories} kcal");
            Console.WriteLine($"  Protein: {day.TotalProtein}g, Carbs: {day.TotalCarbs}g, Fat: {day.TotalFat}g");
            Console.WriteLine($"  Meals: {day.MealCount}, Most Caloric: {day.MostCaloricMeal}");
        }

         var weeklyGoalsCheck = new List<(string Goal, bool IsMet, string Details)>
        {
            ("Workout 3 times", 
             workouts.Count(w => w.Date >= startOfWeek && w.Date < endOfWeek) >= 3,
             $"Workouts this week: {workouts.Count(w => w.Date >= startOfWeek && w.Date < endOfWeek)}/3"),
            
            ("Burn 1500 calories", 
             workouts.Where(w => w.Date >= startOfWeek && w.Date < endOfWeek).Sum(w => w.CaloriesBurned) >= 1500,
             $"Calories burned: {workouts.Where(w => w.Date >= startOfWeek && w.Date < endOfWeek).Sum(w => w.CaloriesBurned)}/1500"),
            
            ("Eat 500g protein", 
             nutritionLogs.Where(n => n.Date >= startOfWeek && n.Date < endOfWeek).Sum(n => n.Protein) >= 500,
             $"Protein consumed: {nutritionLogs.Where(n => n.Date >= startOfWeek && n.Date < endOfWeek).Sum(n => n.Protein)}/500g")
        };

        Console.WriteLine("\n=== Weekly Goals Check ===");
        foreach (var goal in weeklyGoalsCheck)
        {
            string status = goal.IsMet ? "✅" : "❌";
            Console.WriteLine($"{status} {goal.Goal}");
            Console.WriteLine($"  {goal.Details}");
        }

        var workoutBalance = workouts
            .Where(w => w.Date >= startOfWeek && w.Date < endOfWeek)
            .GroupBy(w => w.Type)
            .Select(g => new
            {
                Type = g.Key,
                TotalDuration = g.Sum(w => w.Duration),
                SessionCount = g.Count(),
                Percentage = Math.Round((double)g.Sum(w => w.Duration) / 
                                       workouts.Where(w => w.Date >= startOfWeek && w.Date < endOfWeek).Sum(w => w.Duration) * 100, 1)
            })
            .OrderByDescending(w => w.TotalDuration)
            .ToList();

        Console.WriteLine("\n=== Workout Type Balance (This Week) ===");
        foreach (var balance in workoutBalance)
        {
            Console.WriteLine($"{balance.Type}:");
            Console.WriteLine($"  Duration: {balance.TotalDuration} min ({balance.Percentage}%)");
            Console.WriteLine($"  Sessions: {balance.SessionCount}");
        }

        }
    }

    public class Workout
{
    public int Id { get; set; }
    public string Type { get; set; } // "Cardio", "Strength", "Flexibility"
    public DateTime Date { get; set; }
    public int Duration { get; set; } // in minutes
    public int CaloriesBurned { get; set; }
    public string Notes { get; set; }
}

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // "Upper Body", "Lower Body", "Core", "Cardio"
    public string Equipment { get; set; } // "Bodyweight", "Dumbbell", "Barbell", "Machine"
}

public class ExerciseRecord
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public decimal Weight { get; set; } // in kg
}

public class Nutrition
{
    public int Id { get; set; }
    public string MealType { get; set; } // "Breakfast", "Lunch", "Dinner", "Snack"
    public string FoodItem { get; set; }
    public int Calories { get; set; }
    public int Protein { get; set; } // in grams
    public int Carbs { get; set; } // in grams
    public int Fat { get; set; } // in grams
    public DateTime Date { get; set; }
}

public class FitnessGoal
{
    public int Id { get; set; }
    public string Type { get; set; } // "Weight", "Workout", "Nutrition"
    public string Target { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? TargetDate { get; set; }
    public bool IsCompleted { get; set; }
}
}