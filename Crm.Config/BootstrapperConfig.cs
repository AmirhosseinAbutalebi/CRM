using Microsoft.Extensions.DependencyInjection;
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
    }
}
