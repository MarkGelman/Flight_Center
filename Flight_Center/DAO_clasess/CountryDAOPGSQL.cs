using Npgsql;
using System;
using System.Collections.Generic;

namespace Flight_Center
{
    public class CountryDAOPGSQL : ICountryDAO
    {
        string m_sp_name = "";
        public void Add(Country t)
        {
            m_sp_name= $"INSERT INTO tests VALUES ({t.Id},{t.Name},)";

            int row = NonReader(m_sp_name, "Add country");
        }

        public IList<Country> Get(int id)
        {
            m_sp_name = $"SELECT * FROM tests WHERE id = {id}";

            return Reader(m_sp_name, $"Get country by {id}");
        }

        public IList<Country> GelAll()
        {
            m_sp_name = $"SELECT * FROM tests";

            return Reader(m_sp_name, "Get all country");
        }

        

        public void Remove(Country t)
        {
            m_sp_name = $"DELETE FROM tests WHERE id ={t.Id}";
            int row = NonReader(m_sp_name, $"Delete Country {t.Name}");
        }

        public void Update(Country t)
        {
            m_sp_name = $"UPDATE tests SET id = {t.Id},name = {t.Name} ";
            int row = NonReader(m_sp_name, "Update Tests");
        }

        public List<Country> Reader(string query, string function)
        {
            List<Country> allCountries = new List<Country>();
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
                                Country t = new Country
                                {
                                    Id = (long)reader["id"],
                                    Name = (string)reader["name"],
                                };
                                allCountries.Add(t);
                            }
                            return allCountries;

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
