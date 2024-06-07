using Crm.Infrastructure.Persistent.Dapper;
using Crm.Query.Users.DTOs;
using Dapper;
using MediatR;

namespace Crm.Query.Users.UserToken.GetUserByRefreshToken
{
    internal class GetUserTokenByRefreshTokenQueryHandler : IRequestHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserTokenByRefreshTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"select top(1) * from {_dapperContext.UserToken} where HashRefreshToken = @hashRefreshToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashRefreshToken = request.HashRefreshToken });

        }
    }
}
