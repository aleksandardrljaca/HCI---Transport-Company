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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADTransport.Forms
{
    public partial class MyAccountForm : Form
    {
        private string _lang;
        private Employee _employee;
        public MyAccountForm(Employee emp, string lang)
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
                askBox.ForeColor= Color.FromArgb(255, 140, 4);
                crdntlsGBox.ForeColor= Color.FromArgb(255, 140, 4);
                usrNameLbl.ForeColor= Color.FromArgb(255, 140, 4);
                pswdLbl.ForeColor= Color.FromArgb(255, 140, 4);
                reTypePswdLbl.ForeColor= Color.FromArgb(255, 140, 4);
                changeCrdntlsBtn.ForeColor= Color.FromArgb(255, 140, 4);
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }
        private void txtBoxFocus(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (picBox == usrNmPBOx)
                usrNmPBOx.Focus();
            else if (picBox == pswdPicBox)
                pswdPicBox.Focus();

        }

        private void MyAccountForm_Load(object sender, EventArgs e)
        {
            crdntlsGBox.Enabled = false;
        }

        private void askBox_Click(object sender, EventArgs e)
        {
            if (askBox.Checked)
                crdntlsGBox.Enabled = true;
            else crdntlsGBox.Enabled = false;

        }

        private void changeCrdntlsBtn_Click(object sender, EventArgs e)
        {
            if ("" == usrTBox.Text || "" == pswdTBox.Text || "" == rePswdTBox.Text)
            {
                if (_lang == "en-US")
                    MessageBox.Show("Mandatory fields empty!", "Error");
                else MessageBox.Show("Polja nisu popunjena!", "Error");
            }
            else if (pswdTBox.Text != rePswdTBox.Text)
            {
                if (_lang == "en-US")
                    MessageBox.Show("Passwords do not match!", "Error");
                else MessageBox.Show("Lozinke se ne poklapaju!", "Error");
            }
            else if (!"".Equals(usrTBox.Text) && !"".Equals(pswdTBox.Text) || !"".Equals(rePswdTBox.Text) && pswdTBox.Text.Equals(rePswdTBox.Text))
            {
                EmployeeWrapper.UpdateCredentials(_employee.Id, usrTBox.Text, pswdTBox.Text);
                _employee = EmployeeWrapper.GetEmployee(usrTBox.Text, HashUtil.GetHash(pswdTBox.Text));
                if (_lang == "en-US")
                    MessageBox.Show("Successfully updated credentials!", "Error");
                else MessageBox.Show("Uspješna promjena kredencijala!", "Error");
                if (_employee.IsAdmin == 0)
                {
                    AdministrativeAssistant form = (AdministrativeAssistant)this.FindForm().Parent.Parent;
                    form.UpdateEmployee(_employee.Username, _employee.Password);

                }
                else if (_employee.IsAdmin == 1)
                {
                    AdminForm form = (AdminForm)this.FindForm().Parent.Parent;
                    form.UpdateEmployee(_employee.Username, _employee.Password);
                }
            }


        }

       
    }
}
