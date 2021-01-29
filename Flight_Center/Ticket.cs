using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Ticket:IPoco
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
    }
}
