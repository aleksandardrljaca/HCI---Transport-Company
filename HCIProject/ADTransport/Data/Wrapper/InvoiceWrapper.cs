using ADTransport.Data.DBUtil;
using ADTransport.Data.Exceptions;
using ADTransport.Data.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Wrapper
{
    public class InvoiceWrapper
    {
        private static readonly string SELECT_ALL = @"SELECT faktura.ID,faktura.Tip,CONCAT(klijent.Ime,' ',klijent.Kontakt) AS Klijent,
                                                    narudzbenica.Datum,narudzbenica.UkupnaCijena,CONCAT(zaposleni.Ime,' ',zaposleni.Prezime) AS Fakturisao from faktura
                                                    INNER JOIN  narudzbenica on narudzbenica.ID=faktura.NARUDZBENICA_ID
                                                    INNER JOIN klijent on narudzbenica.KLIJENT_IDKlijenta=klijent.IDKlijenta
                                                    INNER JOIN zaposleni on zaposleni.ID=faktura.ZAPOSLENI_ID";
        private static readonly string INSERT = @"INSERT INTO faktura(Tip,NARUDZBENICA_ID,ZAPOSLENI_ID) values (@TipFakture,@IdNarudzbenice,@IdZaposlenog)";
        private static readonly string DELETE = @"DELETE FROM faktura WHERE faktura.ID=@IdFakture";

        public static List<Invoice> GetInvoices()
        {
            List<Invoice> invoices= new List<Invoice>();
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
                    invoices.Add(new Invoice(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDouble(4),reader.GetString(5)));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && conn != null)
                {
                    MySQLUtil.CloseQuietly(reader, conn);
                }
            }
            return invoices;
        }
        public static bool InsertInvoice(string type,int orderId,int employeeId)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@TipFakture", type);
                cmd.Parameters.AddWithValue("@IdNarudzbenice", orderId);
                cmd.Parameters.AddWithValue("@IdZaposlenog", employeeId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
            finally
            {
                
               MySQLUtil.CloseQuietly(conn);
                
            }
            return true;
        }
        public static bool DeleteInvoice(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IdFakture", id);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {

                MySQLUtil.CloseQuietly(conn);

            }
            return true;
        }

    }
}
