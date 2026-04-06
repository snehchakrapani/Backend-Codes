using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDashboardApi.Data;
using TaskDashboardApi.Models;

namespace TaskDashboardApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUp(SignUpRequest model)
    {
        if (string.IsNullOrWhiteSpace(model.Name) ||
            string.IsNullOrWhiteSpace(model.Email) ||
            string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest(new { message = "Name, email, and password are required." });
        }

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

        if (user != null)
        {
            return Conflict(new { message = "An account with this email already exists." });
        }

        user = new AppUser
        {
            Name = model.Name,
            Email = model.Email,
            Password = model.Password
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            user.Id,
            user.Name,
            user.Email
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest model)
    {
        if (string.IsNullOrWhiteSpace(model.Email) ||
            string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest(new { message = "Email and password are required." });
        }

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

        if (user == null)
        {
            return NotFound(new { message = "Account not found. Please sign up first." });
        }

        if (user.Password != model.Password)
        {
            return Unauthorized(new { message = "Incorrect password." });
        }

        return Ok(new
        {
            user.Id,
            user.Name,
            user.Email
        });
    }
}

public class SignUpRequest
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public class LoginRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}
