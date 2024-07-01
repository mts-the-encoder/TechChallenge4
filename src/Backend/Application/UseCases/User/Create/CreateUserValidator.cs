using Application.Communication.Requests;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.UseCases.User.Create;

public class CreateUserValidator : AbstractValidator<UserRequest>
{
	public CreateUserValidator()
	{
		RuleFor(c => c.Name).NotEmpty().WithMessage("Nome não pode ser nulo");
		RuleFor(c => c.Email).NotEmpty().WithMessage("Email não pode ser nulo");
		RuleFor(c => c.YearBorn).NotEmpty().WithMessage("Idade não pode ser nulo");
		RuleFor(c => c.Password).SetValidator(new PasswordValidator());
		
		When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
		{
			RuleFor(c => c.Email).EmailAddress().WithMessage("Email não pode ser nulo");
		});

		When(c => !string.IsNullOrWhiteSpace(c.YearBorn), () =>
		{
			RuleFor(c => c.YearBorn)
				.Must(age => int.TryParse(age, out var result) && result >= 18)
				.WithMessage("Você precisa ser maior de 18");
		});
	}
}