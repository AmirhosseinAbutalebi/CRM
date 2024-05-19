using Crm.Presentation.Facade.Ticket;
using Crm.Presentation.Facade.TicketDetail;
using Crm.Presentation.Facade.User;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void FacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<ITicketFacade, TicketFacade>();
            services.AddScoped<ITicketDetailFacade, TicketDetailFacade>();
            services.AddScoped<IUserFacade, UserFacade>();
        }
    }
}
