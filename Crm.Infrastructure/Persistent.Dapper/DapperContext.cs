using Microsoft.Data.SqlClient;
using System.Data;

namespace Crm.Infrastructure.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public string Ticket => "[ticket].Tickets";
        public string TicketDetail => "[ticket].TicketDetails";
        public string User => "[user].Users";
        public string UserToken => "[user].UserTokens";
        
    }
}
