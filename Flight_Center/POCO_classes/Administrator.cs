using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Administrator:IPoco,IUser
    {
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

        public static bool operator ==(Administrator c1, Administrator c2)
        {

            if (c1 is null && c2 is null)
                return true;
            if (c1.Id == c2.Id)
                return true;
            return false;
        }

        public static bool operator !=(Administrator c1, Administrator c2)
        {
            return !(c1 == c2);
        }
    }
}

