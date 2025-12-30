namespace LinqProblems.Problems3
{
    public class LearnLanguageSystem
    {
        public static void Execute()
        {
            
        }
    }

    public class Word
{
    public int Id { get; set; }
    public string ForeignWord { get; set; } // کلمه خارجی
    public string Translation { get; set; } // ترجمه
    public string Language { get; set; } // "English", "Spanish", "French"
    public string Category { get; set; } // "Food", "Travel", "Business", "Everyday"
    public int Difficulty { get; set; } // 1-5 (5 is hardest)
    public DateTime AddedDate { get; set; }
    public DateTime? LastReviewed { get; set; }
    public int ReviewCount { get; set; }
    public double MasteryLevel { get; set; } // 0-100
}

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public int WordCount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public double Progress { get; set; } // 0-100
}

public class PracticeSession
{
    public int Id { get; set; }
    public DateTime SessionDate { get; set; }
    public int Duration { get; set; } // in minutes
    public int WordsPracticed { get; set; }
    public int CorrectAnswers { get; set; }
    public string PracticeType { get; set; } // "Flashcards", "Writing", "Listening"
}

public class WordReview
{
    public int Id { get; set; }
    public int WordId { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool WasCorrect { get; set; }
    public string Notes { get; set; }
}
}