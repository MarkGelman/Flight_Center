using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center.Interfaces.DAO
{
    class AirlineDAOPGSQL : IAirlineDAO
    {
        string _query = "";
        public void Add(Airline_Company t)
        {
            _query = $"INSERT INTO tests VALUES ({t.Id},{t.Name})";

            int row = NonReader(_query, "Add Airline_Company");
        }

        public IList<Airline_Company> GelAll()
        {
            _query = $"SELECT * FROM tests";

            return Reader(_query, "Get All Airline_Company");
        }

        public List<Airline_Company> GetAirlineByUsername(string name)
        {
            _query = $"SELECT * FROM tests WHERE name = '{name}'";

            return Reader(_query, $"Get airline company by {name}");
        }

        public IList<Airline_Company> Get(int id)
        {
            _query = $"SELECT * FROM tests WHERE id = {id}";

            return Reader(_query, $"Get airline company by {id}");
        }

        public List<Airline_Company> GetAllAirlineByCountry(string country)
        {
            _query = $"SELECT * FROM tests WHERE name = '{country}'";

            return Reader(_query, $"Get all airline company by {country}");
        }

        public void Remove(Airline_Company t)
        {
            _query = $"DELETE FROM tests WHERE id ={t.Id}";
            int row = NonReader(_query, $"Delete airline company by {t.Name}");
        }

        public void Update(Airline_Company t)
        {
            _query = $"UPDATE tests SET id = {t.Id},name = {t.Name} ";
            int row = NonReader(_query, $"Update airline company {t.Name}");
        }

        public List<Airline_Company> Reader(string query, string function)
        {
            List<Airline_Company> allAirlineCompanies = new List<Airline_Company>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Fligth_CenterAppConfig.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
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

        
    }
}
