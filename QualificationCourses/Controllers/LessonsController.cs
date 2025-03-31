using Microsoft.AspNetCore.Mvc;
using QualificationCourses.Models;
using QualificationCourses;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly AppDbContext _context;
    public LessonsController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult Get() => Ok(_context.Lessons);

    [HttpPost]
    public IActionResult Post(Lesson lesson)
    {
        if (HttpContext.Items["Role"]?.ToString() != "admin")
            return Unauthorized("Only admin can add lessons");

        _context.Lessons.Add(lesson);
        _context.SaveChanges();
        return Ok(lesson);
    }
}