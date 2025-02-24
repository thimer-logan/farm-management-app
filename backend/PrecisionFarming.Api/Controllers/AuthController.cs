using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrecisionFarming.Application.Common.DTO;
using PrecisionFarming.Application.Common.Interfaces;
using PrecisionFarming.Domain.Entities.Identity;
using System.Security.Claims;

namespace PrecisionFarming.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IJwtService _jwtService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }

            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                AppUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (user == null)
                {
                    return NoContent();
                }

                var authenticationResponse = _jwtService.CreateJwtToken(user);
                user.RefreshToken = authenticationResponse.RefreshToken;
                user.RefreshTokenExpiration = authenticationResponse.RefreshExpiration;
                await _userManager.UpdateAsync(user);

                return Ok(authenticationResponse);
            }

            return Problem("Invalid login attempt");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout(LoginDTO loginDTO)
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterPost(RegisterDTO registerDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }

            var user = new AppUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                if (registerDto.Role == null || !await _roleManager.RoleExistsAsync(registerDto.Role))
                {
                    return BadRequest("Invalid role");
                }

                var assignRoleResult = await _userManager.AddToRoleAsync(user, registerDto.Role);
                if (!assignRoleResult.Succeeded)
                {
                    string assignError = string.Join(" | ", assignRoleResult.Errors.Select(x => x.Description));
                    return Problem($"Failed to assign role: {assignError}");
                }

                // sign in the user
                await _signInManager.SignInAsync(user, isPersistent: false);
                var authenticationResponse = _jwtService.CreateJwtToken(user);
                user.RefreshToken = authenticationResponse.RefreshToken;
                user.RefreshTokenExpiration = authenticationResponse.RefreshExpiration;
                await _userManager.UpdateAsync(user);

                return Ok(authenticationResponse);
            }

            string errorMessage = string.Join(" | ", result.Errors.Select(x => x.Description));
            return Problem(errorMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Ok(true);
            }

            return Ok(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenDTO tokenDto)
        {
            if (tokenDto == null)
            {
                return BadRequest("Invalid request");
            }

            string? jwtToken = tokenDto.Token;
            string? refreshToken = tokenDto.RefreshToken;

            ClaimsPrincipal? principal = _jwtService.GetPrincipalFromJwtToken(jwtToken);
            if (principal == null)
            {
                return BadRequest("Invalid token");
            }

            string? email = principal.FindFirstValue(ClaimTypes.Email);
            if (email == null)
            {
                return BadRequest("Invalid token");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiration < DateTime.Now)
            {
                return BadRequest("Invalid refresh token");
            }

            var authenticationResponse = _jwtService.CreateJwtToken(user);
            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpiration = authenticationResponse.RefreshExpiration;
            await _userManager.UpdateAsync(user);
            return Ok(authenticationResponse);
        }
    }
}
