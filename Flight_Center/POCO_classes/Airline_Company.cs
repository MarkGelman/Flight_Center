using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Airline_Company:IPoco,IUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Country_Id { get; set; }
        public long User_Id { get; set; }

        public Airline_Company()
        {

        }

        public Airline_Company(int id, string name, long country_id, long user_id)
        {
            Id = id;
            Name = name;
            Country_Id = country_id;
            User_Id = user_id;
        }
    }
}
