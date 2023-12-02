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
    public partial class SettingsForm : Form
    {
        private Employee _employee;
        private string _lang;
        public SettingsForm(Employee emp, string lang)
        {
            this._lang = lang;
            this._employee = emp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            InitializeComponent();
            ApplyTheme();

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
        private void ApplyTheme()
        {

            int theme = _employee.Theme;
            if (this._lang == "en-US")
                radioBtnUS.Checked = true;
            else radioBtnSR.Checked = true;
            //light
            if (theme == 0)
            {
                lightThemeBtn.Checked = true;
                this.BackColor = Color.White;
            }
            //dark
            else if (theme == 1)
            {
                darkThemeBtn.Checked = true;
                this.BackColor = Color.FromArgb(26, 35, 46);
            }
            //supercool
            else
            {
                coolThemeBtn.Checked = true;
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }

        private void ApplyLangBtnClick(object sender, EventArgs e)
        {
            if (radioBtnSR.Checked)
            {
                _lang = "sr-Latn-RS";
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_lang);
                this.Controls.Clear();
                InitializeComponent();

            }
            else if (radioBtnUS.Checked)
            {
                _lang = "en-US";
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_lang);
                this.Controls.Clear();
                InitializeComponent();
            }
            if (_employee.IsAdmin == 0)
            {
                AdministrativeAssistant p = (AdministrativeAssistant)this.FindForm().Parent.Parent;
                p.RefreshForm(_lang);
            }
            else
            {
                AdminForm af = (AdminForm)this.FindForm().Parent.Parent;
                af.RefreshForm(_lang);
            }
        }

        private void ApplyThemeBtnClick(object sender, EventArgs e)
        {
            if (lightThemeBtn.Checked)
            {
                EmployeeWrapper.ChangeTheme(_employee.Id, 0);
                _employee = EmployeeWrapper.GetEmployee(_employee.Username, _employee.Password);
                ApplyTheme();


            }
            else if (darkThemeBtn.Checked)
            {
                EmployeeWrapper.ChangeTheme(_employee.Id, 1);
                _employee = EmployeeWrapper.GetEmployee(_employee.Username, _employee.Password);
                ApplyTheme();

            }
            else if (coolThemeBtn.Checked)
            {
                EmployeeWrapper.ChangeTheme(_employee.Id, 2);
                _employee = EmployeeWrapper.GetEmployee(_employee.Username, _employee.Password);
                ApplyTheme();

            }
            if (_employee.IsAdmin == 0)
            {
                AdministrativeAssistant form = (AdministrativeAssistant)this.FindForm().Parent.Parent;
                form.RefreshForm(_lang);
            }
            else
            {
                AdminForm af = (AdminForm)this.FindForm().Parent.Parent;
                af.RefreshForm(_lang);
            }
        }
    }
}
