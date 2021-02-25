using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Administrator:IPoco,IUser
    {
        User user;
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Level { get; set; }
        public long User_Id { get; set; }

        public Administrator()
        {

        }

        public Administrator(int id, string first_name, string last_name, int level, long user_id)
        {
            Id = id;
            First_Name = first_name;
            Last_Name = last_name;
            Level = level;
            User_Id = user_id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            Administrator test = obj as Administrator;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Administrator admin1, Administrator admin2)
        {


            if (admin1 is null)
            {
                if (admin2 is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return admin1.Equals(admin2);
        }

        public static bool operator !=(Administrator admin1, Administrator admin2)
        {
            return !(admin1 == admin2);
        }
    }
}

