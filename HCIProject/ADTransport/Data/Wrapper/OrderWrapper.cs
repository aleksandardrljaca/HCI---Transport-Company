using ADTransport.Data.DBUtil;
using ADTransport.Data.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADTransport.Data.Wrapper
{
    public class OrderWrapper
    {
        private static readonly string SELECT_ALL = @"SELECT narudzbenica.ID,klijent.Ime as Klijent,klijent.Kontakt as 'Kontakt klijenta', narudzbenica.Datum,narudzbenica.UkupnaCijena,vozac.Ime as Vozač FROM narudzbenica
                                                    INNER JOIN klijent on klijent.IDKlijenta=narudzbenica.KLIJENT_IDKlijenta
                                                    INNER JOIN vozac_vozilo on vozac_vozilo.IdZaduzenja=narudzbenica.VOZAC_VOZILO_IDZaduzenja
                                                    INNER JOIN vozac on vozac.ID=vozac_vozilo.VOZAC_ID";
        private static readonly string CREATE_ORDER = "napraviNarudzbenicu";
        private static readonly string ADD_SERVICE = "dodavanjeUsluge";
        private static readonly string DELETE_ORDER = "brisanjeNarudzbenice";
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL;
                reader=cmd.ExecuteReader();
                while (reader.Read())
                    orders.Add(new Order(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetDateTime(3), reader.GetDouble(4), reader.GetString(5)));

            }catch(Exception e)
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
            return orders;

        }
        public static bool CreateAnOrder(int clientId,int assistantId,DateTime deliveryDate)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = CREATE_ORDER;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pKlijentId", clientId);
                cmd.Parameters["@pKlijentId"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@pZaposleniId", assistantId);
                cmd.Parameters["@pZaposleniId"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@pDatumDostave", deliveryDate);
                cmd.Parameters["@pDatumDostave"].Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@retVal", MySqlDbType.Bool);
                cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
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
            return (bool)cmd.Parameters["@retVal"].Value;
        }
        public static bool AddServiceToOrder(int serviceID)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = ADD_SERVICE;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIdUsluge",serviceID);
                cmd.Parameters["@pIdUsluge"].Direction = ParameterDirection.Input;
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
        public static bool DeleteOrder(int orderId)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_ORDER;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIdN", orderId);
                cmd.Parameters["@pIdN"].Direction = ParameterDirection.Input;
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
