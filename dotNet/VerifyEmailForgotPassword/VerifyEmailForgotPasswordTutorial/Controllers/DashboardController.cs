using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VerifyEmailForgotPasswordTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public DashboardController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            return Ok("this is protected!");
        }
    }
}
