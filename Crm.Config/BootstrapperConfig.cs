using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Crm.Application.Shared;
using FluentValidation;
using MediatR;
using Crm.Application.Ticket.Create;
using Crm.Presentation.Facade;
using Crm.Application.Ticket.CreateTicketDetail;
using Crm.Infrastructure;
using Crm.Query.Users.GetUserById;

namespace Crm.Config
{
    public class BootstrapperConfig
    {
        public static void DependencyInjectionConfig(IServiceCollection service, string connectionString)
        {

            service.InfrastructureDependency(connectionString);

            service.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly));
            service.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateTicketDetailCommand).Assembly));

            service.AddValidatorsFromAssembly(typeof(CreateTicketCommandValidator).Assembly);

            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            service.FacadeDependency();
        }
        public static void AuthenticationJWT(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SignInKey"])),
                    ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                    ValidAudience = builder.Configuration["JwtConfig:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true
                };
                option.SaveToken = true;
            });
        }
    }
}
