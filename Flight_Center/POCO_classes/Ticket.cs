using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Ticket : IPoco
    {
        Flight flight;
        Customer customer;
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
            Ticket ticket = obj as Ticket;
            return this.Id.Equals(ticket.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Ticket t1, Ticket t2)
        {

            if (t1 is null)
            {
                if (t2 is null)
                    return true;
                return false;
            }
            return t1.Equals(t2);
        }

        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return !(t1 == t2);

        }
    }
}
