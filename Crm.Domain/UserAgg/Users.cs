﻿using Crm.Domain.Shared;
using Crm.Domain.UserAgg.Enums;
namespace Crm.Domain.UserAgg
{
    public class Users : AggregateRoot
    {
        public Users(string userName, string password, string firstName, string lastName, LevelUser role)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
        private Users()
        {

        }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public LevelUser Role { get; private set; }

    }
}
