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
        public string InvoiceType { get; set; }
        public string Assistant { get; set; }
        public Order(int id,string name,string contact,DateTime date,double price,string driver,string invoice,string assistant)
        {
            this.ID = id;
            this.ClientName = name;
            this.ClientContact = contact;
            this.Date = date;
            this.TotalPrice = price;
            this.DriversName = driver;
            this.InvoiceType = invoice;
            this.Assistant = assistant;
        }
       
    }
}
