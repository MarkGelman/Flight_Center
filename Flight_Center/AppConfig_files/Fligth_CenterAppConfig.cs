using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flight_Center
{
    class Fligth_CenterAppConfig
    {
        private string m_file_name;
        private JObject m_configRoot;
        internal static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string ConnectionString { get; set; }


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
            ConnectionString = m_configRoot["ConnectionString"].Value<string>();

        }

        static bool TestDbConnection()
        {
            try
            {
                using (var con = new NpgsqlConnection(ConnectionString))
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

        internal static NpgsqlConnection GetOpenConnection()
        {
            if (TestDbConnection())
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    return connection;
                }

            }
            Environment.Exit(-1);
            return null;
        }
    }
}
