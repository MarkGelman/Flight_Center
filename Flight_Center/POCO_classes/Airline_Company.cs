using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Airline_Company:IPoco,IUser
    {
        User user;
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

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            Airline_Company test = obj as Airline_Company;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Airline_Company a_c1, Airline_Company a_c2)
        {


            if (a_c1 is null)
            {
                if (a_c2 is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return a_c1.Equals(a_c2);
        }

        public static bool operator !=(Airline_Company a_c1, Airline_Company a_c2)
        {
            return !(a_c1 == a_c2);
        }
    }
}
