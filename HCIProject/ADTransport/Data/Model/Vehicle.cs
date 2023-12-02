using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Registration { get; set; }    
        public string Model { get; set; }
        public int FactoryDate { get; set; }
      
        public Vehicle(int id,string reg, string model, int date)
        {
            this.ID = id;
            this.Registration = reg;
            this.Model = model;
            this.FactoryDate = date;
        }
    }
}
