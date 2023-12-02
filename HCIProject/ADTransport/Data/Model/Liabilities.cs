using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.Model
{
    public class Liabilities
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }
        public string Registration { get; set; }
        public string Model { get; set; }
        public int FactoryDate { get; set; }
        public string Driver { get; set; }
        public string AdministrativeAssistant { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int AdministrativeAssistantId { get; set; }
        public Liabilities(int id,DateTime from,DateTime until,int driver,int vehicle,int assistant)
        {
            this.Id = id;
            this.FromDate = from;
            this.UntilDate = until;
            this.DriverId = driver;
            this.VehicleId = vehicle;
            this.AdministrativeAssistantId = assistant;
        }
        public Liabilities(int id,DateTime from,DateTime until,string reg,string model,int facDate,string driver,string assistant)
        {
            this.Id = id;
            this.FromDate = from;
            this.UntilDate = until;
            this.Registration = reg;
            this.Model = model;
            this.FactoryDate = facDate;
            this.Driver = driver;
            this.AdministrativeAssistant = assistant;
        }
    }
}
