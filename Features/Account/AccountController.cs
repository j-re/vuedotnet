using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using vue.Data.Entities;
using vue.Infrastructure;

namespace vue.Features.Account
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly ITokenGenerator _tokenGenerator;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
                return BadRequest("A user with that e-mail address already exists!");

            user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                EmailConfirmed = true,
                UserName = model.Email,
                LockoutEnabled = true
            };

            var registerResult = await _userManager.CreateAsync(user, model.Password);
            if (!registerResult.Succeeded)
                return BadRequest(registerResult.Errors);

            await _userManager.AddToRoleAsync(user, "Customer");

            await _signInManager.SignInAsync(user,true);

             var token = await _tokenGenerator.GenerateToken(user);

            return Ok(token);
        }
    }


    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }

}
