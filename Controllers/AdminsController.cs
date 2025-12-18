using Library_Management_SYS.Application.Interfaces;
using Library_Management_SYS.Entities;
using Library_Management_SYS.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AdminsController : ControllerBase
{
    private readonly IRepositoryWrapper _repository;
    public AdminsController(IRepositoryWrapper repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> getAdmins()
    {
        var admins = await _repository.AdminService.GetAllAdminsAsync();
        return Ok(admins);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> getAdminById(int id)
    {
        var admin = await _repository.AdminService.GetAdminByIdAsync(id);
        if (admin == null)
            return NotFound();
        return Ok(admin);
    }
    [HttpPut]
    public async Task<IActionResult> createAdmin([FromBody] Admin admin)
    {
        _repository.AdminService.CreateAdminAsync(admin);
        await _repository.SaveAsync();
        return Ok("Admin Created Successfully");
    }
    [HttpPost]
    public async Task<IActionResult> updateAdmin([FromBody] Admin admin)
    {
        _repository.AdminService.UpdateAdminAsync(admin);
        await _repository.SaveAsync();
        return Ok("Admin Updated Successfully");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteAdmin(int id)
    {
        _repository.AdminService.DeleteAdminAsync(id);
        await _repository.SaveAsync();
        return Ok("Admin Deleted Successfully");
    }
}
