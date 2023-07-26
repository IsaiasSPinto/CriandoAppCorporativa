using System.Text;
using Data.Services;
using Manager.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api.Configuration;

public static class JWTConfiguration
{
		public static void AddJWTConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
				services.AddSingleton<IJWTService, JWTService>();

				var chave = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);

				services.AddAuthentication(p =>
				{
						p.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
						p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				}).AddJwtBearer( p =>
				{
						p.RequireHttpsMetadata = false;
						p.SaveToken = true;
						p.TokenValidationParameters = new TokenValidationParameters { 
								ValidateIssuerSigningKey = true,
								IssuerSigningKey = new SymmetricSecurityKey(chave),
								ValidateIssuer = true,
								ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
								ValidateAudience = true,
								ValidAudience = configuration.GetSection("JWT:Audience").Value,
								ValidateLifetime = true,
						};
				});
		}

		public static void UseJWTConfiguration(this IApplicationBuilder app)
		{
				app.UseAuthentication();
				app.UseAuthorization();
		}
}
