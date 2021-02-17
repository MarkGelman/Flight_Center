﻿using Npgsql;
using System;
using System.Collections.Generic;

namespace Flight_Center
{
    public class CountryDAOPGSQL : ICountryDAO
    {
        string _query = "";
        public void Add(Country t)
        {
            _query = $"INSERT INTO tests VALUES ({t.Id},{t.Name},)";

            int row = NonReader(_query, "Add country");
        }

        public IList<Country> Get(int id)
        {
            _query = $"SELECT * FROM tests WHERE id = {id}";

            return Reader(_query, $"Get country by {id}");
        }

        public IList<Country> GelAll()
        {
            _query = $"SELECT * FROM tests";

            return Reader(_query, "Get all country");
        }

        

        public void Remove(Country t)
        {
            _query = $"DELETE FROM tests WHERE id ={t.Id}";
            int row = NonReader(_query, $"Delete Country {t.Name}");
        }

        public void Update(Country t)
        {
            _query = $"UPDATE tests SET id = {t.Id},name = {t.Name} ";
            int row = NonReader(_query, "Update Tests");
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
