using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    //private static readonly string[] Summaries = new[]
    //{
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    // private readonly ILogger<UsersController> _logger;

    //public UsersController(ILogger<UsersController> logger)
    //{
    //    _logger = logger;
    //}
    private readonly IUsersService _userService;
    public UsersController(IUsersService usersService)
    {
        _userService = usersService;
    }

    [HttpGet(Name = "GetUsers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAllUsers();

        if (users.Any())
        {
            return Ok(users);
        }
        return NotFound();
    }
}
