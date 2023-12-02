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
        private static readonly string SELECT_SERVICES_FROM_ORDER = @"SELECT usluga.ID,usluga.Tip,usluga_narudzbenica.Cijena FROM usluga 
                                                                               INNER JOIN usluga_narudzbenica ON usluga_narudzbenica.USLUGA_ID=usluga.ID
                                                                                WHERE usluga_narudzbenica.NARUDZBENICA_ID=@Id";
        private static readonly string SELECT_SERVICES_FROM_INVOICE = @"SELECT usluga.ID,usluga.Tip,usluga_narudzbenica.Cijena FROM usluga 
                                                                               INNER JOIN usluga_narudzbenica ON usluga_narudzbenica.USLUGA_ID=usluga.ID
                                                                               INNER JOIN faktura on usluga_narudzbenica.NARUDZBENICA_ID=faktura.NARUDZBENICA_ID
                                                                                WHERE faktura.NARUDZBENICA_ID=@Id";
        private static readonly string UPDATE_SERVICE = @"UPDATE usluga SET usluga.Tip=@Tip,usluga.Cijena=@Cijena WHERE usluga.ID=@IdUsluge";
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
        public static List<Service> GetServicesFromOrderInvoice(int id,string type)
        {
            List<Service> services = new List<Service>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                if(type.Equals("order"))
                    cmd.CommandText = SELECT_SERVICES_FROM_ORDER;
                else cmd.CommandText = SELECT_SERVICES_FROM_INVOICE;
                cmd.Parameters.AddWithValue("@Id", id);
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

        public static bool UpdateService(int id, string type, double price)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_SERVICE;
                cmd.Parameters.AddWithValue("@Tip", type);
                cmd.Parameters.AddWithValue("@Cijena", price);
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
