using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CardCore.Infrastructure;
using MediatR;
using System.Reflection;

namespace CardCore.Application
{
    public static class RegisterApplication
    {
        public static IServiceCollection RegisterApplicationDI(this IServiceCollection services, IConfiguration configuration){
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetValue<string>("JwtSettings:Issuer"),
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtSettings:TokenSecret").Value!))
                };
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.RegistereInfrastructureDI(configuration);
            return services;
        }
    }
}