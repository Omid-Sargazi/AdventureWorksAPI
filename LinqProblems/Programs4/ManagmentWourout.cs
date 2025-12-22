namespace LinqProblems.Programs4
{
    public class ManagmentWourout
    {
        public static void Execute()
        {
            
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