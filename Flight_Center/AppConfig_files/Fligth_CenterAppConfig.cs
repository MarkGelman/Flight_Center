using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Flight_Center
{
    class Fligth_CenterAppConfig
    {
        private string m_file_name;
        private JObject m_configRoot;
        internal static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string conn_string { get; set; }


        public Fligth_CenterAppConfig()
        {
            Init("Fligth_CenterConfig.json");
        }

        internal void Init(string file_name)
        {
            m_file_name = file_name;

            if (!File.Exists(m_file_name))
            {
                Console.WriteLine($"File {m_file_name} not exist!");
                Environment.Exit(-1);
            }

            var reader = File.OpenText(m_file_name);
            string json_string = reader.ReadToEnd();

            JObject jo = (JObject)JsonConvert.DeserializeObject(json_string);
            m_configRoot = (JObject)jo["Flight_Center"];
           conn_string = m_configRoot["ConnectionString"].Value<string>();

        }

        static bool TestDbConnection()
        {
            try
            {
                using (var con = new NpgsqlConnection(conn_string))
                {
                    con.Open();
                    return true;
                }

            }

            catch (Exception ex)
            {
                _log.Error($"Connection failed.Exception: {ex}");
                Console.WriteLine($"Connection failed.Exception: {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
                return false;
            }
        }

        private static List<Dictionary<string, object>> Run_sp_Reader(string conn_string, string sp_name,
            NpgsqlParameter[] parameters)
        {
            
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            if (TestDbConnection())
            {
                try
                {
                    using (var conn = new NpgsqlConnection(conn_string))
                    {
                        conn.Open();

                        NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                        command.CommandType = System.Data.CommandType.StoredProcedure; // this is default

                        //используя AddRange мы можем сразу передать СП полученый массив параметров
                        command.Parameters.AddRange(parameters);

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Dictionary<string, object> one_row = new Dictionary<string, object>();
                            foreach (var item in reader.GetColumnSchema())
                            {
                                object column_value = reader[item.ColumnName];
                                one_row.Add(item.ColumnName, column_value);
                            }
                            items.Add(one_row);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine($"Function {sp_name} failed. parameters: {string.Join(",", parameters.Select(_ => _.ParameterName + " : " + _.Value))}");
                }
                return items;
            }
            else
            {
                Environment.Exit(-1);
                return null;
            }
        }

        public int Run_Sp_NonReader(string sp_name, string task)
        {
            if (TestDbConnection())
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conn_string))
                    {
                        connection.Open();
                        using (NpgsqlCommand command = new NpgsqlCommand(sp_name, connection))
                        {
                            return command.ExecuteNonQuery();
                        }
                    }
                }

                catch (Exception ex)
                {
                    Fligth_CenterAppConfig._log.Error($"Connection failed.Exception: {ex}");
                    Console.WriteLine($"Process '{ task}' failed.Exception : {ex}");
                    Console.ReadKey();
                    Environment.Exit(-1);
                    return 0;
                }
            }
            else
            {
                Environment.Exit(-1);
                return 0;
            }
        }
    }
}
