using System;
using System.Threading.Tasks;
using AspNetCoreDocker.Models;
using AspNetCoreDocker.InputModels;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreDocker.Auth;
using System.Linq;

namespace AspNetCoreDocker.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController: Controller
    {
        private JwtProvider _tokenProvider;
        private EFContext _context;        

        public AccountsController(EFContext context, JwtProvider tokenProvider)
        {   
            _tokenProvider = tokenProvider;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInputModel login)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
            if(user == null)
                return BadRequest("Usuário e/ou senha inválidos");

            var encodedToken = _tokenProvider.CreateEncoded(user.UserName);
            return Json(new 
            {
                Name = user.Name,
                Token = encodedToken,
                Expires = DateTime.Now
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountInputModel createAccount)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == createAccount.UserName);
            if(user != null)
                return BadRequest("Usuário já existe");

            user = new User
            {
                Name = createAccount.Name,
                UserName = createAccount.UserName, 
                Password = createAccount.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();                 
        } 
    }    
}