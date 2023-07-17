using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using ToDo.Domain.DTO;
using ToDo.Domain.InputModel;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route(nameof(AuthController.Cadastro))]
        public async Task<ActionResult<User>> Cadastro(DadosUser user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            _userRepository.CadastrarUser(user.Username, passwordHash, passwordSalt);
            return Ok("Cadastro realizado com sucesso!");
        }

        [HttpPost]
        [Route(nameof(AuthController.Login))]
        public async Task<ActionResult<string>> Login (DadosUser user)
        {
            var userLogin = _userRepository.BuscarUserPorUsername(user.Username);

            if (userLogin == null)
            {
                return BadRequest("Usuário não encontrado");
            }

            if(!VerifyPasswordHash(user.Password, userLogin.PasswordHash, userLogin.PasswordSalt))
            {
                return BadRequest("Senha incorreta.");
            }

            string token = CreateToken(userLogin);

            return Ok(token);

        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            
            return jwt;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordhash);
            }
        }


    }
}
