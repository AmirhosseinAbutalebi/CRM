using Crm.Presentation.Facade.Ticket;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void FacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<ITicketFacade, TicketFacade>();
        }
    }
}
