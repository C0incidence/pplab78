namespace QualificationCourses.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; } // Лекція або практика
        public int Hours { get; set; }
        public int TeacherId { get; set; }
        public string Group { get; set; }
        public decimal RatePerHour { get; set; }
    }
}
