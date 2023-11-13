using ADTransport.Data.Model;
using ADTransport.Data.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace ADTransport.Forms
{
    public partial class LiabilitiesForm : Form
    {
        public string lang;
        public Employee employee;
        public LiabilitiesForm(Employee emp,string lang)
        {
            this.lang = lang;
            this.employee = emp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            int theme = employee.Theme;
            //light
            if (theme == 0)
            {
                this.BackColor = Color.White;
            }
            //dark
            else if (theme == 1)
            {
                this.BackColor = Color.FromArgb(26, 35, 46);
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }
        private void HideColumnsLiabilitiesTable()
        {
            lbltsDGV.Columns["DriverId"].Visible = false;
            lbltsDGV.Columns["VehicleId"].Visible = false;
            lbltsDGV.Columns["AdministrativeAssistantId"].Visible = false;
            lbltsDGV.Columns["Id"].Width = 30;
            lbltsDGV.Columns["FromDate"].Width = 70;
            lbltsDGV.Columns["UntilDate"].Width = 70;
            lbltsDGV.Columns["AdministrativeAssistant"].Width = 130;

        }

        private void LiabilitiesForm_Load(object sender, EventArgs e)
        {
            addLblt.Enabled = false;
            List<Liabilities> liabilities = LiabilitiesWrapper.GetLiabilities();
            lbltsDGV.DataSource = liabilities;
            HideColumnsLiabilitiesTable();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click+= (sen,ee) =>
            {
                if (lbltsDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = lbltsDGV.SelectedRows[0];

                    int id, driverId,vehId;
                    DateTime from, until;
                    int.TryParse(selectedRow.Cells["Id"].Value.ToString(), out id);
                    DateTime.TryParse(selectedRow.Cells["FromDate"].Value.ToString(), out from);
                    DateTime.TryParse(selectedRow.Cells["UntilDate"].Value.ToString(), out until);
                    int.TryParse(selectedRow.Cells["DriverId"].Value.ToString(), out driverId);
                    int.TryParse(selectedRow.Cells["VehicleId"].Value.ToString(), out vehId);
                    Liabilities lblt = new Liabilities(id,from,until,driverId,vehId,employee.Id);
                    LiabilitiesWrapper.DeleteLiability(lblt.Id);
                    liabilities = LiabilitiesWrapper.GetLiabilities();
                    lbltsDGV.DataSource = liabilities;
                    HideColumnsLiabilitiesTable();
                }
                else
                {
                    if (lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripLblts = new ContextMenuStrip();
            contextMenuStripLblts.Items.Add(deleteMenuItem);
            lbltsDGV.ContextMenuStrip = contextMenuStripLblts;


            List<Driver> drivers = DriverWrapper.GetDrivers();
            driversDGV.DataSource = drivers;
           
            List<Vehicle> list = VehicleWrapper.GetVehicles();
            vehiclesDGV.DataSource = list;
           

        }

        private void addLblt_Click(object sender, EventArgs e)
        {
            Driver d=null;
            Vehicle v = null;
            if (driversDGV.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = driversDGV.SelectedRows[0];

                int id, yoe;
                int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                int.TryParse(selectedRow.Cells["YearsOfExperience"].Value.ToString(), out yoe);
                d= new Driver(id, selectedRow.Cells["Name"].Value.ToString(),
                    selectedRow.Cells["SurName"].Value.ToString(), yoe);
                
            }
            if (vehiclesDGV.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = vehiclesDGV.SelectedRows[0];
                int id, prodYear;
                int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                string registration = selectedRow.Cells["Registration"].Value.ToString();
                string model = selectedRow.Cells["Model"].Value.ToString();
                int.TryParse(selectedRow.Cells["FactoryDate"].Value.ToString(), out prodYear);
                v = new Vehicle(id, registration, model, prodYear);
            }
            if (d != null && v != null)
            {
                string from,until;
                if (lang == "en-US")
                {
                    
                    from = Interaction.InputBox("Please type in date",
                       "From date",
                       "Format: year-month-day",
                       900,
                       450);
                    until = Interaction.InputBox("Please type in date",
                           "Until date",
                           "Format: year-month-day",
                           900,
                           450);
                }
                else {
                    
                    from = Interaction.InputBox("Unesite datum zaduženja",
                    "Od datuma",
                    "Format: godina-mjesec-dan",
                    0,
                    0);
                    until = Interaction.InputBox("Unesite datum razduženja",
                           "Do datuma",
                           "Format: godin-mjesec-dan",
                           0,
                           0);
                }
                

               if(!"".Equals(from) && !"".Equals(until) && !"Format: year-month-day".Equals(from) && !"Format: year-month-day".Equals(until)
                    && !"Format: godina-mjesec-dan".Equals(from) && !"Format: godina-mjesec-dan".Equals(until))
                {
                    DateTime fromDate, untilDate;
                    DateTime.TryParse(from, out fromDate);

                    DateTime.TryParse(until, out untilDate);


                    LiabilitiesWrapper.AddLiability(fromDate, untilDate, d.ID, v.ID, employee.Id);

                    List<Liabilities> list = LiabilitiesWrapper.GetLiabilities();
                    lbltsDGV.DataSource = list;
                }
               else
                {
                    if (lang == "en-US")
                        MessageBox.Show("No infomration about date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Niste unijeli datume!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }else{
                if(lang=="en-US")
                    MessageBox.Show("Data missing, please select rows again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Podaci nisu selektovani ispravno", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void driversDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (vehiclesDGV.SelectedRows.Count == 1)
                addLblt.Enabled = true;
        }

        private void vehiclesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (driversDGV.SelectedRows.Count == 1)
                addLblt.Enabled = true;
        }
    }
}
