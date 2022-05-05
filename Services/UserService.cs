using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Controllers.Models.Responses;
using TimeSheets.GB.DAL.Entities;
using TimeSheets.GB.DAL.Interfaces;
using TimeSheets.GB.Services.Interfaces;

namespace TimeSheets.GB.Services
{
    public class UserService : IUserService
    {
        public const string SecretCode = "Maternity time evaluates the natural logarithm.";
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public TokenResponse Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            var tokenResponse = new TokenResponse();
            var i = 0;
            var users = _repository.GetByName(username).Result;

            foreach (var user in users)
            {
                i++;
                if (string.CompareOrdinal(user.Name, username) == 0 &&
                    string.CompareOrdinal(user.Password, password) == 0)
                {
                    tokenResponse.Token = GenerateJwtToken(i, 15);
                    var refreshToken = GenerateRefreshToken(i);
                    user.Token = refreshToken;
                    return tokenResponse;
                }
            }

            return null;
        }

        private TokenEntity GenerateRefreshToken(int id)
        {
            const int lifeTime = 360;
            var refreshToken = new TokenEntity
            {
                Expires = DateTime.Now.AddMinutes(lifeTime),
                Token = GenerateJwtToken(id, lifeTime)
            };
            return refreshToken;
        }

        private string GenerateJwtToken(int id, int minutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretCode);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> Create(UserDto item)
        {
            return await _repository.Create(new UserEntity
            {
                Name = item.Name,
                Password = item.Password
            });
        }

        public Task<bool> Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<UserDto> Get(int id)
        {
            var result = await _repository.Get(id);
            return new UserDto
            {
                Name = result.Name,
                Password = result.Password
            };
        }

        public Task<IList<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public string RefreshToken(string token)
        {
            var i = 0;
            foreach (var user in _repository.GetAll().Result)
            {
                i++;
                if (string.CompareOrdinal(user.Token.Token, token) == 0 &&
                    user.Token.IsExpired is false)
                {
                    user.Token.Token = GenerateRefreshToken(i).ToString();
                    return user.Token.Token;
                }
            }
            return string.Empty;
        }

        public Task<UserDto> Update(int id, UserDto item)
        {
            throw new NotImplementedException();
        }
    }
}
