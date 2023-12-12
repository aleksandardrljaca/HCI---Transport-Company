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
using System.Threading;
namespace ADTransport.Forms
{
    public partial class ClientsForm : Form
    {
        public int _theme;
        private string _lang;
        private bool _isEditMode = false;
        public ClientsForm(int theme, string lang)
        {
            this._theme = theme;
            this._lang = lang;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
            InitializeComponent();
            applyTheme();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            cancelBtn.Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            List<Clients> list = ClientWrapper.GetClients();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["ID"].Visible = false;
            if (_lang != "en-US")
            {
                dataGridView1.Columns["Name"].HeaderText = "Ime";
                dataGridView1.Columns["Contact"].HeaderText = "Kontakt";
            }
            ContextMenuStrip cms = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    ClientWrapper.DeleteClient(id);
                    list = ClientWrapper.GetClients();
                    dataGridView1.DataSource = list;

                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            };
            ToolStripMenuItem edit = new ToolStripMenuItem("Edit");
            edit.Click += (sen, ee) =>
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    _isEditMode = true;
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    string name = selectedRow.Cells["Name"].Value.ToString();
                    string contact = selectedRow.Cells["Contact"].Value.ToString();

                    GroupBoxEditMode(name, contact);


                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            };
            cms.Items.Add(deleteMenuItem);
            cms.Items.Add(edit);
            dataGridView1.ContextMenuStrip = cms;
            if (_lang == "en-US")
                edit.Text = "Edit";
            else edit.Text = "Izmijeni";

            if (_lang == "en-US")
                deleteMenuItem.Text = "Delete";
            else deleteMenuItem.Text = "Obriši";
        }
        private void applyTheme()
        {
            //light
            if (_theme == 0)
            {
                this.BackColor = Color.White;
            }
            //dark
            else if (_theme == 1)
            {
                this.BackColor = Color.FromArgb(26, 35, 46);
                groupBox1.ForeColor= Color.FromArgb(255, 140, 4);
                clientsOverviewLbl.ForeColor = Color.FromArgb(255, 140, 4);
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            _isEditMode = false;
            GroupBoxAddMode();
        }
        private void GroupBoxEditMode(string name, string contact)
        {
            cancelBtn.Visible = true;
            if (_lang == "en-US")
            {
                groupBox1.Text = "Edit client info";
                button1.Text = "Update";
            }
            else
            {
                groupBox1.Text = "Izmijenite podatke o klijentu";
                button1.Text = "Ažuriraj";
            }
            textBox1.Text = name;
            textBox2.Text = contact;
            
        }
        private void GroupBoxAddMode()
        {
            cancelBtn.Visible = false;
            if (_lang == "en-US")
            {
                groupBox1.Text = "Add new client";
                button1.Text = "Add client";
            }
            else
            {
                groupBox1.Text = "Dodavanje novog klijenta";
                button1.Text = "Dodajte klijenta";
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                if (_isEditMode)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int id;
                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    ClientWrapper.UpdateClient(id, textBox1.Text, textBox2.Text);
                }
                else ClientWrapper.AddClient(textBox1.Text, textBox2.Text);
                List<Clients> clients = ClientWrapper.GetClients();
                dataGridView1.DataSource = clients;
                textBox1.Clear();
                textBox2.Clear();
                GroupBoxAddMode();
                _isEditMode = false;
            }
            else
            {
                if (_lang == "en-US")
                    MessageBox.Show("Data not complete!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientsForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_isEditMode)
                dataGridView1.ClearSelection();
           /* _isEditMode = false;
            GroupBoxAddMode();*/
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            GroupBoxAddMode();
            dataGridView1.ClearSelection();
        }
    }
}
