using ADTransport.Data.HashUtils;
using ADTransport.Data.Model;
using ADTransport.Data.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADTransport.Forms
{
    public partial class AdminForm : Form
       
    {
        public Employee admin;
        public string lang;
        public AdminForm(Employee emp,string lang)
        {
            this.admin = emp;
            this.lang = lang;
            this.FormBorderStyle = FormBorderStyle.None;

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            this.Controls.Clear();
            InitializeComponent();
            ApplyTheme();
        }
        public void RefreshForm(string l)
        {
            this.lang = l;
            admin = EmployeeWrapper.GetEmployee(admin.Username, admin.Password);
            this.FormBorderStyle = FormBorderStyle.None;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            this.Controls.Clear();
            InitializeComponent();
            ApplyTheme();
        }
        public void UpdateEmployee(string name, string pass)
        {
            
            this.admin = EmployeeWrapper.GetEmployee(name, pass);
        }
        private void ApplyTheme()
        {

            int theme = admin.Theme;
            //light
            if (theme == 0)
            {
                this.welcomePanel.BackColor = Color.White;
            }
            //dark
            else if (theme == 1)
            {
                this.welcomePanel.BackColor = Color.FromArgb(26, 35, 46);
            }
            //supercool
            else
            {
                this.welcomePanel.BackColor = Color.FromArgb(255, 140, 4);
            }

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            
        }

        private void stngsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(this.admin, this.lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void accntBtn_Click(object sender, EventArgs e)
        {
            MyAccountForm form = new MyAccountForm(this.admin, this.lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vehiclesBtn_Click(object sender, EventArgs e)
        {
            VehiclesForm form = new VehiclesForm(admin,lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            ServicesForm form = new ServicesForm(admin,lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void driversBtn_Click(object sender, EventArgs e)
        {
            DriversForm form = new DriversForm(admin, lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void assistantsBtn_Click(object sender, EventArgs e)
        {
            AssistantsForm form = new AssistantsForm(admin,lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void AdminForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
