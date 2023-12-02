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
        private Employee _admin;
        private string _lang;
        public AdminForm(Employee emp, string lang)
        {
            this._admin = emp;
            this._lang = lang;
            this.FormBorderStyle = FormBorderStyle.None;

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            this.Controls.Clear();
            InitializeComponent();
            ApplyTheme();
        }
        public void RefreshForm(string l)
        {
            this._lang = l;
            _admin = EmployeeWrapper.GetEmployee(_admin.Username, _admin.Password);
            this.FormBorderStyle = FormBorderStyle.None;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_lang);
            this.Controls.Clear();
            InitializeComponent();
            ApplyTheme();
        }
        public void UpdateEmployee(string name, string pass)
        {
            this._admin = EmployeeWrapper.GetEmployee(name, pass);
        }
        private void ApplyTheme()
        {

            int theme = _admin.Theme;
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
            SettingsForm form = new SettingsForm(this._admin, this._lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void accntBtn_Click(object sender, EventArgs e)
        {
            MyAccountForm form = new MyAccountForm(this._admin, this._lang);
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
            VehiclesForm form = new VehiclesForm(_admin, _lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            ServicesForm form = new ServicesForm(_admin, _lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void driversBtn_Click(object sender, EventArgs e)
        {
            DriversForm form = new DriversForm(_admin, _lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void assistantsBtn_Click(object sender, EventArgs e)
        {
            AssistantsForm form = new AssistantsForm(_admin, _lang);
            welcomePanel.Controls.Clear();
            welcomePanel.Controls.Add(form);
            form.Show();
        }

        private void AdminForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
