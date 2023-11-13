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

namespace ADTransport.Forms
{
    public partial class VehiclesForm : Form
    {
        public string lang;
        public Employee employee;
        public VehiclesForm(Employee emp,string lang)
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
        private void VehiclesForm_Load(object sender, EventArgs e)
        {
            List<Vehicle> vehicles = VehicleWrapper.GetVehicles();
            vehiclesDGV.DataSource = vehicles;
            vehiclesDGV.Columns["ID"].Width = 30;
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (vehiclesDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = vehiclesDGV.SelectedRows[0];

                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    VehicleWrapper.DeleteVehicle(id);
                    vehicles = VehicleWrapper.GetVehicles();
                    vehiclesDGV.DataSource = vehicles;

                }
                else
                {
                    if (lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripOrdrs = new ContextMenuStrip();
            contextMenuStripOrdrs.Items.Add(deleteMenuItem);
            vehiclesDGV.ContextMenuStrip = contextMenuStripOrdrs;
        }

        private void addVehicleBtn_Click(object sender, EventArgs e)
        {
            if(!"".Equals(registrationTBox.Text) && !"".Equals(modelTBox.Text) && !"".Equals(prodYearTBox.Text))
            {
                string registration = registrationTBox.Text;
                string model = modelTBox.Text;
                int productionYear;
                int.TryParse(prodYearTBox.Text, out productionYear);
                VehicleWrapper.InsertVehicle(registration, model, productionYear);
                List<Vehicle> vehicles = VehicleWrapper.GetVehicles();
                vehiclesDGV.DataSource = vehicles;
                vehiclesDGV.Columns["ID"].Width = 30;
                registrationTBox.Clear();
                modelTBox.Clear();
                prodYearTBox.Clear();
            }
            else
            {
                if (lang == "en-US") MessageBox.Show("No data entered!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
