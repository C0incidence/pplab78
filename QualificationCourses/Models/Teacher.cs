namespace QualificationCourses.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }
        public List<string> Subjects { get; set; } = new();
    }
}
