using Bogus;
using Domain.Entities;
using Utils.Tests.Cryptography;

namespace Utils.Tests.Entities;

public class UserBuilder
{
    public static (User user, string password) Build()
    {
        var (user, password) = CreateUser();
        user.Id = 1;

        return (user, password);
    }

    private static (User user, string password) CreateUser()
    {
        var password = string.Empty;

        var userCreated = new Faker<User>()
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Email, f => f.Person.Email)
            .RuleFor(x => x.YearBorn, f => f.Person.DateOfBirth.AddYears(18).ToLongDateString())
            .RuleFor(x => x.Password, f =>
            {
                password = f.Internet.Password();

                return PasswordEncryptorBuilder.Instance().Encrypt(password);

            });

        return (userCreated, password);
    }
}