using Application.Services.UserSigned;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddHashIds(services, configuration);
        AddUserSigned(services);

    }

    private static void AddHashIds(IServiceCollection services, IConfiguration configuration)
    {
        var salt = configuration.GetRequiredSection("Configurations:HashIds:Salt");

        services.AddHashids(setup =>
        {
            setup.Salt = salt.Value;
            setup.MinHashLength = 3;
        });
    }

    private static void AddUserSigned(IServiceCollection services)
    {
	    services.AddScoped<IUserSigned, UserSigned>();
    }
}