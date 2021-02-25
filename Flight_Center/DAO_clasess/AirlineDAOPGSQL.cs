using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center.Interfaces.DAO
{
    class AirlineDAOPGSQL : IAirlineDAO
    {
        string _sp_name = "";
        
        public List<Airline_Company> Reader(string query, string function)
        {
            List<Airline_Company> allAirlineCompanies = new List<Airline_Company>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Fligth_CenterAppConfig.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(_sp_name, connection))
                    {
                        command.CommandText = 
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               Airline_Company a_c = new Airline_Company()
                                {
                                    Id = (long)reader["id"],
                                    Name = (string)reader["name"],
                                };
                                allAirlineCompanies.Add(a_c);
                            }
                            return allAirlineCompanies;

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Fligth_CenterAppConfig._log.Error($"Connection failed.Exception: {ex}");
                Console.WriteLine($"Connection failed.Exception: {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
                return null;
            }

        }

        public int NonReader(string query, string function)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Fligth_CenterAppConfig.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                Fligth_CenterAppConfig._log.Error($"Connection failed.Exception: {ex}");
                Console.WriteLine($"Process '{ function}' failed.Exception : {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            return 0;
        }

        public Airline_Company GetAirlineByUsername(string name)
        {
            _sp_name = "sp_get_company_by_username";
            return Extraction(_sp_name, name);
        }

        public IList<Airline_Company> GetAllAirlineByCountry(string country)
        {
            _sp_name = "sp_get_all_company";
            return Reader(_sp_name, country);
        }

        public void Add(Airline_Company t)
        {
            _sp_name = "sp_insert_company";
            NonReader(_sp_name);
        }

        public void Remove(Airline_Company t)
        {
            throw new NotImplementedException();
        }

        public void Update(Airline_Company t)
        {
            throw new NotImplementedException();
        }

        public Airline_Company Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Airline_Company> GelAll()
        {
            throw new NotImplementedException();
        }

        private Airline_Company Extraction (string sp_name,string parameter)
        {
            IList<Airline_Company> amara = Reader(sp_name, parameter);
            return new Airline_Company
            {
                Id = amara[0].Id,
                Name = amara[0].Name
            };
        }
    }
}
