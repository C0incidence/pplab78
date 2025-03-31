using Microsoft.AspNetCore.Mvc;
using QualificationCourses.Models;
using QualificationCourses;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly AppDbContext _context;
    public TeachersController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult Get() => Ok(_context.Teachers);

    [HttpPost]
    public IActionResult Post(Teacher teacher)
    {
        if (HttpContext.Items["Role"]?.ToString() != "admin")
            return Unauthorized("Only admin can add teachers");

        _context.Teachers.Add(teacher);
        _context.SaveChanges();
        return Ok(teacher);
    }
}