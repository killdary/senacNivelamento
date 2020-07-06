using Microsoft.IdentityModel.Tokens;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SenacNivelamento.Application.Common.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Funcionario funcionario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, funcionario.Login.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, funcionario.Nome.ToString()),
                    new Claim(ClaimTypes.Role, funcionario.Cargo.NivelAcesso.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
