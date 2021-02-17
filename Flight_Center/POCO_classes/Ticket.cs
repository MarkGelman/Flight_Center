using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Ticket : IPoco
    {
        public long Id { get; set; }

        public long Flight_Id { get; set; }

        public long Customer_Id { get; set; }

        public Ticket()
        {

        }

        public Ticket(long id, long flight_id, long customer_id)
        {
            Id = id;
            Flight_Id = flight_id;
            Customer_Id = customer_id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            Ticket test = obj as Ticket;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Ticket c1, Ticket c2)
        {

            if (c1 is null && c2 is null)
                return true;
            if (c1.Id == c2.Id)
                return true;
            return false;
        }

        public static bool operator !=(Ticket c1, Ticket c2)
        {
            return !(c1 == c2);

        }
    }
}
