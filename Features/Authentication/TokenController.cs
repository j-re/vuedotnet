using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using vue.Data.Entities;
using vue.Infrastructure;

namespace vue.Features.Authentication
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public TokenController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenGenerator tokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("gettoken")]
        public async Task<IActionResult> GetToken([FromBody] LoginViewModel model)
        {
            var errorMessage = "Invalid e-mail address and/or password";
            if (!ModelState.IsValid)
                return BadRequest(errorMessage);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(errorMessage);

            if (await _userManager.IsLockedOutAsync(user))
                return BadRequest(errorMessage);

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
            if (!result.Succeeded)
                return BadRequest(errorMessage);

            var token = await _tokenGenerator.GenerateToken(user);

            return Ok(token);
        }

        [HttpPost]
        [Route("unlockuser")]
        public async Task<IActionResult> UnlockUser([FromBody] LoginViewModel model)
        {
            var errorMessage = "Invalid e-mail address and/or password";
            if (!ModelState.IsValid)
                return BadRequest(errorMessage);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(errorMessage);


            var result = await _userManager.SetLockoutEnabledAsync(user, false);
            if (!result.Succeeded)
                return BadRequest(errorMessage);

            return Ok();
        }

        
    }

    public class TokenViewModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("access_token_expiration")]
        public DateTime AccessTokenExpiration { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
