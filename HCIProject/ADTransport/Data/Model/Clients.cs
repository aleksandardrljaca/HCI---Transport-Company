using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
   public class Clients
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public Clients(int id, string name, string contact)
        {
            this.ID = id;
            this.Name = name;
            this.Contact = contact;
        }
    }
}
