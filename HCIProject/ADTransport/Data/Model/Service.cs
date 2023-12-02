using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
    public class Service
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public Service(int id,string type,double price)
        {
            this.ID = id;
            this.Type = type;
            this.Price = price;
        }
    }
}
