using Application.Services.Token;
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
        AddTokenJWT(services, configuration);
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

    private static void AddTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
	    var lifeTime = configuration.GetRequiredSection("Configurations:Jwt:TimeInMinutes");
	    var sectionKey = configuration.GetRequiredSection("Configurations:Jwt:TokenKey");

	    services.AddScoped(option => new TokenService(int.Parse(lifeTime.Value), sectionKey.Value));
    }

	private static void AddUserSigned(IServiceCollection services)
    {
	    services.AddScoped<IUserSigned, UserSigned>();
    }
}