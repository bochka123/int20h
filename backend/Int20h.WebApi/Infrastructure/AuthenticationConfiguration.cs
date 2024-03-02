using Int20h.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Int20h.WebApi.Infrastructure
{
    public static class AuthenticationConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role
                };
                o.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var email = context?.Principal?.FindFirst(ClaimTypes.Email);
                        if (email == null || email.Value == null)
                        {
                            context?.Fail("NameClaimType is missing in the token.");
                            return;
                        }
                        var credentialService = context?.HttpContext.RequestServices.GetRequiredService<ICredentialService>();
                        if (!await credentialService!.SetUser(email!.Value))
                        {
                            context?.Fail("No user found for provided email!");
                        }
                    }
                };
            });
        }
    }
}
