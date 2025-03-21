using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Security.Jwt
{
    public class JwtHandler(IConfiguration configuration) : IJwtHandler
    {
        public string Handle(Client client)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:Secret"] ?? string.Empty);
            var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.SerialNumber, client.Id.ToString()),
                new Claim(ClaimTypes.Email, client.Email),
                new Claim(ClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
            ]);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
