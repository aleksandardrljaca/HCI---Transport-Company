using ADTransport.Data.DBUtil;
using ADTransport.Data.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADTransport.Data.Wrapper
{
    public class ServiceWrapper
    {
        private static readonly string SELECT_ALL = @"SELECT * FROM usluga";
        private static readonly string DELETE_SERVICE = @"DELETE FROM usluga WHERE usluga.ID=@IdUsluge";
        private static readonly string INSERT_SERVICE = @"INSERT INTO usluga(Tip,Cijena) values (@Type,@Price)";
        public static List<Service> GetServices()
        {
            List<Service> services = new List<Service>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    services.Add(new Service(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2)));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (reader != null && conn != null)
                {
                    MySQLUtil.CloseQuietly(reader, conn);
                }
            }
            return services;
        }
        public static bool InsertService(string type,double price)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT_SERVICE;
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
            return true;
        }
        internal static bool DeleteService(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_SERVICE;
                cmd.Parameters.AddWithValue("@IdUsluge", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
            return true;
        }
    }
}
