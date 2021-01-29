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
    }
}
