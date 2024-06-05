using Crm.Query.Users.DTOs;
namespace Crm.Query.Users
{
    public class UserMapper
    {
        public static UserDto UserMapToDto(Domain.UserAgg.Users users)
        {
            if (users == null)
                return null;
            return new UserDto()
            {
                Id = users.Id,
                FirstName = users.FirstName,
                LastName = users.LastName,
                UserName = users.UserName,
                Password = users.Password,
                Role = users.Role,
            };
        }

        public static List<UserDto> UserMapToListDto(List<Domain.UserAgg.Users> users)
        {
            if (users == null)
                return null;

            var listUser = users.Select(x => new UserDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Password = x.Password,
                Role = x.Role
            }).ToList();

            return listUser;
        }
    }
}
