using CookieAuthenticationWithAngular.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookieAuthenticationWithAngular.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly List<User> users = new()
    {
        new("admin@gmail.com","tester", "123456", "admin"),
        new("string", "User 1", "string", "manager"),
        new("user2@test.com", "User 2", "user2", "user"),
    };
    public AuthController(ILogger<AuthController>logger)
    {
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> SignInAsync([FromBody] SignInRequest signInRequest)
    {
        var user = users.FirstOrDefault(x => x.Email == signInRequest.Email &&
                                            x.Password == signInRequest.Password);
        if (user is null)
        {
            return BadRequest(new Response(false, "Invalid credentials."));
        }

        var claims = new List<Claim>
        {
            new Claim(type: ClaimTypes.Email, value: signInRequest.Email),
            new Claim(type: ClaimTypes.Name,value: user.Name)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            });
        // add custom header 
        HttpContext.Response.Headers.Add("Authorization", "cookie= sfaasdas fabio test heresres");
        HttpContext.Response.Headers.Add("Cookie", "bearer= sfaasdas fabio test heresres");

        var cookieOptions = new CookieOptions
        {
            // Set the secure flag, which Chrome's changes will require for SameSite none.
            // Note this will also require you to be running on HTTPS.
            Secure = true,

            // Set the cookie to HTTP only which is good practice unless you really do need
            // to access it client side in scripts.
            HttpOnly = true,

            // Add the SameSite attribute, this will emit the attribute with a value of none.
            // Strict - value will only allow first party cookies to be sent. This setting is good for user actions like login credentials, but the cookie will not be sent on the initial request to the webpage.
            // Lax - allow the user to maintain a logged in status while arriving from an external link. This works well for things like transferring a promotional code as it is sent in these top-level navigations
            // None
            SameSite = SameSiteMode.None,

            // The client should follow its default cookie policy.
            // SameSite = SameSiteMode.Unspecified
            MaxAge = TimeSpan.FromDays(1)
        };
        HttpContext.Response.Cookies.Append("MyCookie", "cookieValue 123 test", cookieOptions);
        _logger.LogInformation("User {user.Email} logged in at {Time}.", user.Email, DateTime.UtcNow);
        return Ok(new Response(true, "Signed in successfully"));
    }

    [Authorize]
    [HttpGet("user")]
    public IActionResult GetUser()
    {
        var userClaims = User.Claims.Select(x => new UserClaim(x.Type, x.Value)).ToList();

        var userName = HttpContext.User.Claims
                .Where(x => x.Type == ClaimTypes.Name)
                .Select(x => x.Value)
                .FirstOrDefault();

        return Ok(userClaims);
        // return Ok(new { Message = $"UserName is {userName}" });
    }

    [Authorize(AuthenticationSchemes = "SecondJwtScheme")]
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        var userClaims = User.Claims.Select(x => new UserClaim(x.Type, x.Value)).ToList();

        var userName = HttpContext.User.Claims
                .Where(x => x.Type == ClaimTypes.Name)
                .Select(x => x.Value)
                .FirstOrDefault();

        //return Ok( userName);
        return Ok(new { Message = $"UserName is {userName}" });
    }

    [Authorize]
    [HttpGet("logout")]
    // public async Task SignOutAsync()
    public async Task<ActionResult> LogoutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
        // await HttpContext.SignOutAsync(
        //    CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
