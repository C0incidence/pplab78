using Microsoft.AspNetCore.Mvc;
using QualificationCourses.Models;
using QualificationCourses;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public PaymentsController(AppDbContext context) => _context = context;

    [HttpGet("teacher/{id}")]
    public IActionResult GetPayment(int id)
    {
        var role = HttpContext.Items["Role"]?.ToString();
        if (role != "accountant" && role != "admin")
            return Unauthorized("Only accountant or admin can access payments");

        var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null) return NotFound("Teacher not found");

        var lessons = _context.Lessons.Where(l => l.TeacherId == id).ToList();
        var total = lessons.Sum(l => l.RatePerHour * l.Hours);

        var payment = new Payment
        {
            TeacherId = id,
            Total = total,
            TeacherName = teacher.FullName
        };

        return Ok(payment);
    }
}