using APIproje.Dto;
using APIproje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIproje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                DateAdded = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }



            return BadRequest(result.Errors);


        }

        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null)
            {
                return BadRequest(new {message = "Mail Bulunamadı"});
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password,false);

            if (result.Succeeded)
            {
                return Ok(
                    new { token = "token" }
                );
            }
            return Unauthorized();
        }
 
    }
}
