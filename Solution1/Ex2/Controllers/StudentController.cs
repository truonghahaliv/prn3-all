using Microsoft.AspNetCore.Mvc;

namespace Ex2.Controllers;

[Route("api")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentDbContext _context;

    public StudentController(StudentDbContext context)
    {
        _context = context;
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateStudent([FromBody] Student student)
    {
        if (student == null)
            return BadRequest("Invalid data.");

        var existingStudent = await _context.Students.FindAsync(student.StudentID);
        if (existingStudent == null)
            return NotFound("Student not found.");

        existingStudent.StudentName = student.StudentName;
        await _context.SaveChangesAsync();

        return Ok(existingStudent);
    }
}