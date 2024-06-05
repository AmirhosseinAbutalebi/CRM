using Crm.Domain.TicketAgg.Repository;
using Crm.Domain.UserAgg.Repository;
using Crm.Infrastructure.Persistent.Dapper;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Infrastructure.Persistent.Ef.Ticket;
using Crm.Infrastructure.Persistent.Ef.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void InfrastructureDependency(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();


            services.AddTransient( _ => new DapperContext(connectionString));
            services.AddDbContext<CrmDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
