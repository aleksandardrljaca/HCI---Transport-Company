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
    public partial class LoginForm : Form
    {
        private string _lang;
        public LoginForm()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this._lang = "en-US";
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void ExitPicBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogInBtnClick(object sender, EventArgs e)
        {
            tryLogging();
        }
        private void tryLogging()
        {
            string passwd = HashUtil.GetHash(pswdTxtBox.Text);
            Employee emp = EmployeeWrapper.GetEmployee(usrNameTxtBox.Text, passwd);
            if (emp == null)
            {
                string err = "Error";
                string msg = "Wrong credentials!";
                MessageBox.Show(msg, err, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (emp.IsAdmin == 1)
                {
                    AdminForm form = new AdminForm(emp, _lang);
                    this.Hide();
                    form.Show();

                }

                else if (emp.IsAdmin == 0)
                {
                    AdministrativeAssistant form = new AdministrativeAssistant(emp, _lang);
                    this.Hide();
                    form.Show();

                }

            }
        }
        private void LblUS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this._lang = "en-US";
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_lang);
            this.Controls.Clear();
            InitializeComponent();
        }

        private void LblSR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this._lang = "sr-Latn-RS";
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_lang);
            this.Controls.Clear();
            InitializeComponent();
        }
        private void txtBoxFocus(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (picBox == usrNamePicBox)
                usrNameTxtBox.Focus();
            else if (picBox == pswdPicBox)
                pswdTxtBox.Focus();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            usrNameTxtBox.Select();
            
            
        }

        private void usrNameLbl_Click(object sender, EventArgs e)
        {
            usrNameTxtBox.Focus();
        }

        private void pswdLbl_Click(object sender, EventArgs e)
        {
            pswdTxtBox.Focus();
        }

        private void usrNameTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
                tryLogging();
        }

        private void pswdTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                tryLogging();
        }
    }
}
