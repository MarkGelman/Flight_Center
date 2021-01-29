using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class User:IPoco
    {
        public long Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public int User_Role { get; set; }

        public User()
        {

        }
        public User(long id,string username,string password,string email,int user_role)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            User_Role = user_role;
        }
    }
}
