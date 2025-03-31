namespace QualificationCourses.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public decimal Total { get; set; }
        public string TeacherName { get; set; } = string.Empty;
    }
}
