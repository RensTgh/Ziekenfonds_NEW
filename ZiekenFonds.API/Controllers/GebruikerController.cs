using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Gebruiker;
using ZiekenFonds.API.Helpers;
using ZiekenFonds.API.Models;


namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GebruikerController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> Register(RegistratieDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gebruiker = await _userManager.FindByEmailAsync(request.Email);
            if (gebruiker != null)
            {
                ModelState.AddModelError("message", "Gebruiker is aanwezig is database.");
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<CustomUser>(request);

            user.UserName = request.Email;
            user.NormalizedUserName = request.Naam.ToUpper();
            user.NormalizedEmail = request.Email.ToUpper();

            user.IsActief = true;
            user.isHoofdMonitor = true;
            user.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(user, request.Password);

            await _userManager.AddToRoleAsync(user, "deelnemer");

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                if (result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("message", error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CustomUser? user = await _userManager.FindByNameAsync(model.Email.ToUpper());
            if (user == null)
            {
                ModelState.AddModelError("message", "e-mail niet gevonden");
                return BadRequest(ModelState);
            }

            if (user != null && !user.EmailConfirmed)
            {
                ModelState.AddModelError("message", "Emailadres is nog niet bevestigd.");
                return BadRequest(ModelState);
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
            {
                // Nooit exacte informatie geven: zeg alleen dat combinatie vekeerd is...
                ModelState.AddModelError("message", "Verkeerde logincombinatie!");
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("message", "Account geblokkeerd!!");
            }

            if (result.Succeeded)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles != null)
                {
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                }

                var token = Token.GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            ModelState.AddModelError("message", "Ongeldige loginpoging");
            return Unauthorized(ModelState);
        }



        [Route("Lijst")]
        [HttpGet]
        public async Task<ActionResult> GetLijst()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            CustomUser? gebruiker = await _userManager.FindByIdAsync(id);
            if (gebruiker != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(gebruiker);
                if (result.Succeeded)
                    return Ok("De gebruiker is succesvol verwijderd.");
                else
                {
                    if (result.Errors.Count() > 0)
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError("message", error.Description);
                    }
                    return BadRequest(ModelState);
                }
            }
            return NotFound();
        }
    }
}