using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
    public class Invoice
    {
        public int ID { get; set;}
        public string Type { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public string Assistant { get; set; }
        public Invoice(int id,string type,string client,DateTime date,double price,string assistant)
        {
            this.ID = id;
            this.Type = type;
            this.Client = client;
            this.Date = date;
            this.TotalPrice = price;
            this.Assistant = assistant;
               
        }
    }
}
