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
            User_Role test = obj as User_Role;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(User_Role c1, User_Role c2)
        {

            if (c1 is null && c2 is null)
                return true;
            if (c1.Id == c2.Id)
                return true;
            return false;
        }

        public static bool operator !=(User_Role c1, User_Role c2)
        {
            return !(c1 == c2);
        }
    }
}
