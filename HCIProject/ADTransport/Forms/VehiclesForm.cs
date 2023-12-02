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
        private string _lang;
        private Employee _employee;
        private bool _isEditMode = false;
        public VehiclesForm(Employee emp, string lang)
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
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }
        private void VehiclesForm_Load(object sender, EventArgs e)
        {
            vehiclesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            List<Vehicle> vehicles = VehicleWrapper.GetVehicles();
            vehiclesDGV.DataSource = vehicles;
            vehiclesDGV.Columns["ID"].Visible = false;
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
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripVhcls = new ContextMenuStrip();
            contextMenuStripVhcls.Items.Add(deleteMenuItem);
            vehiclesDGV.ContextMenuStrip = contextMenuStripVhcls;


            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
            editMenuItem.Click += (sen, ee) =>
            {
                if (vehiclesDGV.SelectedRows.Count == 1)
                {
                    _isEditMode = true;
                    DataGridViewRow selectedRow = vehiclesDGV.SelectedRows[0];
                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    string registration = selectedRow.Cells["REgistration"].Value.ToString();
                    string model = selectedRow.Cells["Model"].Value.ToString();
                    int factoryDate;
                    int.TryParse(selectedRow.Cells["FactoryDate"].Value.ToString(), out factoryDate);
                    GroupBoxEditMode(registration, model, factoryDate);


                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            contextMenuStripVhcls.Items.Add(editMenuItem);
        }

        private void GroupBoxAddMode()
        {
            if (_lang == "en-US")
            {
                vehicleGBox.Text = "Add new vehicle";
                addVehicleBtn.Text = "Add vehicle";
            }
            else
            {
                vehicleGBox.Text = "Dodavanje novog vozila";
                addVehicleBtn.Text = "Dodajte vozilo";
            }
            registrationTBox.Clear();
            modelTBox.Clear();
            prodYearTBox.Clear();
        }
        private void GroupBoxEditMode(string name, string lastname, int yof)
        {
            if (_lang == "en-US")
            {
                vehicleGBox.Text = "Edit vehicle";
                addVehicleBtn.Text = "Update";
            }
            else
            {
                vehicleGBox.Text = "Izmjenite podatke o vozilu";
                addVehicleBtn.Text = "Azuriraj";
            }
            registrationTBox.Text = name;
            modelTBox.Text = lastname;
            prodYearTBox.Text = yof.ToString();
        }

        private void addVehicleBtn_Click(object sender, EventArgs e)
        {
            if (!"".Equals(registrationTBox.Text) && !"".Equals(modelTBox.Text) && !"".Equals(prodYearTBox.Text))
            {
                string registration = registrationTBox.Text;
                string model = modelTBox.Text;
                int productionYear;
                int.TryParse(prodYearTBox.Text, out productionYear);
                if (_isEditMode)
                {
                    DataGridViewRow selectedRow = vehiclesDGV.SelectedRows[0];
                    int id;
                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    VehicleWrapper.UpdateDriver(id, registration, model, productionYear);
                }
                else VehicleWrapper.InsertVehicle(registration, model, productionYear);
                List<Vehicle> vehicles = VehicleWrapper.GetVehicles();
                vehiclesDGV.DataSource = vehicles;
                vehiclesDGV.Columns["ID"].Width = 30;
                registrationTBox.Clear();
                modelTBox.Clear();
                prodYearTBox.Clear();
                GroupBoxAddMode();
                _isEditMode = false;
            }
            else
            {
                if (_lang == "en-US") MessageBox.Show("No data entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void VehiclesForm_MouseClick(object sender, MouseEventArgs e)
        {
            vehiclesDGV.ClearSelection();
            _isEditMode = false;
            GroupBoxAddMode();
        }

        private void vehiclesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _isEditMode = false;
            GroupBoxAddMode();
        }
    }
}
