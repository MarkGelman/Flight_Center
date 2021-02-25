using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center.Interfaces
{
    interface IAirlineDAO:IBasicDb<Airline_Company>
    {
      Airline_Company GetAirlineByUsername(string name);

      IList<Airline_Company> GetAllAirlineByCountry(string country);
    }
}
