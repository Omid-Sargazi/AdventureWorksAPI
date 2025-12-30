namespace LinqProblems.Problems3
{
    public class LearnLanguageSystem
    {
        public static void Execute()
        {
             var words = new List<Word>
        {
            new Word { Id = 1, ForeignWord = "Hello", Translation = "سلام", 
                      Language = "English", Category = "Greetings", Difficulty = 1, 
                      AddedDate = DateTime.Now.AddDays(-10), LastReviewed = DateTime.Now.AddDays(-1), 
                      ReviewCount = 5, MasteryLevel = 90 },
            
            new Word { Id = 2, ForeignWord = "Thank you", Translation = "متشکرم", 
                      Language = "English", Category = "Greetings", Difficulty = 1, 
                      AddedDate = DateTime.Now.AddDays(-9), LastReviewed = DateTime.Now.AddDays(-2), 
                      ReviewCount = 4, MasteryLevel = 85 },
            
            new Word { Id = 3, ForeignWord = "Restaurant", Translation = "رستوران", 
                      Language = "English", Category = "Food", Difficulty = 2, 
                      AddedDate = DateTime.Now.AddDays(-8), LastReviewed = DateTime.Now.AddDays(-3), 
                      ReviewCount = 3, MasteryLevel = 70 },
            
            new Word { Id = 4, ForeignWord = "Airport", Translation = "فرودگاه", 
                      Language = "English", Category = "Travel", Difficulty = 3, 
                      AddedDate = DateTime.Now.AddDays(-7), LastReviewed = DateTime.Now.AddDays(-4), 
                      ReviewCount = 2, MasteryLevel = 60 },
            
            new Word { Id = 5, ForeignWord = "Meeting", Translation = "جلسه", 
                      Language = "English", Category = "Business", Difficulty = 4, 
                      AddedDate = DateTime.Now.AddDays(-6), LastReviewed = DateTime.Now.AddDays(-5), 
                      ReviewCount = 1, MasteryLevel = 40 },
            
            new Word { Id = 6, ForeignWord = "Beautiful", Translation = "زیبا", 
                      Language = "English", Category = "Adjectives", Difficulty = 2, 
                      AddedDate = DateTime.Now.AddDays(-5), LastReviewed = null, 
                      ReviewCount = 0, MasteryLevel = 0 },
            
            new Word { Id = 7, ForeignWord = "Hola", Translation = "سلام", 
                      Language = "Spanish", Category = "Greetings", Difficulty = 1, 
                      AddedDate = DateTime.Now.AddDays(-4), LastReviewed = DateTime.Now.AddDays(-1), 
                      ReviewCount = 3, MasteryLevel = 75 },
            
            new Word { Id = 8, ForeignWord = "Gracias", Translation = "متشکرم", 
                      Language = "Spanish", Category = "Greetings", Difficulty = 1, 
                      AddedDate = DateTime.Now.AddDays(-3), LastReviewed = DateTime.Now.AddDays(-2), 
                      ReviewCount = 2, MasteryLevel = 65 }
        };

        // درس‌ها
        var lessons = new List<Lesson>
        {
            new Lesson { Id = 1, Title = "Basic Greetings", Language = "English", 
                       WordCount = 5, StartDate = DateTime.Now.AddDays(-10), 
                       CompletedDate = DateTime.Now.AddDays(-5), Progress = 100 },
            
            new Lesson { Id = 2, Title = "Food Vocabulary", Language = "English", 
                       WordCount = 8, StartDate = DateTime.Now.AddDays(-8), 
                       CompletedDate = null, Progress = 60 },
            
            new Lesson { Id = 3, Title = "Spanish Basics", Language = "Spanish", 
                       WordCount = 10, StartDate = DateTime.Now.AddDays(-4), 
                       CompletedDate = null, Progress = 30 }
        };

        // جلسات تمرین
        var practiceSessions = new List<PracticeSession>
        {
            new PracticeSession { Id = 1, SessionDate = DateTime.Now.AddDays(-1), 
                                Duration = 20, WordsPracticed = 15, CorrectAnswers = 12, 
                                PracticeType = "Flashcards" },
            
            new PracticeSession { Id = 2, SessionDate = DateTime.Now.AddDays(-2), 
                                Duration = 15, WordsPracticed = 10, CorrectAnswers = 8, 
                                PracticeType = "Writing" },
            
            new PracticeSession { Id = 3, SessionDate = DateTime.Now.AddDays(-3), 
                                Duration = 25, WordsPracticed = 20, CorrectAnswers = 16, 
                                PracticeType = "Flashcards" },
            
            new PracticeSession { Id = 4, SessionDate = DateTime.Now.AddDays(-5), 
                                Duration = 30, WordsPracticed = 25, CorrectAnswers = 20, 
                                PracticeType = "Listening" }
        };

        // مرور کلمات
        var wordReviews = new List<WordReview>
        {
            new WordReview { Id = 1, WordId = 1, ReviewDate = DateTime.Now.AddDays(-1), 
                           WasCorrect = true, Notes = "Easy" },
            new WordReview { Id = 2, WordId = 1, ReviewDate = DateTime.Now.AddDays(-3), 
                           WasCorrect = true, Notes = "" },
            new WordReview { Id = 3, WordId = 2, ReviewDate = DateTime.Now.AddDays(-2), 
                           WasCorrect = true, Notes = "" },
            new WordReview { Id = 4, WordId = 3, ReviewDate = DateTime.Now.AddDays(-3), 
                           WasCorrect = false, Notes = "Confused with cafe" },
            new WordReview { Id = 5, WordId = 4, ReviewDate = DateTime.Now.AddDays(-4), 
                           WasCorrect = false, Notes = "Need more practice" },
            new WordReview { Id = 6, WordId = 5, ReviewDate = DateTime.Now.AddDays(-5), 
                           WasCorrect = true, Notes = "Got it!" },
            new WordReview { Id = 7, WordId = 7, ReviewDate = DateTime.Now.AddDays(-1), 
                           WasCorrect = true, Notes = "Spanish hello" }
        };
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