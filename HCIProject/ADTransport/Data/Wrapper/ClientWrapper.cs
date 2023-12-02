using ADTransport.Data.DBUtil;
using ADTransport.Data.Exceptions;
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
    public class ClientWrapper
    {
        public static readonly string SELECT_ALL_CLIENTS = @"SELECT * FROM KLIJENT";
        private static readonly string ADD_CLIENT = @"INSERT INTO klijent(Ime,Kontakt) values (@Ime,@Kontakt)";
        private static readonly string GET_LAST_ADDED_CLIENT = @"SELECT * FROM klijent ORDER BY klijent.IDKlijenta DESC limit 1";
        private static readonly string DELETE_CLIENT = @"DELETE FROM klijent WHERE klijent.IDKlijenta=@IdKlijenta";
        public static List<Clients> GetClients()
        {
            List<Clients> clients = new List<Clients>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL_CLIENTS;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    clients.Add(new Clients(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && conn != null)
                {
                    MySQLUtil.CloseQuietly(reader, conn);
                }
            }
            return clients;
        }
        public static bool AddClient(string name,string contact)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = ADD_CLIENT;
                cmd.Parameters.AddWithValue("@Ime", name);
                cmd.Parameters.AddWithValue("@Kontakt", contact);
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
            return true;
          
        }
        public static bool DeleteClient(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_CLIENT;
                cmd.Parameters.AddWithValue("@IdKlijenta", id);
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
        public static Clients GetMostRecentClient()
        {
            Clients client = null;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = GET_LAST_ADDED_CLIENT;
                
                reader = cmd.ExecuteReader();
                if(reader.Read())
                    client=new Clients(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && conn != null)
                {
                    MySQLUtil.CloseQuietly(reader, conn);
                }
            }
            return client;
        }
    }
}
