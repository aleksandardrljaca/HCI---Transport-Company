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
        public ClientsForm(int theme, string lang)
        {
            this._theme = theme;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
            applyTheme();
            InitializeComponent();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            List<Clients> list = ClientWrapper.GetClients();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["ID"].Visible = false;

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
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }
}
