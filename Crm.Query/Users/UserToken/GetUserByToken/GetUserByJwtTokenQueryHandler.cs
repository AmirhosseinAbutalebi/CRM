using Crm.Infrastructure.Persistent.Dapper;
using Crm.Query.Users.DTOs;
using Dapper;
using MediatR;

namespace Crm.Query.Users.UserToken.GetUserByToken
{
    internal class GetUserByJwtTokenQueryHandler : IRequestHandler<GetUserByJwtTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserByJwtTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto> Handle(GetUserByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"select top(1) * from {_dapperContext.UserToken} where HashJwtToken=@hashtoken";
            var result = await connection.QueryFirstOrDefaultAsync<UserTokenDto>
                (sql, new { hashtoken = request.HashJwtToken});
            return result;
        }
    }
}
