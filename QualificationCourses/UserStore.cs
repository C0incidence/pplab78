namespace QualificationCourses
{
    public class UserStore
    {
        public List<string> ValidRoles { get; } = new() { "admin", "teacher", "accountant" };
    }
}
