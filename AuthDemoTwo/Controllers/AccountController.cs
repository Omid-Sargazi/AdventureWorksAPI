using AuthDemoTwo.Models;
using AuthDemoTwo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemoTwo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    Message="Invalid Data",
                    StatusCode=StatusCodes.Status400BadRequest, 
                });
            }

             if(await _userService.UserExistAsync(model.Email))
                {
                    return Conflict(new Response
                    {
                        Message = "User already exists.",
                        StatusCode = StatusCodes.Status409Conflict
                    });
                }
            var result = await _userService.RegisterUserAsync(model);

            if(result)
            {
                return Ok(new Response
                {
                    Message = "User registered successfully",
                    StatusCode = StatusCodes.Status200OK
                });
            }

            return StatusCode(500,new Response
            {
                Message="Registaration Failed",
                StatusCode = StatusCodes.Status500InternalServerError
            });
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    Message="Invalid Data",
                    StatusCode = StatusCodes.Status400BadRequest,
                });
            }

            if(!await _userService.UserExistAsync(model.Email))
            {
                return Unauthorized(new Response
                {
                    Message = "Invalid credentials",
                    StatusCode = StatusCodes.Status401Unauthorized
                });
            }

            var isValidUser = await _userService.ValidateUserAsync(model);
            if(isValidUser)
            {
                return Ok(new Response
                {
                    Message = "Login Success",
                    StatusCode = StatusCodes.Status200OK
                });
            }

            return Unauthorized(new Response
            {
                Message = "Invalid credentials",
                StatusCode = StatusCodes.Status401Unauthorized,
            });
        }


    }
}