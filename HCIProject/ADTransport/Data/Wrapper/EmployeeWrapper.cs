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
using ADTransport.Data.HashUtils;
namespace ADTransport.Data.Wrapper
{
    class EmployeeWrapper
    {
        private static readonly string SELECT_EMPLOYEE =
            @"SELECT ID,KorisnickoIme,Lozinka,Ime,Prezime,Plata,IsAdmin,Tema
            FROM Zaposleni WHERE Zaposleni.KorisnickoIme=@KorisnickoIme AND Zaposleni.Lozinka=@Lozinka";
        private static readonly string SELECT_ALL_EMPLOYEES = @"SELECT * FROM Zaposleni";
        private static readonly string CHANGE_THEME = @"UPDATE Zaposleni SET Zaposleni.Tema=@Tema WHERE Zaposleni.ID=@Id";
        private static readonly string UPDATE_CREDENTIALS = @"UPDATE Zaposleni SET Zaposleni.KorisnickoIme=@KorisnickoIme, Zaposleni.Lozinka=@Lozinka WHERE Zaposleni.ID=@Id";
        private static readonly string SELECT_ALL_ASSISTANTS = @"SELECT zaposleni.ID,zaposleni.KorisnickoIme,zaposleni.Lozinka,zaposleni.Ime,zaposleni.Prezime,zaposleni.Plata FROM zaposleni WHERE zaposleni.isAdmin=0";
        private static readonly string ADD_ASSISANT = @"INSERT INTO zaposleni(KorisnickoIme,Lozinka,Ime,Prezime,Plata,isAdmin,Tema) values (@KIme,@Loz,@Ime,@Prezime,@Plata,0,0)";
        private static readonly string DELETE_EMPLOYEE = @"DELETE FROM zaposleni WHERE zaposleni.ID=@Id";
        private static readonly string UPDATE_ASSISTANT = @"UPDATE zaposleni SET zaposleni.Ime=@Ime,zaposleni.Prezime=@Prezime,zaposleni.KorisnickoIme=@KorisnickoIme,zaposleni.Lozinka=@Lozinka,zaposleni.Plata=@Plata WHERE zaposleni.Id=@Id";
        public static Employee GetEmployee(string usrName, string passwd)
        {
            Employee employee = null;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_EMPLOYEE;
                cmd.Parameters.AddWithValue("@KorisnickoIme", usrName);
                cmd.Parameters.AddWithValue("@Lozinka", passwd);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    employee = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6), reader.GetInt32(7));
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
            return employee;
        }

        public static bool DeleteEmployee(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;


            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_EMPLOYEE;
                cmd.Parameters.AddWithValue("@Id", id);
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

        public static bool ChangeTheme(int id,int tema)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            

            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = CHANGE_THEME;
                cmd.Parameters.AddWithValue("@Tema", tema);
                cmd.Parameters.AddWithValue("@Id", id);
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

        public static List<Employee> GetAssistants()
        {
            List<Employee> employees = new List<Employee>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL_ASSISTANTS;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    employees.Add(new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetDouble(5)));
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
            return employees;
        }

        public static bool UpdateAssistant(int id, string firstName, string lastName, string username, string password, double salary)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_ASSISTANT;
                cmd.Parameters.AddWithValue("@Ime", firstName);
                cmd.Parameters.AddWithValue("@Prezime", lastName);
                cmd.Parameters.AddWithValue("@KorisnickoIme", username);
                cmd.Parameters.AddWithValue("@Lozinka", password);
                cmd.Parameters.AddWithValue("@Plata", salary);
                cmd.Parameters.AddWithValue("@Id", id);
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

        public static bool UpdateCredentials(int id, string name, string pass)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;


            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_CREDENTIALS;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@KorisnickoIme", name);
                string pswdHash = HashUtil.GetHash(pass);
                cmd.Parameters.AddWithValue("@Lozinka", pswdHash);
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

        public static bool InsertEmployee(string username, string password, string firstName, string lastName, double salary)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;


            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = ADD_ASSISANT;
                cmd.Parameters.AddWithValue("@KIme", username);
                string pswdHash = HashUtil.GetHash(password);
                cmd.Parameters.AddWithValue("@Loz", pswdHash);
                cmd.Parameters.AddWithValue("@Ime", firstName);
                cmd.Parameters.AddWithValue("@Prezime", lastName);
                cmd.Parameters.AddWithValue("@Plata", salary);
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

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                conn = MySQLUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL_EMPLOYEES;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    employees.Add(new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6), reader.GetInt32(7)));
            }
            catch (Exception e )
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
            return employees;
        }
    }
}
