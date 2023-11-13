using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
    public class Order
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientContact { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public string DriversName { get; set; }
        public Order(int id,string name,string contact,DateTime date,double price,string driver)
        {
            this.ID = id;
            this.ClientName = name;
            this.ClientContact = contact;
            this.Date = date;
            this.TotalPrice = price;
            this.DriversName = driver;
        }
      
    }
}
