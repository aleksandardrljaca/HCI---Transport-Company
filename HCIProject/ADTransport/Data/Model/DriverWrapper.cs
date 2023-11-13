using ADTransport.Data.DBUtil;
using ADTransport.Data.Exceptions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADTransport.Data.Model
{
    public class DriverWrapper
    {
        private static readonly string SELECT_ALL_DRIVERS = @"SELECT * FROM Vozac";
        private static readonly string DELETE_DRIVER = @"DELETE FROM Vozac WHERE Vozac.ID=@Id";
        private static readonly string INSERT_DRIVER = @"INSERT INTO vozac(Ime,Prezime,GodineIskustva) values (@firstName,@lastName,@yearsOfExperience)";
        public static object MySqlCommand { get; private set; }

        public static List<Driver> GetDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL_DRIVERS;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    drivers.Add(new Driver(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));

            }
            catch (Exception)
            {
                throw new DataAccessException("Greška pri dohvatanju vozača!");
            }
            finally
            {
                if (reader != null && conn != null)
                {
                    MySQLUtil.CloseQuietly(reader, conn);
                }
            }
            return drivers;
        }

        public static bool DeleteDriver(int iD)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd= null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText =DELETE_DRIVER;
                cmd.Parameters.AddWithValue("@Id", iD);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
            return true;
        }

        public static bool InsertDriver(string firstName, string lastName, int yearsOfExperience)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT_DRIVER;
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@yearsOfExperience", yearsOfExperience);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
            return true;
        }
    }
}
