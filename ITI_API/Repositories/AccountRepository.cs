using ITI_API.DTO;
using ITI_API.Interfaces;
using ITI_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ITI_API.Repositories
{
    public class AccountRepository(ItiContext dbContext) : IAcountRepository
    {
        public async Task<string?> LoginAsync(LogInDTO user)
        {
            var usrerInDb = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == user.Username && u.PasswordHash == user.Password);
            if (usrerInDb == null)
            {
                return null;
            }

            var TokenHandler = new JwtSecurityTokenHandler();
            var ToknDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, usrerInDb.Email)

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtTokenFromProjectITI")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(ToknDescriptor);
            var tokenString = TokenHandler.WriteToken(token);
            return tokenString;
        }

      
    }
}
