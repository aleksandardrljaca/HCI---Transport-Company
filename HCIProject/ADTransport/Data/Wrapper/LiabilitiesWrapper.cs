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
    public class LiabilitiesWrapper
    {
        private static readonly string SELECT_ALL = @"SELECT * FROM vozac_vozilo";
        
        private static readonly string SELECT_ALL_JOINED = @"SELECT vozac_vozilo.IdZaduzenja,vozac_vozilo.DatumOd,vozac_vozilo.DatumDo,vozilo.RegistarskaOznaka,vozilo.Model,
                                                             vozilo.GodinaProizvodnje,CONCAT(vozac.Ime,' ',vozac.Prezime) as Vozač,CONCAT(zaposleni.Ime,' ',zaposleni.Prezime) as AdministrativniRadnik "+
                                                              "FROM vozac_vozilo "+
                                                              "INNER JOIN vozilo on vozilo.ID=vozac_vozilo.VOZILO_ID "+
                                                                "INNER JOIN vozac on vozac.ID=vozac_vozilo.VOZAC_ID "+
                                                                   "INNER JOIN zaposleni on zaposleni.ID=vozac_vozilo.ZAPOSLENI_ID";
        private static readonly string DELETE_LIABILITY = @"DELETE FROM vozac_vozilo WHERE vozac_vozilo.IDZaduzenja=@Id";
        private static  readonly string ADD_LIABILITY= @"INSERT INTO vozac_vozilo(DatumOd,DatumDo,VOZILO_ID,VOZAC_ID,ZAPOSLENI_ID) values (@Od,@Do,@vId,@dId,@aId)";

        public static List<Liabilities> GetLiabilities()
        {
            List<Liabilities> liabilities= new List<Liabilities>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL_JOINED;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    liabilities.Add(new Liabilities(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3),reader.GetString(4),reader.GetInt32(5),reader.GetString(6),reader.GetString(7)));
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
            return liabilities;
        }
        public static bool DeleteLiability(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_LIABILITY;
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

        public static bool AddLiability(DateTime from,DateTime until,int dId, int vId,int aId)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = ADD_LIABILITY;
                cmd.Parameters.AddWithValue("@Od", from);
                cmd.Parameters.AddWithValue("@Do", until);
                cmd.Parameters.AddWithValue("@vId", vId);
                cmd.Parameters.AddWithValue("@dId", dId);
                cmd.Parameters.AddWithValue("@aId", aId);
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
