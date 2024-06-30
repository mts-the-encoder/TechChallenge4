using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services.Token;

public class TokenService(double tokenLifeTimeMinutes, string securityKey)
{
	private const string EmailAlias = "eml";
	private readonly double _TokenLifeTimeMinutes = tokenLifeTimeMinutes;
	private readonly string _securityKey = securityKey;

	public string GenerateToken(string email)
	{
		var claims = new List<Claim>
		{
			new(EmailAlias, email),
		};

		var tokenHandler = new JwtSecurityTokenHandler();

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.AddMinutes(_TokenLifeTimeMinutes),
			SigningCredentials = new SigningCredentials(SymmetricKey(), SecurityAlgorithms.HmacSha256Signature)
		};

		var securityToken = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(securityToken);
	}

	private ClaimsPrincipal ValidateToken(string token)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var validationParameter = new TokenValidationParameters
		{
			RequireExpirationTime = true,
			IssuerSigningKey = SymmetricKey(),
			ClockSkew = new TimeSpan(0),
			ValidateIssuer = false,
			ValidateAudience = false,
		};

		var claims = tokenHandler.ValidateToken(token, validationParameter, out _);

		return claims;
	}

	public string GetEmail(string token)
	{
		var claims = ValidateToken(token);

		return claims.FindFirst(EmailAlias).Value;
	}

	private SymmetricSecurityKey SymmetricKey()
	{
		var symmetricKey = Convert.FromBase64String(_securityKey);
		return new SymmetricSecurityKey(symmetricKey);
	}
}