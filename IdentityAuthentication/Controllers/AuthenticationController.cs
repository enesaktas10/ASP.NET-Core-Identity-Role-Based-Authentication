using AutoMapper;
using IdentityAuthentication.Dto;
using IdentityAuthentication.Models.Entities;
using IdentityAuthentication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserManager<User> _userManager,SignInManager<User> _signInManager,IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IdentityResult> RegisterUser([FromBody] UserForRegistrationDto model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            //Role tanimlama
            if (result.Succeeded)
            {
                //birden fazla role tanimimiz vardi UserForRegistrationDto gidip bakabilrisin collection icinde
                await _userManager.AddToRolesAsync(user, model.Roles);
            }

            return result;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
                return Ok(new { message = "user logged is succesfuly" });

            return Unauthorized();
        }



        [Authorize(Roles = "Admin")]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            return Ok("This is a protected API endpoint! ENES");
        }

        [Authorize(Roles = "User")]
        [HttpGet("protected2")]
        public IActionResult ProtectedEndpoint2()
        {
            return Ok("This is a protected API endpoint! GAMZE");
        }


    }
}
