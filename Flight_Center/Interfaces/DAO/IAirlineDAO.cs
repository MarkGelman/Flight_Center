using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center.Interfaces
{
    interface IAirlineDAO:IBasicDb<Airline_Company>
    {
       List<Airline_Company> GetAirlineByUsername(string name);

        List<Airline_Company> GetAllAirlineByCountry(string country);
    }
}
