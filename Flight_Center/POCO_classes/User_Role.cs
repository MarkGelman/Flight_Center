using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class User_Role:IPoco
    {
        public long Id { get; set; }
        public string Role_Name { get; set; }

        public User_Role()
        {

        }

        public User_Role(long id, string role_name)
        {
            Id = id;
            Role_Name = role_name;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            User_Role user_role = obj as User_Role;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(User_Role u_r1, User_Role u_r2)
        {

            if (u_r1 is null && u_r2 is null)
                return true;
            if (u_r1.Id == u_r2.Id)
                return true;
            return false;
        }

        public static bool operator !=(User_Role u_r1, User_Role u_r2)
        {
            return !(u_r1 == u_r2);
        }
    }
}
