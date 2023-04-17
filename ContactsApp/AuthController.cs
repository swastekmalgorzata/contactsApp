using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserContext _context;
        private readonly TokenServices _tokenService;
        public AuthController(UserManager<IdentityUser> userManager, UserContext context, TokenServices tokenServices )
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenServices;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("zle dane");
            }
            var result = await _userManager.CreateAsync(
                new IdentityUser { UserName = request.UserName, Email = request.Email },
                request.Password
            );
            if(result.Succeeded)
            {
                request.Password = "";
                return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);

        }
        [HttpPost]
            [Route("login")]
            public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userInDatabase = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (userInDatabase is null)
            {
                return Unauthorized();
            }
            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            if(managedUser == null)
            {
                return BadRequest("zly uzytkownik");
            }

            var isPasswordOk = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordOk)
            {
                return BadRequest("zle haslo");
            }

            
            var accesToken = _tokenService.CreateToken(userInDatabase);
            await _context.SaveChangesAsync();
            return Ok(
                new AuthResponse
                {
                    Username = userInDatabase.UserName,
                    Emial = userInDatabase.Email,
                    Token = accesToken,
                }
                );
        }
    }
}
