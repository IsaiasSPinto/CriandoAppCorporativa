using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Domain;
using Manager.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Data.Services;

public class JWTService : IJWTService
{
		private readonly IConfiguration _configuration;
		public JWTService(IConfiguration configuration)
		{
				_configuration = configuration;
		}

		public string GerarToken(Usuario usuario)
		{
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWT:Secret").Value);

				var claims = new List<Claim> {
						new Claim(ClaimTypes.Name,usuario.Login)
				};

				claims.AddRange(usuario.Funcoes.Select(p => new Claim(ClaimTypes.Role, p.Descricao)));
				var tokenDescriptor = new SecurityTokenDescriptor
				{
						Subject = new ClaimsIdentity(claims),
						Audience = _configuration.GetSection("JWT:Audience").Value,
						Issuer = _configuration.GetSection("JWT:Issuer").Value,
						Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("JWT:ExpiraEmMinutos").Value)),
						SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
				};

				var token = tokenHandler.CreateToken(tokenDescriptor);

				return tokenHandler.WriteToken(token);
		}
}
