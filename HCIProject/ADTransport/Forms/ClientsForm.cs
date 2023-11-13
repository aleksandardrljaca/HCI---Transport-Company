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
        public int theme;
        public ClientsForm(int theme, string lang)
        {
            this.theme = theme;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            Thread.CurrentThread.CurrentCulture=new System.Globalization.CultureInfo(lang);
            applyTheme();
            InitializeComponent();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            List<Clients> list = ClientWrapper.GetClients();
            dataGridView1.DataSource = list;
            
        }
        private void applyTheme()
        {
            //light
            if (theme == 0)
            {
                this.BackColor = Color.White;
            }
            //dark
            else if (theme == 1)
            {
                this.BackColor = Color.FromArgb(26,35,46);
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }
    }
}
