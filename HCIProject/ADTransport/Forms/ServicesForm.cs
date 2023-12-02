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
        private string _lang;
        private Employee _employee;
        private bool _isEditMode = false;
        public ServicesForm(Employee emp, string lang)
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

        private void Services_Load(object sender, EventArgs e)
        {
            servicesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            List<Service> Services = ServiceWrapper.GetServices();
            servicesDGV.DataSource = Services;
            servicesDGV.Columns["ID"].Visible = false;
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
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripSrvcs = new ContextMenuStrip();
            contextMenuStripSrvcs.Items.Add(deleteMenuItem);
            servicesDGV.ContextMenuStrip = contextMenuStripSrvcs;

            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
            editMenuItem.Click += (sen, ee) =>
            {
                if (servicesDGV.SelectedRows.Count == 1)
                {
                    _isEditMode = true;
                    DataGridViewRow selectedRow = servicesDGV.SelectedRows[0];

                    string type = selectedRow.Cells["Type"].Value.ToString();

                    int price;
                    int.TryParse(selectedRow.Cells["Price"].Value.ToString(), out price);
                    GroupBoxEditMode(type, price);


                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            contextMenuStripSrvcs.Items.Add(editMenuItem);
        }

        private void GroupBoxEditMode(string type, int price)
        {
            if (_lang == "en-US")
            {
                serviceGBox.Text = "Edit service";
                addServiceBtn.Text = "Update";
            }
            else
            {
                serviceGBox.Text = "Azuriranje usluge";
                addServiceBtn.Text = "Azurirajte";
            }
            serviceTypeTBox.Text = type;
            priceTBox.Text = price.ToString();
        }

        private void addServiceBtn_Click(object sender, EventArgs e)
        {
            if (!"".Equals(serviceTypeTBox.Text) && !"".Equals(priceTBox.Text))
            {

                string type = serviceTypeTBox.Text;
                double price;
                double.TryParse(priceTBox.Text, out price);
                if (_isEditMode)
                {
                    DataGridViewRow selectedRow = servicesDGV.SelectedRows[0];
                    int id;
                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    ServiceWrapper.UpdateService(id, type, price);
                }
                else ServiceWrapper.InsertService(type, price);
                List<Service> services = ServiceWrapper.GetServices();
                servicesDGV.DataSource = services;
                servicesDGV.Columns["ID"].Visible = false;
                serviceTypeTBox.Clear();
                priceTBox.Clear();
                GroupBoxAddMode();
                _isEditMode = false;
            }
            else
            {
                if (_lang == "en-US") MessageBox.Show("No data entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void servicesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _isEditMode = false;
            GroupBoxAddMode();
        }

        private void ServicesForm_MouseClick(object sender, MouseEventArgs e)
        {
            servicesDGV.ClearSelection();
            _isEditMode = false;
            GroupBoxAddMode();

        }

        private void GroupBoxAddMode()
        {
            if (_lang == "en-US")
            {
                serviceGBox.Text = "Add new service";
                addServiceBtn.Text = "Add service";
            }
            else
            {
                serviceGBox.Text = "Dodavanje nove usluge";
                addServiceBtn.Text = "Dodajte uslugu";
            }
            serviceTypeTBox.Clear();
            priceTBox.Clear();

        }
    }
}
