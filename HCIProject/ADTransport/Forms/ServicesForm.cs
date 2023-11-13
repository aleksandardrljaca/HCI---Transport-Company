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
    public partial class ServicesForm : Form
    {
        public string lang;
        public Employee employee;
        public ServicesForm(Employee emp, string lang)
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

        private void Services_Load(object sender, EventArgs e)
        {
            List<Service> Services = ServiceWrapper.GetServices();
            servicesDGV.DataSource = Services;
            servicesDGV.Columns["ID"].Width = 30;
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (servicesDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = servicesDGV.SelectedRows[0];

                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    ServiceWrapper.DeleteService(id);
                    Services = ServiceWrapper.GetServices();
                    servicesDGV.DataSource = Services;

                }
                else
                {
                    if (lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripOrdrs = new ContextMenuStrip();
            contextMenuStripOrdrs.Items.Add(deleteMenuItem);
            servicesDGV.ContextMenuStrip = contextMenuStripOrdrs;
        }

        private void addServiceBtn_Click(object sender, EventArgs e)
        {
            if (!"".Equals(serviceTypeTBox.Text) && !"".Equals(priceTBox.Text))
            {
                string type = serviceTypeTBox.Text;
                double price;
                double.TryParse(priceTBox.Text, out price);
                ServiceWrapper.InsertService(type,price);
                List<Service> services = ServiceWrapper.GetServices();
                servicesDGV.DataSource = services;
                servicesDGV.Columns["ID"].Width = 30;
                serviceTypeTBox.Clear();
                priceTBox.Clear();
            }
            else
            {
                if (lang == "en-US") MessageBox.Show("No data entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
