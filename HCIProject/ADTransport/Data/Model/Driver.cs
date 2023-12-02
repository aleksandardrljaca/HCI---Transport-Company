using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
    public class Driver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; } 
        public int YearsOfExperience { get; set; }
        public Driver(int id,string name,string surname,int yoe)
        {
            this.ID = id;
            this.Name = name;
            this.SurName = surname;
            this.YearsOfExperience = yoe;
        }
        
    }
}
