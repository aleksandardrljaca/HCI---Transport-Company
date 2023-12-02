using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.DBUtil
{
   public static class MySQLUtil
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlHCI"].ConnectionString;

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void CloseQuietly(MySqlConnection conn)
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch { }
        }

        public static void CloseQuietly(MySqlDataReader reader)
        {
            try
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            catch { }
        }

        public static void CloseQuietly(MySqlDataReader reader, MySqlConnection conn)
        {
            CloseQuietly(reader);
            CloseQuietly(conn);
        }
    }
}
