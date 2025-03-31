using QualificationCourses.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string Department { get; set; }

    // Навігаційна властивість (1 до багатьох)
    public List<Student> Students { get; set; } = new();
}
