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
    public class VehicleWrapper
    {
        private static readonly string SELECT_ALL_VEHICLES = @"SELECT * FROM Vozilo";
        private static readonly string INSERT_VEHICLE = @"INSERT INTO Vozilo(Vozilo.RegistarskaOznaka,Vozilo.Model,Vozilo.GodinaProizvodnje) values (@Reg,@Model,@GodP)";
        private static readonly string DELETE_VEHICLE = @"DELETE FROM vozilo WHERE vozilo.ID=@IdVozila";
        private static readonly string UPDATE_VEHICLE = @"UPDATE vozilo SET vozilo.RegistarskaOznaka=@Registracija,vozilo.Model=@Model,vozilo.GodinaProizvodnje=@GP WHERE vozilo.ID=@IdVozila";
        private static readonly string SELECT_FREE_VEHICLES = @"select vozilo.ID,vozilo.RegistarskaOznaka,vozilo.Model,vozilo.GodinaProizvodnje from vozilo 
						                                        left outer join vozac_vozilo on vozac_vozilo.VOZILO_ID=vozilo.ID
						                                        where vozac_vozilo.VOZILO_ID is null or vozac_vozilo.DatumDo<curdate()";
        public static bool InsertVehicle(string reg,string model,int god)
        {
            MySqlConnection conn=null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT_VEHICLE;
                cmd.Parameters.AddWithValue("@Reg", reg);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@GodP", god);
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
        public static List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL_VEHICLES;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    vehicles.Add(new Vehicle(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
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
            return vehicles;
        }
        public static List<Vehicle> GetFreeVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_FREE_VEHICLES;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    vehicles.Add(new Vehicle(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
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
            return vehicles;
        }
        public static bool DeleteVehicle(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_VEHICLE;
                cmd.Parameters.AddWithValue("@IdVozila",id);
               
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

        public static bool UpdateDriver(int id, string registration, string model, int productionYear)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_VEHICLE;
                cmd.Parameters.AddWithValue("@Registracija", registration);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@GP", productionYear);
                cmd.Parameters.AddWithValue("@IdVozila", id);

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
