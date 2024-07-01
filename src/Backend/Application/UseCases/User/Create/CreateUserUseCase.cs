using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Exceptions;
using Application.Services.Cryptography;
using Application.Services.Token;
using AutoMapper;
using Domain.Repositories;
using Domain.Repositories.UserRepositories;

namespace Application.UseCases.User.Create;

public class CreateUserUseCase(
	IUserReadOnlyRepository readOnlyRepository,
	IUserWriteOnlyRepository writeOnlyRepository,
	IMapper mapper,
	IUnitOfWork unitOfWork,
	PasswordEncryptor passwordEncryptor,
	TokenService tokenService) : ICreateUserUseCase
{
	public async Task<UserCreatedResponse> Execute(UserRequest req)
	{
		await Validate(req);

		var entity = mapper.Map<Domain.Entities.User>(req);
		entity.Password = passwordEncryptor.Encrypt(req.Password);

		await writeOnlyRepository.Add(entity);
		await unitOfWork.Commit();

		var token = tokenService.GenerateToken(entity.Email);

		return new UserCreatedResponse()
		{
			Token = token
		};
	}

	private async Task Validate(UserRequest request)
	{
		var validator = new CreateUserValidator();
		var response = await validator.ValidateAsync(request);

		var existsUser = await readOnlyRepository.ExistsByEmail(request.Email);
		if (existsUser)
			response.Errors.Add(new FluentValidation.Results.ValidationFailure("email", "Email já existe"));

		if (!response.IsValid)
		{
			var errorsMessages = response.Errors.Select(error => error.ErrorMessage).ToList();
			throw new ValidationsException(errorsMessages);
		}
	}
}