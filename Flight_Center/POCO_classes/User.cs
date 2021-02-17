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

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            User test = obj as User;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(User c1, User c2)
        {

            if (c1 is null && c2 is null)
                return true;
            if (c1.Id == c2.Id)
                return true;
            return false;
        }

        public static bool operator !=(User c1, User c2)
        {
            return !(c1 == c2);
        }
    }
}
