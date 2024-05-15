using Crm.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Crm.Domain.UserAgg.Repository;
using Crm.Infrastructure.Persistent.Ef.User;
using Crm.Query.Users.GetByUsername;
using Crm.Application.Shared;
using FluentValidation;
using MediatR;
using Crm.Application.Ticket.Create;
using Crm.Domain.TicketAgg.Repository;
using Crm.Infrastructure.Persistent.Ef.Ticket;
using Crm.Domain.TicketDetailAgg.Repository;
using Crm.Infrastructure.Persistent.Ef.TicketDetail;
using Crm.Application.TicketDetail.Create;


namespace Crm.Config
{
    /// <summary>
    /// we defing this class and set startup project there and dont need define this in program.cs
    /// just defie there and use it in program.cs
    /// </summary>
    public class BootstrapperConfig
    {
        /// <summary>
        /// this method for DI container and set connection string for connection to Sqlserver db
        /// </summary>
        /// <param name="service"> service is type of IserviceCollection</param>
        /// <param name="connectionString">connectionstring from type string and get string connection of sqlserver</param>
        public static void DependencyInjectionConfig(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<ITicketRepository, TicketRepository>();
            service.AddTransient<ITicketDetailRepository, TicketDetailRepository>();
            service.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetUserByUsernameQuery).Assembly));
            service.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateTicketCommand).Assembly));
            service.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateTicketDetailCommand).Assembly));
            service.AddDbContext<CrmDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            service.AddValidatorsFromAssembly(typeof(CreateTicketCommandValidator).Assembly);
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        }
        /// <summary>
        /// for set jwt and config in this project 
        /// </summary>
        /// <param name="builder">builder from type WebApplicationBuilder </param>
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
            });
        }
    }
}
