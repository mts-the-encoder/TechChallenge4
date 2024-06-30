using Application.Services.Token;
using Domain.Entities;
using Domain.Repositories.UserRepositories;
using Microsoft.AspNetCore.Http;

namespace Application.Services.UserSigned;

public class UserSigned(
	IHttpContextAccessor httpContextAccessor,
	TokenService tokenService,
	IUserReadOnlyRepository repository) : IUserSigned
{
	public async Task<User> GetUser()
	{
		var authorization = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

		var token = authorization["Bearer".Length..].Trim();

		var userEmail = tokenService.GetEmail(token);

		var user = await repository.GetByEmail(userEmail);

		return user;
	}
}