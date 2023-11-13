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
        public string lang;
        public Employee employee;
        public DriversForm(Employee emp, string lang)
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

        private void DriversForm_Load(object sender, EventArgs e)
        {
            List<Driver> drivers = DriverWrapper.GetDrivers();
            driversDGV.DataSource = drivers;
            driversDGV.Columns["ID"].Width = 30;
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
                    if (lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripOrdrs = new ContextMenuStrip();
            contextMenuStripOrdrs.Items.Add(deleteMenuItem);
            driversDGV.ContextMenuStrip = contextMenuStripOrdrs;
        }

        private void addDriverBtn_Click(object sender, EventArgs e)
        {
            if (!"".Equals(driverNameTBox.Text) && !"".Equals(driverLastNameTBox.Text) && !"".Equals(driverYearsTBox.Text))
            {
                string firstName = driverNameTBox.Text;
                string lastName = driverLastNameTBox.Text;
                int yearsOfExperience;
                int.TryParse(driverYearsTBox.Text, out yearsOfExperience);
                DriverWrapper.InsertDriver(firstName,lastName,yearsOfExperience);
                List<Driver> drivers = DriverWrapper.GetDrivers();
                driversDGV.DataSource = drivers;
                driversDGV.Columns["ID"].Width = 30;
                driverNameTBox.Clear();
                driverLastNameTBox.Clear();
                driverYearsTBox.Clear();
            }
            else
            {
                if (lang == "en-US") MessageBox.Show("No data entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
