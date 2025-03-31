namespace QualificationCourses.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public int GroupId { get; set; } // Foreign Key
        public Group Group { get; set; } // Навігаційне посилання
    }
}
