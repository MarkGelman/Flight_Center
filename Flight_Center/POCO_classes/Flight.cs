using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Flight:IPoco
    {
        public long Id { get; set; }
        public long Airline_Company_Id { get; set; }
        public long Origin_Country_Id { get; set; }
        public long Destination_Country_Id { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Landing_Time { get; set; }
        public int Remaining_Tickets { get; set; }

        public Flight()
        {

        }

        public Flight(long id,long airline_company_id,long origin_country_id,long destination_country_id,DateTime departure_time,DateTime landing_time,int remaining_tickets)
        {
            Id = id;
            Airline_Company_Id = airline_company_id;
            Origin_Country_Id = origin_country_id;
            Destination_Country_Id = destination_country_id;
            Departure_Time = departure_time;
            Landing_Time = landing_time;
            Remaining_Tickets = remaining_tickets;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            Flight test = obj as Flight;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Flight c1, Flight c2)
        {

            if (c1 is null && c2 is null)
                return true;
            if (c1.Id == c2.Id)
                return true;
            return false;
        }

        public static bool operator !=(Flight c1, Flight c2)
        {
            return !(c1 == c2);
        }

    }
}
