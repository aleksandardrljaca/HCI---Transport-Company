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
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom ubacivanja vozila.");
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
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja zaposlenih.");
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
    }
}
