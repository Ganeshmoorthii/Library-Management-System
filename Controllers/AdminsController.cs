using Library_Management_SYS.Data;
using Library_Management_SYS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AdminsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> getAdmins()
    {
        var admins = await _context.Admin.ToListAsync();
        return Ok(admins);
    }

    [HttpPost]
    public async Task<IActionResult> createAdmin([FromBody] Admin admin)
    {
        await _context.Admin.AddAsync(admin);
        await _context.SaveChangesAsync();
        return Ok("Admin Created Successfully");
    }

    [HttpPut]
    public async Task<IActionResult> updateAdmin([FromBody] Admin admin)
    {
        var updateAdmin = await _context.Admin.FindAsync(admin.AdminId);
        if (updateAdmin == null)
            return NotFound();

        updateAdmin.name = admin.name;
        updateAdmin.Email = admin.Email;
        updateAdmin.Password = admin.Password;

        await _context.SaveChangesAsync();
        return Ok("Admin Updated Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteAdmin(int id)
    {
        var admin = await _context.Admin.FindAsync(id);
        if (admin == null)
            return NotFound();

        _context.Admin.Remove(admin);
        await _context.SaveChangesAsync();
        return Ok("Admin Deleted Successfully");
    }
}
