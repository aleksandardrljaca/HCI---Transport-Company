using ADTransport.Data.Model;
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
    public partial class DriversForm : Form
    {
        private string _lang;
        private Employee _employee;
        private bool _isEditMode = false;
        public DriversForm(Employee emp, string lang)
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

        private void DriversForm_Load(object sender, EventArgs e)
        {
            driversDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            List<Driver> drivers = DriverWrapper.GetDrivers();
            driversDGV.DataSource = drivers;
            driversDGV.Columns["ID"].Visible = false;
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (driversDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = driversDGV.SelectedRows[0];

                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    DriverWrapper.DeleteDriver(id);
                    drivers = DriverWrapper.GetDrivers();
                    driversDGV.DataSource = drivers;

                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripDrvrs = new ContextMenuStrip();
            contextMenuStripDrvrs.Items.Add(deleteMenuItem);
            driversDGV.ContextMenuStrip = contextMenuStripDrvrs;



            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
            editMenuItem.Click += (sen, ee) =>
            {
                if (driversDGV.SelectedRows.Count == 1)
                {
                    _isEditMode = true;
                    DataGridViewRow selectedRow = driversDGV.SelectedRows[0];

                    string name = selectedRow.Cells["Name"].Value.ToString();
                    string lastname = selectedRow.Cells["SurName"].Value.ToString();
                    int yof;
                    int.TryParse(selectedRow.Cells["YearsOfExperience"].Value.ToString(), out yof);
                    GroupBoxEditMode(name, lastname, yof);


                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            contextMenuStripDrvrs.Items.Add(editMenuItem);

        }
        private void GroupBoxAddMode()
        {
            if (_lang == "en-US")
            {
                driversGBox.Text = "Add new driver";
                addDriverBtn.Text = "Add driver";
            }
            else
            {
                driversGBox.Text = "Dodavanje novog vozača";
                addDriverBtn.Text = "Dodajte vozača";
            }
            driverNameTBox.Clear();
            driverLastNameTBox.Clear();
            driverYearsTBox.Clear();
        }
        private void GroupBoxEditMode(string name, string lastname, int yof)
        {
            if (_lang == "en-US")
            {
                driversGBox.Text = "Edit driver";
                addDriverBtn.Text = "Update";
            }
            else
            {
                driversGBox.Text = "Izmjenite podatke o vozacu";
                addDriverBtn.Text = "Azuriraj";
            }
            driverNameTBox.Text = name;
            driverLastNameTBox.Text = lastname;
            driverYearsTBox.Text = yof.ToString();
        }

        private void addDriverBtn_Click(object sender, EventArgs e)
        {
            if (!"".Equals(driverNameTBox.Text) && !"".Equals(driverLastNameTBox.Text) && !"".Equals(driverYearsTBox.Text))
            {

                string firstName = driverNameTBox.Text;
                string lastName = driverLastNameTBox.Text;
                int yearsOfExperience;
                int.TryParse(driverYearsTBox.Text, out yearsOfExperience);
                if (_isEditMode)
                {
                    DataGridViewRow selectedRow = driversDGV.SelectedRows[0];
                    int id;
                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    DriverWrapper.UpdateDriver(id, firstName, lastName, yearsOfExperience);
                }

                else DriverWrapper.InsertDriver(firstName, lastName, yearsOfExperience);
                List<Driver> drivers = DriverWrapper.GetDrivers();
                driversDGV.DataSource = drivers;

                GroupBoxAddMode();
                _isEditMode = false;

            }
            else
            {
                if (_lang == "en-US") MessageBox.Show("No data entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DriversForm_MouseClick(object sender, MouseEventArgs e)
        {
            driversDGV.ClearSelection();
            _isEditMode = false;
            GroupBoxAddMode();
        }

        private void driversDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _isEditMode = false;
            GroupBoxAddMode();
        }
    }
}
