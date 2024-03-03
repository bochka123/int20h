using System.Text;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Mappers;
using Int20h.BLL.Services;
using Int20h.Common.Helpers;
using Int20h.DAL.Context;
using AutoMapper;
using Int20h.WebApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Security.Claims;
using Int20h.DAL.Interfaces;
using Int20h.DAL.Helpers;
using Azure.Storage.Blobs;
using QueryCraft.MVC;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Int20h.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        services.Configure<JwtOptionsHelper>(options =>
        {
			options.Audience = configuration["Jwt:Audience"]!;
			options.Issuer = configuration["Jwt:Issuer"]!;
			options.Key = configuration["Jwt:Key"]!;
            options.RefreshTokenKey = configuration["Jwt:RefreshTokenKey"]!;

			if (int.TryParse(configuration["Jwt:TokenExpiration"], out int tokenExpiration))
			{
				options.TokenExpiration = tokenExpiration;
			}
			else
			{
				options.TokenExpiration = 60;
			}
		});
		services.ConfigureIdentity(configuration);
        services.AddScoped<IMigrationHelper, MigrationHelper>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddTransient<IAzureBlobStorageService, AzureBlobStorageService>();
        services.AddScoped<IUserService, UserService>();
		services.AddScoped<ITokenService, TokenService>();
        services.AddTransient<IGroupService, GroupService>();
        services.AddTransient<ISubjectService, SubjectService>();
        services.AddScoped<ICredentialService, CredentialService>();
        services.AddTransient<ITestService, TestService>();
        services.AddTransient<IAdminService, AdminService>();
        services.AddTransient<IQuestionService, QuestionService>();
        services.RegisterQueryCraft();
        services.AddTransient<IPagingService, PagingService>();
	}

    public static void AddCustomAutoMapperProfiles(this IServiceCollection services)
    {
		services.AddAutoMapper(conf =>
		{
			conf.AddProfiles(
				new List<Profile>()
				{
						new DataMapperProfile(),
				});
		});
	}
	public static void AddFluentValidation(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining(typeof(Program));
	}

	public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
    {
		services.ConfigureAuthentication(config);
        services.AddAuthorization();
    }

    public static void RegisterAzureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["AzureBlobStorageSettings:ConnectionString"];

        services.AddScoped(_ =>
                new BlobServiceClient(connectionString));

        services.AddSingleton(provider =>
        {
            var options = new BlobContainerOptionsHelper
            {
                BlobContainerName = configuration["AzureBlobStorageSettings:BlobContainerName"]!
            };
            return options;
        });
    }
}
