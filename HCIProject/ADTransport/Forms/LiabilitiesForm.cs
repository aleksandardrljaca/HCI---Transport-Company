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
        private string _lang;
        private Employee _employee;
        public LiabilitiesForm(Employee emp, string lang)
        {
            this._lang = lang;
            this._employee = emp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            int theme = _employee.Theme;
            //light
            if (theme == 0)
            {
                this.BackColor = Color.White;
            }
            //dark
            else if (theme == 1)
            {
                this.BackColor = Color.FromArgb(26, 35, 46);
                label1.ForeColor = Color.FromArgb(255, 140, 4);
                label2.ForeColor = Color.FromArgb(255, 140, 4);
                label3.ForeColor = Color.FromArgb(255, 140, 4);
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
            lbltsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            lbltsDGV.MultiSelect = false;
            addLblt.Enabled = false;
            List<Liabilities> liabilities = LiabilitiesWrapper.GetLiabilities();
            lbltsDGV.DataSource = liabilities;
            lbltsDGV.Columns["ID"].Visible = false;
            lbltsDGV.Columns["Driver"].Width = 149;
            lbltsDGV.Columns["AdministrativeAssistant"].Width = 148;
            HideColumnsLiabilitiesTable();

            List<Driver> drivers = DriverWrapper.GetFreeDrivers();
            driversDGV.DataSource = drivers;
            driversDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            driversDGV.Columns["ID"].Visible = false;
            driversDGV.MultiSelect = false;
            List<Vehicle> list = VehicleWrapper.GetFreeVehicles();
            vehiclesDGV.DataSource = list;
            vehiclesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vehiclesDGV.Columns["ID"].Visible = false;
            vehiclesDGV.MultiSelect = false;
            driversDGV.Columns["Name"].Width = 111;
            driversDGV.Columns["SurName"].Width = 111;
            driversDGV.Columns["YearsOfExperience"].Width = 111;
            vehiclesDGV.Columns["Registration"].Width = 102;
            vehiclesDGV.Columns["Model"].Width = 102;
            vehiclesDGV.Columns["FactoryDate"].Width = 102;

            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
             {
                 if (lbltsDGV.SelectedRows.Count == 1)
                 {
                     DataGridViewRow selectedRow = lbltsDGV.SelectedRows[0];

                     int id, driverId, vehId;
                     DateTime from, until;
                     int.TryParse(selectedRow.Cells["Id"].Value.ToString(), out id);
                     DateTime.TryParse(selectedRow.Cells["FromDate"].Value.ToString(), out from);
                     DateTime.TryParse(selectedRow.Cells["UntilDate"].Value.ToString(), out until);
                     int.TryParse(selectedRow.Cells["DriverId"].Value.ToString(), out driverId);
                     int.TryParse(selectedRow.Cells["VehicleId"].Value.ToString(), out vehId);
                     Liabilities lblt = new Liabilities(id, from, until, driverId, vehId, _employee.Id);
                     LiabilitiesWrapper.DeleteLiability(lblt.Id);
                     liabilities = LiabilitiesWrapper.GetLiabilities();
                     lbltsDGV.DataSource = liabilities;
                     HideColumnsLiabilitiesTable();
                     drivers = DriverWrapper.GetFreeDrivers();
                     driversDGV.DataSource = drivers;
                     list = VehicleWrapper.GetFreeVehicles();
                     vehiclesDGV.DataSource = list;
                 }
                 else
                 {
                     if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                     else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                 }

             };
            ContextMenuStrip contextMenuStripLblts = new ContextMenuStrip();
            contextMenuStripLblts.Items.Add(deleteMenuItem);
            lbltsDGV.ContextMenuStrip = contextMenuStripLblts;
            if (_lang == "en-US")
            {
                lbltsDGV.Columns["FromDate"].HeaderText = "From date";
                lbltsDGV.Columns["UntilDate"].HeaderText = "Until date";
                lbltsDGV.Columns["FactoryDate"].HeaderText = "Production year";
                lbltsDGV.Columns["AdministrativeAssistant"].HeaderText = "Administrative assistant";

                vehiclesDGV.Columns["FactoryDate"].HeaderText = "Production year";

                driversDGV.Columns["Name"].HeaderText = "First name";
                driversDGV.Columns["SurName"].HeaderText = "Last name";
                driversDGV.Columns["YearsOfExperience"].HeaderText = "Years of experience";
            }
            else
            {
                lbltsDGV.Columns["FromDate"].HeaderText = "Od datuma";
                lbltsDGV.Columns["UntilDate"].HeaderText = "Do datuma";
                lbltsDGV.Columns["Registration"].HeaderText = "Registracija";
                lbltsDGV.Columns["FactoryDate"].HeaderText = "Godina proizvodnje";
                lbltsDGV.Columns["Driver"].HeaderText = "Vozač";
                lbltsDGV.Columns["AdministrativeAssistant"].HeaderText = "Administrativni radnik";

                vehiclesDGV.Columns["FactoryDate"].HeaderText = "Godina proizvodnje";
                vehiclesDGV.Columns["Registration"].HeaderText = "Registracija";

                driversDGV.Columns["Name"].HeaderText = "Ime";
                driversDGV.Columns["SurName"].HeaderText = "Prezime";
                driversDGV.Columns["YearsOfExperience"].HeaderText = "Godine iskustva";
                
            }

          
        }

        private void addLblt_Click(object sender, EventArgs e)
        {
            Driver d = null;
            Vehicle v = null;
            if (driversDGV.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = driversDGV.SelectedRows[0];

                int id, yoe;
                int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                int.TryParse(selectedRow.Cells["YearsOfExperience"].Value.ToString(), out yoe);
                d = new Driver(id, selectedRow.Cells["Name"].Value.ToString(),
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
                string from, until;
                if (_lang == "en-US")
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
                else
                {

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


                if (!"".Equals(from) && !"".Equals(until) && !"Format: year-month-day".Equals(from) && !"Format: year-month-day".Equals(until)
                     && !"Format: godina-mjesec-dan".Equals(from) && !"Format: godina-mjesec-dan".Equals(until))
                {
                    DateTime fromDate, untilDate;
                    DateTime.TryParse(from, out fromDate);

                    DateTime.TryParse(until, out untilDate);


                    LiabilitiesWrapper.AddLiability(fromDate, untilDate, d.ID, v.ID, _employee.Id);

                    List<Liabilities> list = LiabilitiesWrapper.GetLiabilities();
                    lbltsDGV.DataSource = list;
                    List<Driver> drivers = DriverWrapper.GetFreeDrivers();
                    driversDGV.DataSource = drivers;
                    List<Vehicle> veh = VehicleWrapper.GetFreeVehicles();
                    vehiclesDGV.DataSource =veh;

                }
                else
                {
                    if (_lang == "en-US")
                        MessageBox.Show("No infomration about date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Niste unijeli datume!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (_lang == "en-US")
                    MessageBox.Show("Data missing, please select rows again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Podaci nisu selektovani ispravno", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void LiabilitiesForm_MouseClick(object sender, MouseEventArgs e)
        {
            driversDGV.ClearSelection();
            vehiclesDGV.ClearSelection();
            lbltsDGV.ClearSelection();
        }

        private void vehiclesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*vehiclesDGV.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            vehiclesDGV.Rows[e.RowIndex].Selected = true;*/
            if (driversDGV.SelectedRows.Count == 1)
                addLblt.Enabled = true;
        }

        private void driversDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*driversDGV.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            driversDGV.Rows[e.RowIndex].Selected = true;*/
            if (vehiclesDGV.SelectedRows.Count == 1)
                addLblt.Enabled = true;
        }

        private void lbltsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
