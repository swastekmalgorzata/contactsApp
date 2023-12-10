using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("zle dane");
            }
            var result = await _userManager.CreateAsync(new IdentityUser { UserName = request.Email , Email = request.Email }, request.Password);
            if(result.Succeeded)
            {
                request.Password = "";
                return Ok();
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LogInResponse>> LogIn([FromBody] LogInRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            if(managedUser == null)
            {
                return BadRequest("User not found");
            }

            var isPasswordOk = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordOk)
            {
                return BadRequest("zle haslo");
            }

            
            var accesToken = _tokenService.CreateToken(managedUser);
            await _context.SaveChangesAsync();
            return Ok(new{Emial = managedUser.Email,Token = accesToken,});
        }
    }
}
