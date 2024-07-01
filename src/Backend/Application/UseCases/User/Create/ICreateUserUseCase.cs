using Application.Communication.Requests;
using Application.Communication.Responses;

namespace Application.UseCases.User.Create;

public interface ICreateUserUseCase
{
	Task<UserCreatedResponse> Execute(UserRequest req);
}