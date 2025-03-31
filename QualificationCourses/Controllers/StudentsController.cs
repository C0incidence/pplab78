using Microsoft.AspNetCore.Mvc;
using QualificationCourses.Models;
using QualificationCourses;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public StudentsController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult Get() => Ok(_context.Students.ToList());

    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        var role = HttpContext.Items["Role"]?.ToString();
        if (role != "admin")
            return Unauthorized("Only admin can add students");

        _context.Students.Add(student);
        _context.SaveChanges();
        return Ok(student);
    }
}
