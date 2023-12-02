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
        private static readonly string UPDATE_DRIVER = @"UPDATE vozac SET vozac.Ime=@Ime,vozac.Prezime=@Prezime,vozac.GodineIskustva=@Iskustvo WHERE vozac.ID=@Id";
        private static readonly string SELECT_FREE_DRIVERS = @"select vozac.ID,vozac.Ime,vozac.Prezime,vozac.GodineIskustva from vozac
                                                                left outer join vozac_vozilo on vozac_vozilo.VOZAC_ID=vozac.ID
                                                                where vozac_vozilo.VOZAC_ID is null or vozac_vozilo.DatumDo<curdate()";

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
        public static List<Driver> GetFreeDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_FREE_DRIVERS;
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

        public static bool UpdateDriver(int id,string firstName, string lastName, int yearsOfExperience)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_DRIVER;
                cmd.Parameters.AddWithValue("@Ime", firstName);
                cmd.Parameters.AddWithValue("@Prezime", lastName);
                cmd.Parameters.AddWithValue("@Iskustvo", yearsOfExperience);
                cmd.Parameters.AddWithValue("@Id", id);
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
