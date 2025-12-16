using Library_Management_SYS.Data;
using Library_Management_SYS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> getStudents()
    {
        var students = await _context.Student.ToListAsync();
        return Ok(students);
    }

    [HttpPost]
    public async Task<IActionResult> createStudent([FromBody] Student student)
    {
        await _context.Student.AddAsync(student);
        await _context.SaveChangesAsync();
        return Ok("Student Created Successfully");
    }

    [HttpPut]
    public async Task<IActionResult> updateStudent([FromBody] Student student)
    {
        var updateStudent = await _context.Student.FindAsync(student.StudentId);
        if (updateStudent == null)
            return NotFound();

        updateStudent.name = student.name;
        updateStudent.Email = student.Email;

        await _context.SaveChangesAsync();
        return Ok("Student Updated Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteStudent(int id)
    {
        var student = await _context.Student.FindAsync(id);
        if (student == null)
            return NotFound();

        _context.Student.Remove(student);
        await _context.SaveChangesAsync();
        return Ok("Student Deleted Successfully");
    }
}
