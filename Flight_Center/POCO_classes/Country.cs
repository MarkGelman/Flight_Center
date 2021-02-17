using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    public class Country:IPoco
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
                
        }

        public Country(long id,string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
           Country test = obj as Country;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Country c1, Country c2)
        {

            if (c1 is null && c2 is null)
                return true;
            if (c1.Id == c2.Id)
                return true;
            return false;
        }

        public static bool operator !=(Country c1, Country c2)
        {
            return !(c1 == c2);
        }
    }
}
