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
    }
}
