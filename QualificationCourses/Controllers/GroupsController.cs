using Microsoft.AspNetCore.Mvc;
using QualificationCourses;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly AppDbContext _context;
    public GroupsController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult Get() => Ok(_context.Groups);

    [HttpPost]
    public IActionResult Post(Group group)
    {
        if (HttpContext.Items["Role"]?.ToString() != "admin")
            return Unauthorized("Only admin can add groups");

        _context.Groups.Add(group);
        _context.SaveChanges();
        return Ok(group);
    }
}