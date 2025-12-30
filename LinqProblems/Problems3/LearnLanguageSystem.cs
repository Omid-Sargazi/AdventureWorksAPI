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

        var newWordsToday = words
            .Where(w => w.AddedDate >= DateTime.Today.AddDays(-2))
            .OrderByDescending(w => w.AddedDate)
            .Select(w => new
            {
                w.ForeignWord,
                w.Translation,
                w.Language,
                w.Category,
                w.Difficulty,
                Added = (DateTime.Now - w.AddedDate).Days,
                Mastery = w.MasteryLevel > 0 ? $"{w.MasteryLevel}%" : "Not practiced"
            })
            .ToList();

        Console.WriteLine("=== New Words (Last 2 Days) ===");
        foreach (var word in newWordsToday)
        {
            string difficulty = new string('★', word.Difficulty) + new string('☆', 5 - word.Difficulty);
            Console.WriteLine($"{word.ForeignWord} = {word.Translation}");
            Console.WriteLine($"  Language: {word.Language}, Category: {word.Category}");
            Console.WriteLine($"  Difficulty: {difficulty}, Added {word.Added} days ago");
            Console.WriteLine($"  Mastery: {word.Mastery}");
        }

        // 2. کلمات نیازمند مرور (بر اساس Spaced Repetition)
        var wordsForReview = words
            .Select(w => new
            {
                Word = w,
                DaysSinceReview = w.LastReviewed.HasValue ? 
                    (DateTime.Now - w.LastReviewed.Value).Days : int.MaxValue,
                ReviewPriority = CalculateReviewPriority(w)
            })
            .Where(x => x.ReviewPriority >= 3) // اولویت ۳ یا بالاتر
            .OrderByDescending(x => x.ReviewPriority)
            .ThenBy(x => x.DaysSinceReview)
            .Select(x => new
            {
                x.Word.ForeignWord,
                x.Word.Translation,
                x.Word.MasteryLevel,
                LastReview = x.Word.LastReviewed?.ToString("MMM dd") ?? "Never",
                x.Word.ReviewCount,
                Priority = x.ReviewPriority switch
                {
                    >= 5 => "🚨 HIGH",
                    >= 4 => "⚠️ MEDIUM",
                    _ => "📝 LOW"
                }
            })
            .Take(5) // فقط ۵ کلمه اول
            .ToList();

        Console.WriteLine("\n=== Words Needing Review ===");
        foreach (var word in wordsForReview)
        {
            Console.WriteLine($"{word.Priority} {word.ForeignWord} = {word.Translation}");
            Console.WriteLine($"  Mastery: {word.MasteryLevel}%, Reviews: {word.ReviewCount}");
            Console.WriteLine($"  Last reviewed: {word.LastReview}");
        }

          var lessonProgress = lessons
            .Select(l => new
            {
                l.Title,
                l.Language,
                l.Progress,
                Status = l.CompletedDate.HasValue ? "✅ Completed" : "📚 In Progress",
                DaysActive = (DateTime.Now - l.StartDate).Days,
                EstimatedCompletion = l.CompletedDate?.ToString("MMM dd") ?? 
                    (l.Progress > 0 ? $"~{DateTime.Now.AddDays((100 - l.Progress) / 5).ToString("MMM dd")}" : "Unknown")
            })
            .OrderByDescending(l => l.Progress)
            .ToList();

        Console.WriteLine("\n=== Lesson Progress ===");
        foreach (var lesson in lessonProgress)
        {
            string progressBar = GenerateProgressBar(lesson.Progress);
            Console.WriteLine($"{lesson.Title} ({lesson.Language})");
            Console.WriteLine($"  {progressBar} {lesson.Progress}%");
            Console.WriteLine($"  Status: {lesson.Status}, Active for {lesson.DaysActive} days");
            if (!lesson.Status.Contains("Completed"))
                Console.WriteLine($"  Estimated completion: {lesson.EstimatedCompletion}");
        }

        var weeklyPractice = practiceSessions
            .Where(p => p.SessionDate >= DateTime.Now.AddDays(-7))
            .GroupBy(p => p.SessionDate.Date)
            .Select(g => new
            {
                Date = g.Key,
                TotalMinutes = g.Sum(p => p.Duration),
                TotalSessions = g.Count(),
                TotalWords = g.Sum(p => p.WordsPracticed),
                Accuracy = Math.Round((double)g.Sum(p => p.CorrectAnswers) / g.Sum(p => p.WordsPracticed) * 100, 1)
            })
            .OrderByDescending(d => d.Date)
            .ToList();

        Console.WriteLine("\n=== Weekly Practice Summary ===");
        foreach (var day in weeklyPractice)
        {
            Console.WriteLine($"{day.Date:ddd, MMM dd}:");
            Console.WriteLine($"  Sessions: {day.TotalSessions}, Time: {day.TotalMinutes} min");
            Console.WriteLine($"  Words practiced: {day.TotalWords}, Accuracy: {day.Accuracy}%");
        }

         var difficultWords = words
            .Select(w => new
            {
                Word = w,
                Reviews = wordReviews.Where(wr => wr.WordId == w.Id).ToList()
            })
            .Where(x => x.Reviews.Any())
            .Select(x => new
            {
                x.Word.ForeignWord,
                x.Word.Translation,
                TotalReviews = x.Reviews.Count,
                CorrectReviews = x.Reviews.Count(r => r.WasCorrect),
                SuccessRate = Math.Round((double)x.Reviews.Count(r => r.WasCorrect) / x.Reviews.Count * 100, 1),
                LastAttempt = x.Reviews.Max(r => r.ReviewDate),
                CommonMistake = x.Reviews
                    .Where(r => !r.WasCorrect && !string.IsNullOrEmpty(r.Notes))
                    .Select(r => r.Notes)
                    .FirstOrDefault() ?? "No notes"
            })
            .Where(x => x.SuccessRate < 70) // کمتر از ۷۰٪ موفقیت
            .OrderBy(x => x.SuccessRate)
            .Take(3)
            .ToList();

        Console.WriteLine("\n=== Difficult Words (Needs Focus) ===");
        foreach (var word in difficultWords)
        {
            Console.WriteLine($"{word.ForeignWord} = {word.Translation}");
            Console.WriteLine($"  Success Rate: {word.SuccessRate}% ({word.CorrectReviews}/{word.TotalReviews})");
            Console.WriteLine($"  Last attempted: {word.LastAttempt:MMM dd}");
            Console.WriteLine($"  Note: {word.CommonMistake}");
        }

var practiceByType = practiceSessions
            .GroupBy(p => p.PracticeType)
            .Select(g => new
            {
                Type = g.Key,
                TotalSessions = g.Count(),
                TotalMinutes = g.Sum(p => p.Duration),
                AverageAccuracy = Math.Round(g.Average(p => (double)p.CorrectAnswers / p.WordsPracticed * 100), 1),
                FavoriteTime = g.GroupBy(p => p.SessionDate.Hour)
                               .OrderByDescending(hg => hg.Count())
                               .First()
                               .Key
            })
            .OrderByDescending(p => p.TotalMinutes)
            .ToList();

        Console.WriteLine("\n=== Practice by Type ===");
        foreach (var practice in practiceByType)
        {
            Console.WriteLine($"{practice.Type}:");
            Console.WriteLine($"  Sessions: {practice.TotalSessions}, Time: {practice.TotalMinutes} min");
            Console.WriteLine($"  Average Accuracy: {practice.AverageAccuracy}%");
            Console.WriteLine($"  Most common time: {practice.FavoriteTime}:00");
        }
 var wordsByCategory = words
            .GroupBy(w => w.Category)
            .Select(g => new
            {
                Category = g.Key,
                WordCount = g.Count(),
                AverageMastery = Math.Round(g.Average(w => w.MasteryLevel), 1),
                MostDifficult = g.OrderByDescending(w => w.Difficulty).First().ForeignWord,
                NewestWord = g.OrderByDescending(w => w.AddedDate).First().ForeignWord
            })
            .OrderByDescending(c => c.WordCount)
            .ToList();

        Console.WriteLine("\n=== Words by Category ===");
        foreach (var category in wordsByCategory)
        {
            Console.WriteLine($"{category.Category}:");
            Console.WriteLine($"  Words: {category.WordCount}, Avg Mastery: {category.AverageMastery}%");
            Console.WriteLine($"  Hardest: {category.MostDifficult}, Newest: {category.NewestWord}");
        }

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