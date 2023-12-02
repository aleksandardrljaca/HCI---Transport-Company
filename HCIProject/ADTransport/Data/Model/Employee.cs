using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
   public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public int IsAdmin { get; set; }
        public int Theme { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Employee(int id, string usrName, string passwd, string name, string surname, double salary, int isAdmin, int theme)
        {
            this.Id = id;
            this.Username = usrName;
            this.Password = passwd;
            this.Name = name;
            this.Surname = surname;
            this.Salary = salary;
            this.IsAdmin = isAdmin;
            this.Theme = theme;

        }
        //administrative assistant
        public Employee(int id, string usrName, string passwd, string name, string surname, double salary)
        {
            this.Id = id;
            this.Username = usrName;
            this.Password = passwd;
            this.Name = name;
            this.Surname = surname;
            this.Salary = salary;
            

        }
        public override string ToString()
        {
            return Username + " " + Password + " " + Salary;
        }
    }
}
